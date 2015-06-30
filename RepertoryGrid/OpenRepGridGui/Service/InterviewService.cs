using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenRepGridModel.Model;
using System.Xml.Linq;
using System.IO;
using RDotNet; 
using System.ComponentModel;
using LimeTree.BaseClasses;
using System.Diagnostics;
using LimeTree.Extensions;

namespace OpenRepGridGui.Service
{
    public class InterviewService : NotifyPropertyChanged
    {

        #region Enums As List

        public static Dictionary<String, Boolean> DendrogramType()
        {

            Dictionary<String, Boolean> d = new Dictionary<string, bool>();
            d.Add("triangle", true);
            d.Add("rectangle", false);
            return d;

        }

        public static Dictionary<String, Boolean> SomersD()
        {

            Dictionary<String, Boolean> d = new Dictionary<string, bool>();
            d.Add("columns", true);
            d.Add("rows", false);
            d.Add("symmetric", false);
            return d;

        }

        public static Dictionary<String, Boolean> DistanceMeasures()
        {

            Dictionary<String, Boolean> d = new Dictionary<string, bool>();
            d.Add("euclidean", true);
            d.Add("manhattan", false);
            d.Add("minkowski", false);
            d.Add("maximum", false);
            d.Add("canberra", false);
            d.Add("binary", false);
            return d;

        }

        public static Dictionary<String, Boolean> ClusterMethods()
        {

            Dictionary<String, Boolean> d = new Dictionary<string, bool>();
            d.Add("ward.D", false);
            d.Add("ward.D2", false);
            d.Add("complete", true);
            d.Add("single", false);
            d.Add("canberra", false);
            d.Add("mcquitty", false);
            d.Add("median", false);
            d.Add("centroid", false);
            return d;

        }

        public static Dictionary<String, Boolean> CorrelationTypes()
        {

            Dictionary<String, Boolean> d = new Dictionary<string, bool>();
            d.Add("pearson", true);
            d.Add("kendall", false);
            d.Add("spearman", false);
            return d;

        }

        public static Dictionary<String, Boolean> RotationMethods()
        {

            Dictionary<String, Boolean> d = new Dictionary<string, bool>();
            d.Add("none", false);
            d.Add("varimax", true);
            d.Add("promax", false);
            d.Add("cluster", false);
            return d;

        }

        #endregion

        #region Variables

        private ProjectService Parent;
        private Interview currentInterview;
        private StringBuilder rscript = new StringBuilder();

        #endregion

        #region Properties

        public Interview CurrentInterview
        {
            get { return currentInterview; }
            set { currentInterview = value; }
        }

        public RHelper.RHelper R
        {
            get
            {
                return this.Parent.R;
            }
        }

        public String rScript
        {
            get { return this.rscript.ToString(); }
        }

        #endregion

        #region Constructor
         
        public InterviewService(ProjectService value, Interview interview)
        {
            this.Parent = value;
            this.CurrentInterview = interview;
        }


        #endregion

        #region Saving

        public void SaveAs(FileInfo f)
        {
            string cmd = "";
            switch (f.Extension.ToLower())
            {
                case "txt":
                    cmd = string.Format("saveAsTxt({0}, \"{1}\")",
                        this.CurrentInterview.GridName,
                        f.FullName.Replace("\\", "/"));
                    break;
                case "xml":
                    this.CurrentInterview.getXML().Save(f.FullName);
                    break;
                case "rdata":
                    cmd = string.Format("save({0}, \"{1}\")",
                        this.CurrentInterview.GridName,
                        f.FullName.Replace("\\", "/"));
                    break;
                default:
                    throw new NotSupportedException(
                        string.Format("The filetype (*.{0}) is not supported",
                            f.Extension));
            }
            if (cmd.Length > 0) this.R.Evaluate(cmd);
        }

        #endregion
        

        
        #region Communicate with R

        public void GetFromR (Boolean DefineScale)
        {

            if (DefineScale)
            {
                int scaleMin = R.getInt(string.Format("{0}@scale$min", this.CurrentInterview.GridName));
                int scaleMax = R.getInt(string.Format("{0}@scale$max", this.CurrentInterview.GridName));

                this.defineDefaultScale(scaleMin, scaleMax);
            }
            GenericVector rConstructs = R.getGenericVector(string.Format("{0}@constructs", this.CurrentInterview.GridName));
            GenericVector rElements = R.getGenericVector(string.Format("{0}@elements", this.CurrentInterview.GridName));

            int I = rElements.Length;
            int J = rConstructs.Length;

            for (int i = 0; i < I; i++)
            {
                GenericVector rElement = rElements.ToList()[i].AsList();
                Element element = this.AddElement();
                element.Name = rElement.ToList()[0].AsCharacter().ToArray()[0];
                /*
                if (bw != null)
                {
                    if (bw.CancellationPending) throw new Exception("Process Cancelled");
                    int progress = (int)((i * 100) / I);
                    if (bw.WorkerReportsProgress)
                        bw.ReportProgress(progress,
                            string.Format("Importing Element {0} ({1}/{2}) --> {3}%",
                            element.Name,
                            (i + 1), I, progress));
                }
                */
                for (int j = 0; j < J; j++)
                {
                    /*
                    if (bw != null)
                    {
                        if (bw.CancellationPending) throw new Exception("Process Cancelled");
                    }
                     * */
                    Construct construct = null;
                    if (i == 0)
                    {
                        construct = this.AddConstruct();

                        GenericVector rConstruct = rConstructs.ToList()[j].AsList();
                        String lPole = rConstruct.ToList()[0].AsCharacter().ToArray()[0];
                        String rPole = rConstruct.ToList()[1].AsCharacter().ToArray()[0];
                        construct.ConstructPol = rPole;
                        construct.ContrastPol = lPole;
                        construct.Name = string.Format("{0} - {1}", lPole, rPole);
                        construct.HasChanges = false;
                    }
                    else
                    {
                        construct = this.CurrentInterview.Constructs[j];
                    }
                    /*
                    if (bw != null)
                    {
                        if (bw.CancellationPending) throw new Exception("Process Cancelled");
                    }
                     * */
                    int score = R.getInt(
                        string.Format("{0}@ratings[{1}]",
                            this.CurrentInterview.GridName,
                            ((i) * J + (j + 1))));
                    this.GiveRating(element, construct, score);
                }
            }

        }
         
        public void SetToR(Boolean PrintToConsole, String newGridName = "")
        {
            StringBuilder str = new StringBuilder();
            StringBuilder strElement = new StringBuilder();
            StringBuilder strConstructLPole = new StringBuilder();
            StringBuilder strConstructRPole = new StringBuilder();
            StringBuilder strScores = new StringBuilder();

            int minScale = this.CurrentInterview.Scales.Where(x => x.IsDefault).Min(x => x.Id);
            int maxScale = this.CurrentInterview.Scales.Where(x => x.IsDefault).Max(x => x.Id);
            string gridname = (newGridName.Length == 0 ? this.CurrentInterview.GridName : newGridName);

            strElement.Append("name= c(");
            strConstructLPole.Append("l.name= c(");
            strConstructRPole.Append("r.name= c(");
            strScores.Append("scores= c(");
            for (int i = 0; i < this.CurrentInterview.Constructs.Count; i++)
            {
                Construct construct = this.CurrentInterview.Constructs[i];

                strConstructLPole.Append(string.Format("\"{0}\"", construct.ContrastPol));
                strConstructRPole.Append(string.Format("\"{0}\"", construct.ConstructPol));
                if (i < this.CurrentInterview.Constructs.Count - 1)
                {
                    strConstructLPole.Append(",");
                    strConstructRPole.Append(",");
                }
                strScores.Append("\n\t\t\t");

                for (int j = 0; j < this.CurrentInterview.Elements.Count; j++)
                {
                    Element element = this.CurrentInterview.Elements[j];
                    if (i == 0)
                    {
                        strElement.Append(string.Format("\"{0}\"", element.Name));
                        if (j < this.CurrentInterview.Elements.Count - 1)
                        {
                            strElement.Append(",");
                        }
                    }


                    Score r = element.Scores.Single(x => x.ParentConstruct.Id.Equals(construct.Id));
                    strScores.Append(string.Format("{0}", r.getRatingForR()));
                    strScores.Append(",");

                }

            }

            int index = strScores.ToString().LastIndexOf(",");
            strElement.Append("),\n\t");
            strConstructLPole.Append("),\n\t");
            strConstructRPole.Append("),\n\t");

            strScores = strScores.Remove(index, 1);
            strScores.Append(")\n");


            str.Append("args <- list(\n\t");
            str.Append(strElement);
            str.Append(strConstructLPole);
            str.Append(strConstructRPole);
            str.Append(strScores);

            str.Append(")\n");
            str.Append(string.Format("{0} <- makeRepgrid(args)\n", gridname));
            str.Append(string.Format("{0} <- setScale({0}, {1}, {2})\n{0}\n",
                gridname, minScale, maxScale
             ));
            Debug.Print(str.ToString());
            if (PrintToConsole)
            {
                this.R.Evaluate(str.ToString(), false);
            }
            else
            {
                this.R.Execute(str.ToString());
            }
        }

        public void AppendRScript(String cmd)
        {
            this.rscript.Append(cmd);
            this.rscript.Append(Environment.NewLine);
            this.FirePropertyChanged("rScript");

        }

        public void ResetRScript()
        {
            rscript = new StringBuilder();
            this.FirePropertyChanged("rScript");
        }

        #endregion

        #region getScore
         
        public Score getScore(Element element, Guid IdConstruct)
        {
            return getScore(element,
                          CurrentInterview.Constructs.Single(x => x.Id.Equals(IdConstruct)));
        }
        public Score getScore(Guid IdElement, Guid IdConstruct)
        {
            return getScore(CurrentInterview.Elements.Single(x => x.Id.Equals(IdElement)),
                          CurrentInterview.Constructs.Single(x => x.Id.Equals(IdConstruct)));
        }
        public Score getScore(Guid IdElement, Construct construct)
        {
            return getScore(CurrentInterview.Elements.Single(x => x.Id.Equals(IdElement)), construct);
        }
        public Score getScore(Element element, Construct construct)
        {
            Score s = element.Scores.Single(x => x.ParentConstruct.Id.Equals(construct.Id));
            return s;
        }
            
        #endregion

        #region Methods
         
        public void Reset()
        {
            this.CurrentInterview.Elements.Clear();
            this.CurrentInterview.Constructs.Clear();
            this.CurrentInterview.Scales.Clear();
            this.ResetRScript();
        }

        public void defineDefaultScale(int min = -3, int max = 3)
        {
            if (min >= max) throw new ArgumentOutOfRangeException("The min Value must be larger than the max Value");
            ScaleItem si;

            si = new ScaleItem(this.CurrentInterview, int.MaxValue, "NAN");
            si = new ScaleItem(this.CurrentInterview, int.MinValue, "Not rated (interviewee doesn't want to rate this item)");
            if (max - min == 6)
            {
                si = new ScaleItem(this.CurrentInterview, 0 + min, "The contrast (left) pole applies totally");
                si = new ScaleItem(this.CurrentInterview, 1 + min, "The contrast (left) pole applies not totally, the construct (right) pole does not apply");
                si = new ScaleItem(this.CurrentInterview, 2 + min, "The contrast (left) pole rather applies than the construct (right) pole");
                si = new ScaleItem(this.CurrentInterview, 3 + min, "Neither the contrast (left) pole nor the construct (right) pole aplly");
                si = new ScaleItem(this.CurrentInterview, 4 + min, "The construct (right) pole rather applies than the contrast (left) pole");
                si = new ScaleItem(this.CurrentInterview, 5 + min, "The construct (right) pole applies not totally, the contrast (left) pole does not apply");
                si = new ScaleItem(this.CurrentInterview, 6 + min, "The construct (right) pole applies totally");
            }
            else
            {
                for (int i = min; i <= max; i++)
                {
                    si = new ScaleItem(this.CurrentInterview, i, "");
                }
            }

        }
         
        #endregion

        #region OpenRepGrid Functions


        #region Basic grid manipulation

        #region Rename

        [Obsolete("Changes are not immediately transferred to R")]
        public void RenameConstruct(Construct construct)
        {
            int index = this.CurrentInterview.Constructs.IndexOf(construct);
            string cmd = string.Format("setConstructAttr({0}, {1}, \"{2}\", \"{3}\")",
                this.CurrentInterview.GridName, index,
            construct.ContrastPol, construct.ConstructPol);
            this.AppendRScript(cmd);
            this.R.Evaluate(cmd);
        }

        [Obsolete("Changes are not immediately transferred to R")]
        public void RenameElement(Element element)
        {
            int index = this.CurrentInterview.Elements.IndexOf(element);
            string cmd = string.Format("setElementAttr({0}, {1}, \"{2}\")",
                this.CurrentInterview.GridName, index, element.Name);

            this.AppendRScript(cmd);
            this.R.Evaluate(cmd);
        }

        #endregion

        #region Add/Delete Elements and/or Constructs

        #region Constructs

        public Construct AddConstruct()
        {

            this.ResetRScript();
            Construct c = new Construct(this.CurrentInterview);
            this.CurrentInterview.Constructs.Add(c);
            this.CurrentInterview.FirePropertyChanged("Constructs");
            foreach (Element elem in this.CurrentInterview.Elements)
            {
                Score s = GiveRating(elem, c, int.MaxValue);
                s.PropertyChanged += new PropertyChangedEventHandler(s_PropertyChanged);
                elem.FirePropertyChanged("Scores");
            }

            c.PropertyChanged += new PropertyChangedEventHandler(con_PropertyChanged);
            return c;
        }

        public void DeleteConstruct(Construct c)
        {
            if (c == null) throw new ArgumentNullException();
            foreach (Element elem in this.CurrentInterview.Elements)
            {
                elem.Scores.RemoveAll(x => x.ParentConstruct.Id.Equals(c.Id));
            }

            int index = this.CurrentInterview.Constructs.IndexOf(c);
            this.CurrentInterview.Constructs.RemoveAt(index);
            this.CurrentInterview.FirePropertyChanged("Constructs");

        }

        public void DeleteConstruct(int i)
        {
            if (i > this.CurrentInterview.Constructs.Count - 1 || i < 0) throw new IndexOutOfRangeException();
            DeleteConstruct(this.CurrentInterview.Constructs[i]);
        }

        #endregion

        #region Elements

        public Element AddElement()
        {
            Element elem = new Element(this.CurrentInterview);
            this.CurrentInterview.Elements.Add(elem);
            elem.PropertyChanged += new PropertyChangedEventHandler(elem_PropertyChanged);
            this.ResetRScript();

            foreach (Construct c in this.CurrentInterview.Constructs)
            {
                Score s = GiveRating(elem, c, int.MaxValue);
                s.PropertyChanged += new PropertyChangedEventHandler(s_PropertyChanged);
            }
            elem.FirePropertyChanged("Scores");
            this.CurrentInterview.FirePropertyChanged("Elements");

            return elem;
        }

        public void DeleteElement(Element element)
        {
            if (element == null) throw new ArgumentNullException();
            int index = this.CurrentInterview.Elements.IndexOf(element);
            DeleteElement(index);
        }

        public void DeleteElement(int j)
        {
            if (j < 0 || j > this.CurrentInterview.Elements.Count - 1)
                throw new IndexOutOfRangeException();
            this.CurrentInterview.Elements.RemoveAt(j);

            this.CurrentInterview.FirePropertyChanged("Elements");
            /*if (rGrid == null) return;
            string cmd = string.Format("{0}<-{0}[,-{1}]",
                    this.CurrentInterview.GridName, j);

            this.AppendRScript(cmd);
            this.R.Evaluate(cmd);
            */
        }

        #endregion

        #endregion

        #region Reorder a grid

        public void ReorderGridFromRGrid()
        {

            this.CurrentInterview.Elements.Clear();
            this.CurrentInterview.FirePropertyChanged("Elements");
            this.CurrentInterview.Constructs.Clear();
            this.CurrentInterview.FirePropertyChanged("Constructs");
            this.GetFromR(false);
        }
         
        #region MoveElements

        public void SwapElements(int OldIndex, int NewIndex)
        {

            CurrentInterview.Elements.Swap(OldIndex, NewIndex);
            this.CurrentInterview.FirePropertyChanged("Elements");
            this.FirePropertyChanged("CurrentInterview");
        }

        public void MoveLeft(int index)
        {
            CurrentInterview.Elements.MoveUp(index);
            this.CurrentInterview.FirePropertyChanged("Elements");
            this.FirePropertyChanged("CurrentInterview");
        }

        public void MoveRight(int index)
        {
            CurrentInterview.Elements.MoveDown(index);
            this.CurrentInterview.FirePropertyChanged("Elements");
            this.FirePropertyChanged("CurrentInterview");
        }

        #endregion

        #region MoveConstructs

        public void SwapConstructs(int OldIndex, int NewIndex)
        {
            this.CurrentInterview.Constructs.Swap(OldIndex, NewIndex);
            this.CurrentInterview.FirePropertyChanged("Constructs");
            this.FirePropertyChanged("CurrentInterview");
        }

        public void MoveUp(int index)
        {

            this.CurrentInterview.Constructs.MoveUp(index);
            this.CurrentInterview.FirePropertyChanged("Constructs");
            this.FirePropertyChanged("CurrentInterview");
        }

        public void MoveDown(int index)
        {
            this.CurrentInterview.Constructs.MoveDown(index);
            this.CurrentInterview.FirePropertyChanged("Constructs");
            this.FirePropertyChanged("CurrentInterview");
        }

        #endregion

        #endregion

        #region Score

        public void CopyRatings(Element ElementSource, Element ElementDestination)
        {
            /*
            if (rGrid != null)
            {
                string cmd = string.Format("# Copying Scores from {0} to {1}",
                        ElementSource.Name, ElementDestination.Name);
                this.AppendRScript(cmd);
                this.R.Evaluate(cmd);

            }
             */
            foreach (Score s in ElementSource.Scores)
            {
                GiveRating(ElementDestination, s.ParentConstruct, s.ScaleItemId);
            }
        }

        public Score GiveRating(Element element, Construct construct, int value)
        {
            Predicate<ScaleItem> psi = new Predicate<ScaleItem>(x => x.Id == value);
            if (this.CurrentInterview.Scales.Any(x => psi(x)) == false)
                throw new KeyNotFoundException(
                    string.Format("The given Rating '{0}' is not part of the scale related to this construct. The Element can't be rated for non existing scale-keys.", value));
            /*if (rGrid != null)
            {
                int i = this.CurrentInterview.Constructs.IndexOf(construct) + 1;
                int j = this.CurrentInterview.Elements.IndexOf(element) + 1;
                string cmd = string.Format("{0}[{1},{2}] <- {3}",
                        this.CurrentInterview.GridName, i, j, value);
                this.AppendRScript(cmd);
                this.R.Evaluate(cmd);

            }*/
            Predicate<Score> pr = new Predicate<Score>(x => x.ParentConstruct.Id.Equals(construct.Id));
            if (element.Scores.Any(x => pr(x)) == false)
            {
                return new Score(element, construct, value);
            }
            else
            {
                Score r = element.Scores.Single(x => pr(x));
                r.ScaleItemId = value;
                return r;
            }

        }

        #endregion

        #endregion

        #region Analysis

        #region Description

        /// <summary>
        /// http://docu.openrepgrid.org/constructs_descriptives.html
        /// </summary>
        /// <returns></returns>
        /// tested.
        public DataFrame StatsGrid(Boolean InitRGrid, Boolean forConstructs,
            Boolean index = true, int trim = 20)
        {
            SetToR(InitRGrid);
            String cmd = string.Format("{0}({1}, index={2}, trim={3})",
                forConstructs ? "statsConstructs" : "statsElements",
                this.CurrentInterview.GridName,
                index ? "TRUE" : "FALSE",
                trim < 0 ? "NA" : trim.ToString()
             );
            this.AppendRScript(cmd);
            DataFrame dt = this.R.Evaluate(cmd)[0].AsDataFrame();
            return dt;
        }

        /// <summary>
        /// http://docu.openrepgrid.org/constructs_descriptives.html
        /// </summary>
        /// <returns></returns>
        /// tested.
        public DataFrame StatsConstructs(Boolean InitRGrid, Boolean index = true, int trim = 20)
        {
            return StatsGrid(InitRGrid, true, index, trim);
        }

        /// <summary>
        /// http://docu.openrepgrid.org/constructs_descriptives.html
        /// </summary>
        /// <returns></returns>
        /// tested.
        public DataFrame StatsElements(Boolean InitRGrid, Boolean index = true, int trim = 20)
        {
            return StatsGrid(InitRGrid, false, index, trim);
        }

        #endregion

        #region Constructs

        #region Correlations

        /// 
        /// <summary>Different types of correlations can be requested: PMC, Kendall tau rank correlation, Spearman rank correlation.</summary>
        /// <remarks>
        /// The correlations between constructs are used in a lot of occasions, 
        /// indices etc, and present a standard statistic. 
        /// Several types of correlations can be requested via the function constructCor.
        /// </remarks>
        /// <param name="method">A character string indicating which correlation coefficient is to be computed. One of "pearson" (default), "kendall" or "spearman", can be abbreviated. The default is "pearson".</param> 
        /// <param name="trim">Numeric. Number of digits to round to (default is 2).</param>
        /// <param name="digits">The number of characters a construct is trimmed to (default is 20). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.</param>
        /// <param name="ShowConstructIndex">Logical. Whether to add an extra index column so the column names are indexes instead of construct names. This option renders a neater output as long construct names will stretch the output (default is TRUE).</param>
        /// <param name="ShowColumnIndex">Logical. Whether to print the number of the construct. (default is TRUE).</param>
        /// <param name="toUpper">Whether to display upper triangle of correlation matrix only (default is FALSE).</param>
        /// <param name="PrintHeader"> Whether to print additional information in header.
        /// </param>
        /// <returns>Returns a matrix of construct correlations. </returns>
        public RDotNet.NumericMatrix ConstructCor(Boolean InitRGrid, String method = "pearson", int trim = 20, Boolean ShowConstructIndex = false)
        {
            this.SetToR(InitRGrid);
            if (InterviewService.CorrelationTypes().ContainsKey(method) == false)
                throw new MissingMethodException(string.Format("The requested method '{0}' is not supported.", method));
            string cmd = string.Format("ConCor{0} <- constructCor({0}, method=\"{1}\", trim={2}, index={3})",
                this.CurrentInterview.GridName, method, trim, ShowConstructIndex ? "T" : "F");
            this.AppendRScript(cmd);
            NumericMatrix nm = this.R.Evaluate(cmd)[0].AsNumericMatrix();
            return nm;
        }

        /// <summary>
        /// Print method for class constructCor. 
        /// </summary>
        /// <param name="digits">Numeric. Number of digits to round to (default is 2).</param>
        /// <param name="ShowColumnIndex">Logical. Whether to add an extra index column so the column names are indexes instead of construct names. This option renders a neater output as long construct names will stretch the output (default is TRUE).</param>
        /// <param name="toUpper">Whether to display upper triangle of correlation matrix only (default is TRUE).</param>
        /// <param name="PrintHeader">Whether to print additional information in header.</param>
        public void PrintConstructCor(int digits = 2, Boolean ShowColumnIndex = true, Boolean toUpper = true, Boolean PrintHeader = true)
        {
            string cmd = string.Format("print(ConCor{0}, digits={1}, col.index={2}, upper = {3}, header = {4})",
              this.CurrentInterview.GridName,
              digits,
              ShowColumnIndex ? "TRUE" : "FALSE",
               toUpper ? "TRUE" : "FALSE",
               PrintHeader ? "TRUE" : "FALSE"
              );
            this.AppendRScript(cmd);
            this.R.Evaluate(cmd);
        }


        /// <summary>
        /// The RMS is also known as 'quadratic mean' of the inter-construct correlations. 
        /// The RMS serves as a simplification of the correlation table. 
        /// It reflects the average relation of one construct to all other constructs.
        /// Note that as the correlations are squared during its calculation, 
        /// the RMS is not affected by the sign of the correlation 
        /// (cf. Fransella, Bell & Bannister, 2003, p. 86). 
        /// </summary>
        /// <param name="method">A character string indicating which correlation coefficient is to be computed. One of "pearson" (default), "kendall" or "spearman", can be abbreviated. The default is "pearson".</param>
        /// <param name="trim"> The number of characters a construct is trimmed to (default is NA). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.</param>
        /// <returns></returns>
        public DataFrame ConstructRmsCor(Boolean InitRGrid, String method = "pearson", int trim = -1)
        {
            this.SetToR(InitRGrid);
            string cmd = string.Format("constructRmsCor({0}, method =\"{1}\", trim = {2})",
                this.CurrentInterview.GridName, method, trim < 0 ? "NA" : trim.ToString());
            this.AppendRScript(cmd); 
            DataFrame dt = this.R.Evaluate(cmd)[0].AsDataFrame();
            return dt;

        }

        /// <summary>
        /// Somer'ss d is an assymetric association measure as it depends on which variable is set as dependent and independent. The direction of dependency needs to be specified. 
        /// </summary>
        /// <param name="dependent"> A string denoting the direction of dependency in the output table (as d is assymetrical). Possible values are "columns" (the default) for setting the columns as dependent, "rows" for setting the rows as the dependent variable and "symmetric" for the symmetrical Somers' d measure (the mean of the two directional values for code"columns" and "rows").</param>
        /// <param name="trim"> The number of characters a construct is trimmed to (default is 30). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.</param>
        /// <param name="ShowConstructIndex">Whether to print the number of the construct (default is TRUE).</param>
        /// <returns></returns>
        public RDotNet.NumericMatrix ConstructD(Boolean InitRGrid, String dependent = "columns", int trim = 30, Boolean ShowConstructIndex = false)
        {
            this.SetToR(InitRGrid);
            string cmd = string.Format("constructD({0}, dependent = \"{1}\", trim = {2}, index = {3})",
                this.CurrentInterview.GridName,
                dependent,
                trim < 0 ? "NA" : trim.ToString(),
              ShowConstructIndex ? "TRUE" : "FALSE");
            this.AppendRScript(cmd);
            NumericMatrix nm =  this.R.Evaluate(cmd)[0].AsNumericMatrix();

            return nm;
        }

        #endregion

        #region Distances

        /// <summary>
        /// http://docu.openrepgrid.org/constructs_distances.html
        /// Various distance measures between constructs are calculated. 
        /// </summary>
        /// <param name="method">The distance measure to be used. This must be one of "euclidean", "maximum", "manhattan", "canberra", "binary" or "minkowski". Any unambiguous substring can be given. For additional information on the different types type ?dist</param>
        /// <param name="p">The power of the Minkowski distance, in case "minkowski" is used as argument for dmethod.</param>
        /// <param name="trim">The number of characters a construct or element is trimmed to (default is 20). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.</param>
        /// <param name="index">Whether to print the number of the construct or element in front of the name (default is TRUE). This is useful to avoid identical row names, which may cause an error.</param>
        /// <returns></returns>
        public NumericMatrix DistanceConstructs(Boolean InitRGrid, string method = "euclidean", int p = 2, int trim = 20, Boolean index = true)
        {
            return Distance(InitRGrid, true, method, p, trim, index);
        }


        #endregion

        #region PCA

        /// <summary>
        /// Principal components analysis (PCA)
        /// Does an eigen value decomposition and returns eigen values, loadings, and degree of fit for a specified number of components. Basically it is just doing a principal components analysis (PCA) for n principal components of either a correlation or covariance matrix. Can show the residual correlations as well. The quality of reduction in the squared correlations is reported by comparing residual correlations to original correlations. Unlike princomp, this returns a subset of just the best nfactors. The eigen vectors are rescaled by the sqrt of the eigen values to produce the component loadings more typical in factor analysis. 
        /// Various methods for rotation and methods for the calculation of the correlations are available. Note that the number of factors has to be specified. For more information on the PCA function itself type ?principal. 
        /// </summary>
        /// <param name="nfactors">Number of components to extract </param>
        /// <param name="rotate">"none", "varimax", "promax" and "cluster" are possible rotations (default is none).</param>
        /// <param name="method">A character string indicating which correlation coefficient is to be computed. One of "pearson" (default), "kendall" or "spearman", can be abbreviated. The default is "pearson".</param>
        /// <param name="trim">The number of characters a construct is trimmed to (default is 7). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.</param>
        public void ConstructPCA(Boolean InitRGrid, int nfactors = 3, string rotate = "varimax", string method = "pearson", int trim = 7)
        {
            this.SetToR(InitRGrid);
            string cmd = string.Format("constructPca({0}, nfactors = {1}, rotate = \"{2}\", method = \"{3}\", trim = {4})",
                this.CurrentInterview.GridName,
                nfactors, rotate, method, trim < 0 ? "NA" : trim.ToString());
            this.AppendRScript(cmd);
            this.R.Evaluate(cmd);

        }

        #endregion

        #endregion

        #region Elements

        /// <summary>
        /// The correlations between constructs are used in a lot of occasions, 
        /// indices etc, and present a standard statistic. 
        /// Several types of correlations can be requested via the function constructCor.
        /// </summary>
        /// <param name="rc"> Use Cohen's rc which is invariant to construct reflection (see desciption above). It is used as the default.</param> 
        /// <param name="method">A character string indicating which correlation coefficient is to be computed. One of "pearson" (default), "kendall" or "spearman", can be abbreviated. The default is "pearson".</param> 
        /// <param name="trim">Numeric. Number of digits to round to (default is 2).</param>
        /// <param name="ShowConstructIndex">Logical. Whether to add an extra index column so the column names are indexes instead of construct names. This option renders a neater output as long construct names will stretch the output (default is TRUE).</param>
        /// </param>
        public RDotNet.NumericMatrix ElementCor(Boolean InitRGrid, Boolean rc = true,
            String method = "pearson", int trim = 20,
            Boolean ShowConstructIndex = false)
        {
            this.SetToR(InitRGrid);
            string cmd = string.Format("ElemCor{0} <- elementCor({0}, rc={4}, method={1}, trim={2}, index={3})",
                this.CurrentInterview.GridName, trim, ShowConstructIndex ? "TRUE" : "FALSE", rc ? "TRUE" : "FALSE");
            this.AppendRScript(cmd);
            return this.R.Evaluate(cmd)[0].AsNumericMatrix();
        }

        /// <summary>
        /// Print method for class elementCor. 
        /// </summary>
        /// <param name="digits">Numeric. Number of digits to round to (default is 2).</param>
        /// <param name="ShowColumnIndex">Logical. Whether to add an extra index column so the column names are indexes instead of construct names. This option renders a neater output as long construct names will stretch the output (default is TRUE).</param>
        /// <param name="toUpper">Whether to display upper triangle of correlation matrix only (default is TRUE).</param>
        /// <param name="PrintHeader">Whether to print additional information in header.</param>
        /// <remarks></remarks>
        public void PrintElementCor(int digits = 2, Boolean ShowColumnIndex = true, Boolean toUpper = true, Boolean PrintHeader = true)
        {
            string cmd = string.Format("print(ElemCor{0}, digits={1}, col.index={2}, upper = {3}, header = {4})",
              this.CurrentInterview.GridName,
              digits,
              ShowColumnIndex ? "TRUE" : "FALSE",
               toUpper ? "TRUE" : "FALSE",
               PrintHeader ? "TRUE" : "FALSE"
              );
            this.AppendRScript(cmd);
            this.R.Evaluate(cmd);
        }

        #region Distances

        /// <summary>
        /// Calculate Slater distance. 
        /// </summary> 

        /// <param name="trim">The number of characters a construct or element is trimmed to (default is 20). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.</param>
        /// <param name="index">Whether to print the number of the construct or element in front of the name (default is TRUE). This is useful to avoid identical row names, which may cause an error.</param>
        /// <returns></returns>
        /// <remarks> The euclidean distance is often used as a measure of similarity between elements 
        /// (see distance. A drawback of this measure is that it depends on the range of the rating scale and the 
        /// number of constructs used, i. e. on the size of a grid.  An approach to standardize the euclidean distance to 
        /// make it independent from size and range of ratings and was proposed by Slater (1977, pp. 94). 
        /// The 'Slater distance' is the Euclidean distance divided by the expected distance. 
        /// Slater distances bigger than 1 are greater than expected, lesser than 1 are smaller than expected. 
        /// The minimum value is 0 and values bigger than 2 are rarely found. Slater distances have been be used to 
        /// compare inter-element distances between different grids, where the grids do not need to have the 
        /// same constructs or elements. 
        /// Hartmann (1992) showed that Slater distance is not independent of grid size. Also the distribution of the Slater distances is asymmetric. Hence, the upper and lower limit to infer 'significance' of distance is not symmetric. The practical relevance of Hartmann's findings have been demonstrated by Schoeneich and Klapp (1998). To calculate Hartmann's version of the standardized distances see distanceHartmann </remarks>
        /// </remarks>
        public NumericMatrix DistanceSlater(int trim = 20, Boolean index = true)
        {
            string cmd = string.Format("distanceSlater({0}, trim = {1}, index = {2})",
                this.CurrentInterview.GridName, trim < 0 ? "NA" : trim.ToString(), index ? "TRUE" : "FALSE");
            this.AppendRScript(cmd);
            return this.R.Evaluate(cmd)[0].AsNumericMatrix();
        }

        /// <summary>
        /// Calculate Hartmann distance
        /// </summary>
        /// <param name="method">The method used for distance calculation, on of "paper", "simulate", "new". "paper" uses the parameters as given in Hartmann (1992) for caclulation. "simulate" (default) simulates a Slater distribution for the caclulation. In a future version the time consuming simulation will be replaced by more accurate parameters for Hartmann distances than used in Hartmann (1992).</param>
        /// <param name="reps">Number of random grids to generate sample distribution for Slater distances (default is 10000). Note that a lot of samples may take a while to calculate.</param>
        /// <param name="progress">Whether to show a progress bar during simulation (default is TRUE) (for method="simulate"). May be useful when the distribution is estimated on the basis of many quasis.</param>
        /// <param name="distributions">Wether to additionally return the values of the simulated distributions (Slater etc.) The default is FALSE as it will quickly boost the object size. </param>
        /// <returns></returns>
        /// <remarks>Hartmann (1992) showed in a simulation study that Slater distances (see distanceSlater) based on random grids, 
        /// for which Slater coined the expression quasis, have a skewed distribution, a mean and a standard deviation depending on 
        /// the number of constructs elicited. He suggested a linear transformation (z-transformation) which takes into account the
        /// estimated (or expected) mean and the standard deviation of the derived distribution to standardize Slater distance scores 
        /// across different grid sizes. 'Hartmann distances' represent a more accurate version of 'Slater distances'. 
        /// Note that Hartmann distances are multiplied by -1. Hence, negative Hartmann values represent dissimilarity, i.e. a big Slater distance. 
        /// 
        /// There are two ways to use this function. Hartmann distances can either be calculated based on the reference values 
        /// (i.e. means and standard deviations of Slater distance distributions) as given by Hartmann in his paper. 
        /// The second option is to conduct an instant simulation for the supplied grid size for each calculation. 
        /// The second option will be more accurate when a big number of quasis is used in the simulation. 
        /// 
        /// It is also possible to return the quantiles of the sample distribution and only the element distances 
        /// consideres 'significant' according to the quantiles defined. </remarks>
        public NumericMatrix DistanceHartmann(string method = "paper", int reps = 10000, Boolean progress = true, Boolean distributions = false)
        {
            throw new NotImplementedException();
        }
        #endregion
        /// <summary>
        /// Calculate power-transformed Hartmann distances. 
        /// </summary>
        /// <param name="reps">Number of random grids to generate to produce sample distribution for Hartmann distances (default is 1000). Note that a lot of samples may take a while to calculate.</param>
        /// <param name="progress"> Whether to show a progress bar during simulation (default is TRUE) (for method="simulate"). May be useful when the distribution is estimated on the basis of many quasis. </param>
        /// <param name="distributions">Wether to additionally return the values of the simulated distributions (Slater etc.) The default is FALSE as it will quickly boost the object size.</param>
        /// <returns>A matrix containing the standardized distances. 
        /// Further data is contained in the object's attributes:
        /// "arguments" 
        /// A list of several parameters including mean and sd of Slater distribution.
        /// 
        /// "quantiles" 
        /// Quantiles for Slater, Hartmann and power transformed distance distribitions.
        /// 
        /// "distributions" 
        /// List with values of the simulated distributions, if distributions=TRUE.
        /// </returns>
        /// <remarks>Hartmann (1992) suggested a transformation of Slater (1977) distances to make them independent from the size of a grid. 
        /// Hartmann distances are supposed to yield stable cutoff values used to determine 'significance' of inter-element distances. 
        /// It can be shown that Hartmann distances are still affected by grid parameters like size and the range of the rating scale used (Heckmann, 2012).
        /// The function distanceNormalize applies a Box-Cox (1964) transformation to the Hartmann distances in order to remove the 
        /// skew of the Hartmann distance distribution. The normalized values show to have more stable cutoffs (quantiles) and better properties
        /// for comparison across grids of different size and scale range. 
        /// 
        /// The function distanceNormalize can also return the quantiles of the sample distribution and only the element distances consideres 
        /// 'significant' according to the quantiles defined. </remarks>
        public NumericMatrix DistanceNormalized(string method = "paper", int reps = 1000, Boolean progress = true, Boolean distributions = false)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region Constructs and Elements

        #region Distances

        /// <summary>
        /// http://docu.openrepgrid.org/constructs_distances.html
        /// Various distance measures between elements or constructs are calculated. 
        /// </summary>
        /// <param name="forConstructs">Whether to calculate distance for 1 = constructs (default) or for 2= elements.</param>
        /// <param name="method">The distance measure to be used. This must be one of "euclidean", "maximum", "manhattan", "canberra", "binary" or "minkowski". Any unambiguous substring can be given. For additional information on the different types type ?dist</param>
        /// <param name="p">The power of the Minkowski distance, in case "minkowski" is used as argument for dmethod.</param>
        /// <param name="trim">The number of characters a construct or element is trimmed to (default is 20). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.</param>
        /// <param name="index">Whether to print the number of the construct or element in front of the name (default is TRUE). This is useful to avoid identical row names, which may cause an error.</param>
        /// <returns></returns>
        private NumericMatrix Distance(Boolean InitRGrid, Boolean forConstructs = true, string method = "euclidean", int p = 2, int trim = 20, Boolean index = true)
        {

            this.SetToR(InitRGrid);
            string cmd = string.Format("distance({0},along = {1}, dmethod = \"{2}\", p = {3}, trim = {4}, index = {5})",
                this.CurrentInterview.GridName,
                forConstructs ? 1 : 2,
                method, p,
                trim < 0 ? "NA" : trim.ToString(),
              index ? "TRUE" : "FALSE");
            this.AppendRScript(cmd);
            return this.R.Evaluate(cmd)[0].AsNumericMatrix();

        }

        #endregion

        #region Cluster

        /// <summary>
        /// cluster is a preliminary implementation of a cluster function. It supports various distance measures as well as cluster methods. More is to come. 
        /// </summary>
        /// <param name="along"> Along which dimension to cluster. 1 = constructs only, 2= elements only, 0=both (default). </param>
        /// <param name="dmethod">The distance measure to be used. This must be one of "euclidean", "maximum", "manhattan", "canberra", "binary" or "minkowski". Any unambiguous substring can be given. For additional information on the different types type ?dist.</param>
        /// <param name="cmethod">The agglomeration method to be used. This should be (an unambiguous abbreviation of) one of "ward", "single", "complete", "average", "mcquitty", "median" or "centroid".</param>
        /// <param name="p">The power of the Minkowski distance, in case "minkowski" is used as argument for dmethod.</param>
        /// <param name="align">Whether the constructs should be aligned before clustering (default is TRUE). If not, the grid matrix is clustered as is. See Details section for more information.</param>
        /// <param name="trim"> the number of characters a construct is trimmed to (default is 10). If NA no trimming is done. Trimming simply saves space when displaying the output.</param>
        /// <param name="main">Title of plot. The default is a name indicating the distance function and cluster method.</param>
        /// <param name="cex"> Size parameter for the nodes. Usually not needed. </param>
        /// <param name="cexlab">Size parameter for the constructs on the right side.</param>
        /// <param name="cexmain">Size parameter for the plot title (default is .9).</param>
        /// <param name="print">Logical. Wether to print the dendrogram (default is TRUE).</param>
        /// <param name="t">Logical. Wether to print the dendrogram in a different style.</param>
        public void cluster(
            int along = 0,
            string dmethod = "euclidean",
            string cmethod = "ward",
            int p = 2,
            Boolean align = true,
            int trim = 10,
            string main = "",
            double cex = 0d,
            double cexlab = 0.8,
            double cexmain = 0.9,
            Boolean print = true,
            Boolean t = false)
        {
            string cmd = string.Format("{0}<-cluster({0}, along = {1}, dmethod = \"{2}\", cmethod = \"{3}\", p = {4}, align = {5}, trim = {6}, main = {7}, cex = {8}, lab.cex = {9}, cex.main = {10}, print = {11} {12})",
                this.CurrentInterview.GridName, along, dmethod, cmethod, p, align ? "TRUE" : "FALSE",
                trim < 0 ? "NA" : trim.ToString(), main.Length == 0 ? "NULL" : main,
                cex.ToString().Replace(",", "."), cexlab.ToString().Replace(",", "."),
                cexmain.ToString().Replace(",", "."), print ? "TRUE" : "FALSE", t ? ", t = \"{12}\"" : "");
            this.AppendRScript(cmd);
            this.R.Evaluate(cmd);

            this.GetFromR( false);


        }
        #endregion
      
        #endregion

        #region Visualisation

        public void bertin(Boolean toFile = false,
            List<string> colors = null,
            Boolean showvalues = true,
            Boolean IndexColumns = true,
            Boolean IndexElements = true,
            double[] xlim = null,
            double[] ylim = null,
            double[] margins = null,
            double cexElements = 0.7,
            double cexConstructs = 0.7,
            double cexText = 0.7,
            string colText = "NA",
            string border = "white",
            double lheight = 0.75,
            Boolean print = true)
        {
            throw new NotImplementedException();
        }

        public void bertinCluster(Boolean toFile = false,
            string dmethod = "euclidean",
            string cmethod = "ward",
            int[] p = null,
            Boolean align = true,
            int trim = -1,
            string type = "triangle",
            double xoff = 0.01,
            double yoff = 0.01,
            double cexaxis = 0.6,
            string colaxis = "grey(0.4)",
            Boolean drawAxis = true,
            List<string> colors = null,
            Boolean showvalues = true,
            Boolean IndexColumns = true,
            Boolean IndexElements = true,
            double[] xlim = null,
            double[] ylim = null,
            double[] margins = null,
            double cexElements = 0.7,
            double cexConstructs = 0.7,
            double cexText = 0.7,
            string colText = "NA",
            string border = "white",
            double lheight = 0.75,
            Boolean print = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// biplotSimple(x, dim = 1:2, center = 1, normalize = 0, g = 0, h = 1 -
        ///     g, unity = T, col.active = NA, col.passive = NA, scale.e = 0.9,
        ///     zoom = 1, e.point.col = "black", e.point.cex = 1,
        ///     e.label.col = "black", e.label.cex = 0.7, c.point.col = grey(0.6),
        ///     c.label.col = grey(0.6), c.label.cex = 0.6, ...) 
        /// </summary>
        public void BiPlotSimple()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// biplot2d(x, dim = c(1, 2), map.dim = 3, center = 1, normalize = 0,
        ///     g = 0, h = 1 - g, col.active = NA, col.passive = NA,
        ///     e.point.col = "black", e.point.cex = 0.9, e.label.col = "black",
        ///     e.label.cex = 0.7, e.color.map = c(0.4, 1), c.point.col = "black",
        ///     c.point.cex = 0.8, c.label.col = "black", c.label.cex = 0.7,
        ///     c.color.map = c(0.4, 1), c.points.devangle = 91, c.labels.devangle = 91,
        ///     c.points.show = TRUE, c.labels.show = TRUE, e.points.show = TRUE,
        ///     e.labels.show = TRUE, inner.positioning = TRUE,
        ///     outer.positioning = TRUE, c.labels.inside = FALSE, c.lines = TRUE,
        ///     col.c.lines = grey(0.9), flipaxes = c(FALSE, FALSE), strokes.x = 0.1,
        ///     strokes.y = 0.1, offsetting = TRUE, offset.labels = 0, offset.e = 1,
        ///     axis.ext = 0.1, mai = c(0.2, 1.5, 0.2, 1.5), rect.margins = c(0.01,
        ///     0.01), srt = 45, cex.pos = 0.7, xpd = TRUE, unity = FALSE,
        ///     unity3d = FALSE, scale.e = 0.9, zoom = 1, var.show = TRUE,
        ///     var.cex = 0.7, var.col = grey(0.1), ...)
        /// </summary>
        public void BiPlot2d()
        {
            throw new NotImplementedException();
        }

        public void BiPlotPseudo3d()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// biplot3d(x, dim = 1:3, labels.e = TRUE, labels.c = TRUE, lines.c = TRUE,
        ///    lef = 1.3, center = 1, normalize = 0, g = 0, h = 1,
        ///    col.active = NA, col.passive = NA, c.sphere.col = grey(0.4),
        ///    c.cex = 0.6, c.text.col = grey(0.4), e.sphere.col = grey(0),
        ///    e.cex = 0.6, e.text.col = grey(0), alpha.sphere = 0.05,
        ///    col.sphere = "black", unity = FALSE, unity3d = FALSE, scale.e = 0.9,
        ///    zoom = 1, ...) 
        /// </summary>
        public void BiPlot3d()
        {
            throw new NotImplementedException();
        }

        #endregion


        #endregion
         
        #region Eventhandler

        void elem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void con_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        void s_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // throw new NotImplementedException();
        }


        #endregion

    }
}
