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
using RHelper.model;
using System.Drawing;

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

        public static Dictionary<String, Boolean> DistanceHartmannMethods()
        {

            Dictionary<String, Boolean> d = new Dictionary<string, bool>();
            d.Add("paper", true);
            d.Add("new", false);
            d.Add("simulate", false);
            return d;

        }
        public static Dictionary<String, Boolean> SomerDMethods()
        {

            Dictionary<String, Boolean> d = new Dictionary<string, bool>();
            d.Add("columns", true);
            d.Add("rows", false);
            d.Add("symmetric", false);
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

        public void GetFromR(Boolean DefineScale)
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
            List<Element> elements = new List<Element>();
            List<Construct> constructs = new List<Construct>();
            for (int i = 0; i < I; i++)
            {
                Element element;
                GenericVector rElement = rElements.ToList()[i].AsList();
                string eName = rElement.ToList()[0].AsCharacter().ToArray()[0];
                if (this.CurrentInterview.Elements.Any(x => x.Name == eName))
                {
                    element = this.CurrentInterview.Elements.First(x => x.Name == eName);
                }
                else
                {
                    element = new Element(this.CurrentInterview);
                    element.Name = eName;
                }
                elements.Add(element);

                for (int j = 0; j < J; j++)
                {
                    Construct construct;
                    if (i == 0)
                    {
                        GenericVector rConstruct = rConstructs.ToList()[j].AsList();
                        String lPole = rConstruct.ToList()[0].AsCharacter().ToArray()[0].Trim();
                        String rPole = rConstruct.ToList()[1].AsCharacter().ToArray()[0].Trim();

                        if (this.CurrentInterview.Constructs.Any(x => (x.ContrastPol == lPole && x.ConstructPol == rPole) ||
                                                                    (x.ContrastPol == rPole && x.ConstructPol == lPole)))
                        {
                            construct = this.CurrentInterview.Constructs.First(x => (x.ContrastPol == lPole && x.ConstructPol == rPole) ||
                                                                    (x.ContrastPol == rPole && x.ConstructPol == lPole));
                        }
                        else
                        {
                            construct = new Construct(this.CurrentInterview);
                            construct.ContrastPol = lPole;
                            construct.ConstructPol = rPole;
                        }
                        constructs.Add(construct);
                    }
                    else
                    {
                        construct = constructs[j];
                    }
                    int score = R.getInt(
                        string.Format("{0}@ratings[{1}]",
                            this.CurrentInterview.GridName,
                            ((i) * J + (j + 1))));
                    this.GiveRating(element, construct, score);
                }
            }
            this.CurrentInterview.Elements = elements;
            this.CurrentInterview.Constructs = constructs;
            this.FirePropertyChanged("CurrentInterview");

        }

        public void SetToR(Boolean PrintToConsole, String newGridName = "")
        {
            StringBuilder str = new StringBuilder();
            StringBuilder strElement = new StringBuilder();
            StringBuilder strConstructLPole = new StringBuilder();
            StringBuilder strConstructRPole = new StringBuilder();
            StringBuilder strScores = new StringBuilder();
            List<String> constructNames = new List<string>();
            List<String> ElementNames = new List<string>();
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
                construct.ContrastPol = construct.ContrastPol.Trim();
                construct.ConstructPol = construct.ConstructPol.Trim();

                string cName = String.Format("{0}/{1}", construct.ContrastPol.Trim(), construct.ConstructPol.Trim());
                if (constructNames.Any(x=> x.ToUpper() == cName.ToUpper()))
                {
                    throw new DuplicateWaitObjectException(
                        string.Format("The Pair ('{0}') of Contrast and Construct for construct '{1}' is not unique! Please make sure, that only unique pairs exists!", cName, construct.Name));
                }
                constructNames.Add(cName);
                strConstructLPole.Append(string.Format("\"{0}\"", construct.ContrastPol.Trim()));
                strConstructRPole.Append(string.Format("\"{0}\"", construct.ConstructPol.Trim()));
                if (i < this.CurrentInterview.Constructs.Count - 1)
                {
                    strConstructLPole.Append(",");
                    strConstructRPole.Append(",");
                }
                strScores.Append("\n\t\t\t");

                for (int j = 0; j < this.CurrentInterview.Elements.Count; j++)
                {
                    Element element = this.CurrentInterview.Elements[j];
                    element.Name = element.Name.Trim();
                    if (i == 0)
                    {
                        strElement.Append(string.Format("\"{0}\"", element.Name.Trim()));
                        if (j < this.CurrentInterview.Elements.Count - 1)
                        {
                            strElement.Append(",");
                        }
                        string eName =  element.Name.Trim();
                        if (ElementNames.Any(x => x.ToUpper() == eName.ToUpper()))
                        {
                            throw new DuplicateWaitObjectException(string.Format("The Element ('{0}') is not unique! Please make sure, that only unique elements exists!", eName));
                        }
                        ElementNames.Add(eName);
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
            if (this.CurrentInterview.Scales.Any() == false) this.defineDefaultScale(); 
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
             
            this.CurrentInterview.Constructs.Remove(c);
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
            if (this.CurrentInterview.Scales.Any() == false) this.defineDefaultScale();
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

        private String getOptionalValues(Dictionary<String, Object> optionalValues, List<rParameter> acceptedValues)
        {
            StringBuilder cmd = new StringBuilder();
            if (optionalValues != null)
            {
                foreach (string key in optionalValues.Keys)
                {
                    if (acceptedValues.Any(x => x.VarName == key))
                    {
                        rParameter param = acceptedValues.Single(x => x.VarName == key);
                        Type valueType = optionalValues[key].GetType();

                        if (param.VariableType == typeof(Color))
                        {
                            String[] a;
                            if (valueType.IsArray)
                            {
                                a = (String[])optionalValues[key];
                            }
                            else
                            {
                                a = new string[] { (string)optionalValues[key] };
                            }

                            if (a.Length > 0)
                            {
                                cmd.Append("c(");
                                for (int i = 0; i < a.Length; i++)
                                {
                                    if (i > 0) cmd.Append(",");
                                    cmd.Append("\"");
                                    cmd.Append(a[i]);
                                    cmd.Append("\"");
                                }
                                cmd.Append(")");

                            }
                        }
                        else if (valueType == param.VariableType || param.VariableType == typeof(Dictionary<String, Boolean>))
                        {
                            cmd.Append(", ");
                            cmd.Append(key);
                            cmd.Append("=");

                            if (optionalValues[key].GetType() == typeof(string))
                            {
                                String[] a;
                                if (valueType.IsArray)
                                {
                                    a = (String[])optionalValues[key];
                                }
                                else
                                {
                                    a = new string[] { (string)optionalValues[key] };
                                }

                                if (a.Length > 0)
                                {
                                    cmd.Append("c(");
                                    for (int i = 0; i < a.Length; i++)
                                    {
                                        if (i > 0) cmd.Append(",");
                                        cmd.Append("\"");
                                        cmd.Append(a[i]);
                                        cmd.Append("\"");
                                    }
                                    cmd.Append(")");

                                }
                            }
                        }
                        else if (valueType == typeof(Boolean))
                        {
                            Boolean[] a;

                            if (valueType.IsArray)
                            {
                                a = (Boolean[])optionalValues[key];
                            }
                            else
                            {
                                a = new Boolean[] { (Boolean)optionalValues[key] };
                            }

                            if (a.Length > 0)
                            {
                                cmd.Append("c(");
                                for (int i = 0; i < a.Length; i++)
                                {
                                    if (i > 0) cmd.Append(",");
                                    if (a[i])
                                    {
                                        cmd.Append("TRUE");
                                    }
                                    else
                                    {
                                        cmd.Append("FALSE");
                                    }
                                }
                                cmd.Append(")");

                            }
                        }
                        else if (valueType == typeof(int))
                        {
                            int[] a;

                            if (valueType.IsArray)
                            {
                                a = (int[])optionalValues[key];
                            }
                            else
                            {
                                a = new int[] { (int)optionalValues[key] };
                            }

                            if (a.Length > 0)
                            {
                                cmd.Append("c(");
                                for (int i = 0; i < a.Length; i++)
                                {
                                    if (i > 0) cmd.Append(",");
                                    cmd.Append(a[i].ToString());
                                }
                                cmd.Append(")");

                            }
                        }
                        else if (valueType == typeof(Double))
                        {

                            Double[] a;

                            if (valueType.IsArray)
                            {
                                a = (Double[])optionalValues[key];
                            }
                            else
                            {
                                a = new Double[] { (Double)optionalValues[key] };
                            }

                            if (a.Length > 0)
                            {
                                cmd.Append("c(");
                                for (int i = 0; i < a.Length; i++)
                                {
                                    if (i > 0) cmd.Append(",");
                                    cmd.Append(a[i].ToString().Replace(",", "."));
                                }
                                cmd.Append(")");

                            }
                        } 
                    }
                    else if (key == "custom")
                    {
                        cmd.Append(optionalValues[key]);
                    }else
                    {
                        throw new ArgumentException(string.Format("The optional Argument '{0}' is not supported", key));
                    }
                }
            }
            return cmd.ToString();
        }

        #region Accepted Parameter for functions

        public static List<rParameter> StatsGridAcceptedValues()
        {
            List<rParameter> acceptedValues = new List<rParameter>();
            acceptedValues.Add(new rParameter(true, "trim", "The number of characters a construct or element is trimmed to (default is 20). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.", new int[] { 0, int.MaxValue }, typeof(int), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "index", "Whether to print the number of the construct or element in front of the name (default is TRUE). This is useful to avoid identical row names, which may cause an error.", null, typeof(Boolean), 1, 1, 1));

            return acceptedValues;
        }


        public static List<rParameter> CorrelationAcceptedValues()
        {
            List<rParameter> acceptedValues = new List<rParameter>();
            acceptedValues.Add(new rParameter(true, "method", "A character string indicating which correlation coefficient to be computed. One of \"pearson\" (default), \"kendall\" or \"spearman\", can be abbreviated. The default is \"pearson\".", InterviewService.CorrelationTypes(), typeof(Dictionary<String, Boolean>), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "rc", "Use Cohen's rc which is invariant to construct reflection (see desciption above). It is used as the default.", null, typeof(Boolean), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "trim", "The number of characters a construct or element is trimmed to (default is 20). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.", new int[] { 0, int.MaxValue }, typeof(int), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "index", "Whether to print the number of the construct or element in front of the name (default is TRUE). This is useful to avoid identical row names, which may cause an error.", null, typeof(Boolean), 1, 1, 1));

            return acceptedValues;
        }
        public static List<rParameter> CorrelationRMSAcceptedValues()
        {
            List<rParameter> acceptedValues = new List<rParameter>();
            acceptedValues.Add(new rParameter(true, "method", "A character string indicating which correlation coefficient to be computed. One of \"pearson\" (default), \"kendall\" or \"spearman\", can be abbreviated. The default is \"pearson\".", InterviewService.CorrelationTypes(), typeof(Dictionary<String, Boolean>), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "rc", "Use Cohen's rc which is invariant to construct reflection (see desciption above). It is used as the default.", null, typeof(Boolean), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "trim", "The number of characters a construct or element is trimmed to (default is 20). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.", new int[] { 0, int.MaxValue }, typeof(int), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "index", "Whether to print the number of the construct or element in front of the name (default is TRUE). This is useful to avoid identical row names, which may cause an error.", null, typeof(Boolean), 1, 1, 1));

            return acceptedValues;
        }
        public static List<rParameter> DistanceAcceptedValues()
        {
            List<rParameter> acceptedValues = new List<rParameter>();
            acceptedValues.Add(new rParameter(true, "dmethod", "The distance measure to be used. This must be one of \"euclidean\", \"maximum\", \"manhattan\", \"canberra\", \"binary\" or \"minkowski\". Any unambiguous substring can be given. For additional information on the different types type ?dist.", InterviewService.DistanceMeasures(), typeof(Dictionary<String, Boolean>), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "p", "The power of the Minkowski distance, in case \"minkowski\" is used as argument for dmethod", new int[] { 1, 10 }, typeof(int), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "trim", "The number of characters a construct or element is trimmed to (default is 20). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.", new int[] { 0, int.MaxValue }, typeof(int), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "index", "Whether to print the number of the construct or element in front of the name (default is TRUE). This is useful to avoid identical row names, which may cause an error.", null, typeof(Boolean), 1, 1, 1));

            return acceptedValues;
        }
        public static List<rParameter> DistanceSlaterAcceptedValues()
        {
            List<rParameter> acceptedValues = new List<rParameter>();
            acceptedValues.Add(new rParameter(true, "trim", "The number of characters a construct or element is trimmed to (default is 20). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.", new int[] { 0, int.MaxValue }, typeof(int), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "index", "Whether to print the number of the construct or element in front of the name (default is TRUE). This is useful to avoid identical row names, which may cause an error.", null, typeof(Boolean), 1, 1, 1));

            return acceptedValues;
        }
        public static List<rParameter> DistanceHartmannAcceptedValues()
        {
            List<rParameter> acceptedValues = new List<rParameter>();
            acceptedValues.Add(new rParameter(true, "method", "Use 'paper' (default) for precalculated mean and standard deviations (as e.g. given in Hartmann (1992)) for the standardization;\n use 'simulate' to simulate the distribution of distances based on the size and scale range of the grid under investigation.", InterviewService.DistanceHartmannMethods(), typeof(Dictionary<String, Boolean>), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "reps", "Number of random grids to generate to produce sample distribution for Hartmann distances (default is 1000). Note that a lot of samples may take a while to calculate.", new int[] { 1, int.MaxValue }, typeof(int), 1, 1, 1));

            return acceptedValues;
        }
        public static List<rParameter> DistanceNormalizedAcceptedValues()
        {
            List<rParameter> acceptedValues = new List<rParameter>();
            acceptedValues.Add(new rParameter(true, "reps", "Number of random grids to generate to produce sample distribution for Hartmann distances (default is 1000). Note that a lot of samples may take a while to calculate.", new int[] { 1, int.MaxValue }, typeof(int), 1, 1, 1));
            // acceptedValues.Add(new rParameter(true, "prob", "The probability of each rating value to occur. If NULL (default) the distribution is uniform. The number of values must match the length of the rating scale.", InterviewService.DistanceHartmannMethods(), typeof(Dictionary<String, Boolean>)));

            return acceptedValues;
        }
        public static List<rParameter> SomerDAcceptedValues()
        {
            List<rParameter> acceptedValues = new List<rParameter>();
            acceptedValues.Add(new rParameter(true, "dependent", "A string denoting the direction of dependency in the output table (as d is assymetrical). Possible values are \"columns\" (the default) for setting the columns as dependent, \"rows\" for setting the rows as the dependent variable and \"symmetric\" for the symmetrical Somers' d measure (the mean of the two directional values for code\"columns\" and \"rows\").", InterviewService.SomerDMethods(), typeof(Dictionary<String, Boolean>), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "trim", "The number of characters a construct or element is trimmed to (default is 20). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.", new int[] { 0, int.MaxValue }, typeof(int), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "index", "Whether to print the number of the construct or element in front of the name (default is TRUE). This is useful to avoid identical row names, which may cause an error.", null, typeof(Boolean), 1, 1, 1));

            return acceptedValues;
        }

        public static List<rParameter> PCAAcceptedValues()
        {
            List<rParameter> acceptedValues = new List<rParameter>();
            acceptedValues.Add(new rParameter(true, "nfactors", "Number of components to extract (default is 3).", new int[] { 0, int.MaxValue }, typeof(int), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "rotate", "\"none\", \"varimax\", \"promax\" and \"cluster\" are possible rotations (default is none).", InterviewService.RotationMethods(), typeof(Dictionary<String, Boolean>), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "method", "A character string indicating which correlation coefficient to be computed. One of \"pearson\" (default), \"kendall\" or \"spearman\", can be abbreviated. The default is \"pearson\".", InterviewService.CorrelationTypes(), typeof(Dictionary<String, Boolean>), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "trim", "The number of characters a construct or element is trimmed to (default is 20). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.", new int[] { 0, int.MaxValue }, typeof(int), 1, 1, 1));

            return acceptedValues;
        }

        public static List<rParameter> ClusterAcceptedValues()
        {
            List<rParameter> acceptedValues = new List<rParameter>();
            acceptedValues.Add(new rParameter(true, "along", "Along which dimension to cluster. 1 = constructs only, 2= elements only, 0=both (default).", new int[] { 0, 2 }, typeof(int), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "dmethod", "The distance measure to be used. This must be one of \"euclidean\", \"maximum\", \"manhattan\", \"canberra\", \"binary\" or \"minkowski\". Any unambiguous substring can be given. For additional information on the different types type ?dist.", InterviewService.DistanceMeasures(), typeof(Dictionary<String, Boolean>), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "cmethod", "The agglomeration method to be used. This should be (an unambiguous abbreviation of) one of \"ward\", \"single\", \"complete\", \"average\", \"mcquitty\", \"median\" or \"centroid\".", InterviewService.ClusterMethods(), typeof(Dictionary<String, Boolean>), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "p", "The power of the Minkowski distance, in case \"minkowski\" is used as argument for dmethod", new int[] { 1, 10 }, typeof(int), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "align", "Whether the constructs should be aligned before clustering (default is TRUE). If not, the grid matrix is clustered as is. See Details section for more information.", null, typeof(Boolean), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "trim", "The number of characters a construct or element is trimmed to (default is 20). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.", new int[] { 0, int.MaxValue }, typeof(int), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "main", "Title of plot. The default is a name indicating the distance function and cluster method.", null, typeof(string), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "print", "Logical. Wether to print the dendrogram (default is TRUE).", null, typeof(Boolean), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "mar", "Define the plot region (bottom, left, upper, right).", null, typeof(double), 4, 4, 4));
            acceptedValues.Add(new rParameter(true, "cex", "Size parameter for the nodes. Usually not needed.", null, typeof(double), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "lab.cex", "Size parameter for the constructs on the right side.", new double[] { 0.1, 3.9 }, typeof(double), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "cex.main", "Size parameter for the plot title (default is .9).", new double[] { 0.1, 3.9 }, typeof(double), 1, 1, 1));
            // 

            return acceptedValues;
        }
        
        public static List<rParameter> BertinClusterAcceptedValues()
        {
            List<rParameter> acceptedValues = new List<rParameter>();
             acceptedValues.Add(new rParameter(true, "dmethod", "The distance measure to be used. This must be one of \"euclidean\", \"maximum\", \"manhattan\", \"canberra\", \"binary\" or \"minkowski\". Any unambiguous substring can be given. For additional information on the different types type ?dist.", InterviewService.DistanceMeasures(), typeof(Dictionary<String, Boolean>), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "cmethod", "The agglomeration method to be used. This should be (an unambiguous abbreviation of) one of \"ward\", \"single\", \"complete\", \"average\", \"mcquitty\", \"median\" or \"centroid\".", InterviewService.ClusterMethods(), typeof(Dictionary<String, Boolean>), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "p", "The power of the Minkowski distance, in case \"minkowski\" is used as argument for dmethod", new int[] { 1, 10 }, typeof(int), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "align", "Whether the constructs should be aligned before clustering (default is TRUE). If not, the grid matrix is clustered as is. See Details section for more information.", null, typeof(Boolean), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "trim", "The number of characters a construct or element is trimmed to (default is 20). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.", new int[] { 0, int.MaxValue }, typeof(int), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "type", "Type of dendrogram. Either or \"triangle\" (default) or \"rectangle\" form.", InterviewService.DendrogramType (), typeof(Dictionary<String, Boolean>), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "cex.axis", "cex for axis labels, default is .6", new double[] { 0.1, 3.9 }, typeof(double), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "col.axis", "Color for axis and axis labels, default is grey(.4).", null, typeof(Color), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "draw.axis", "Whether to draw axis showing the distance metric for the dendrograms (default is TRUE).", null, typeof(Boolean), 1, 1, 1));
            // 
            acceptedValues.AddRange(InterviewService.BertinAcceptedValues());
            return acceptedValues;
        }
        public static List<rParameter> BertinAcceptedValues()
        {
            List<rParameter> acceptedValues = new List<rParameter>();
            acceptedValues.Add(new rParameter(true, "colors", "Vector. Two or more colors defininig the color ramp for the bertin (default c(\"white\", \"black\")).", null, typeof(Color), 2, 2, 2));
            acceptedValues.Add(new rParameter(true, "showvalues", "Logical. Wether scores are shown in bertin", null, typeof(Boolean), 1, 1, 1));

            acceptedValues.Add(new rParameter(true, "cex.elements", "Numeric. Text size of element labels (default .7).", new double[]{0.1,3.9}, typeof(double), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "cex.constructs", "Numeric. Text size of construct labels (default .7).", new double[] { 0.1, 3.9 }, typeof(double), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "cex.text", "Numeric. Text size of scores in bertin cells (default .7).", new double[] { 0.1, 3.9 }, typeof(double), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "col.text", "Color of scores in bertin (default NA). By default the color of the text is chosen according to the background color. If the background ist bright the text will be black and vice versa. When a color is specified the color is set independetn of background.", null, typeof(Color), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "border", "Border color of the bertin cells (default white).", null, typeof(Color), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "lheight", "Line height for constructs.", null, typeof(double), 1, 1, 1));
            acceptedValues.Add(new rParameter(true, "id", "Logical. Wheteher to print id number for constructs and elements respectively (default c(T,T)).", null, typeof(Boolean), 2, 2, 2));
             

            return acceptedValues;
        }/*
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
            Boolean print = true)*/
        #endregion

        #region Description

        /// <summary>
        /// Calculates the descriptive Stats Mentioned in http://docu.openrepgrid.org/constructs_descriptives.html
        /// </summary>
        /// <param name="Elements">if true, use statsElements, if false, use statsConstructs</param>
        /// <param name="InitGrid">if true, write Grid to R before evaluation. if false, use the one currently in R</param>
        /// <param name="optionalValues">Dictionary of optional Values</param>
        /// <returns></returns>
        public DataFrame StatsGrid(Boolean elements, Dictionary<String, Object> optionalValues = null)
        {
            this.SetToR(false); // write CurrentGrid to R. 
            StringBuilder cmd = new StringBuilder();

            if (elements)
            {
                cmd.Append("statsElements");
            }
            else
            {
                cmd.Append("statsConstructs");
            }
            cmd.Append("(");
            cmd.Append(this.CurrentInterview.GridName);
            cmd.Append(getOptionalValues(optionalValues, InterviewService.StatsGridAcceptedValues()));
            cmd.Append(")");
            DataFrame dt = this.R.Evaluate(cmd.ToString())[0].AsDataFrame();
            this.AppendRScript(cmd.ToString());
            return dt;
        }

        /// <summary>
        /// As a measure for element similarity correlations between elements are frequently used.
        /// Note that product moment correlations as a measure of similarity are flawed as they 
        /// are not invariant to construct reflection (Bell, 2010; Mackay, 1992). 
        /// 
        /// A correlation index invariant to construct reflection is Cohen’s rc measure (1969), 
        /// which can be calculated using the argument rc=TRUE which is the default option.
        /// http://docu.openrepgrid.org/elements_correlation.html
        /// </summary>
        /// <param name="Elements">if true, use statsElements, if false, use statsConstructs</param>
        /// <param name="InitGrid">if true, write Grid to R before evaluation. if false, use the one currently in R</param>
        /// <param name="optionalValues">Dictionary of optional Values</param>
        /// <returns></returns>
        public NumericMatrix Correlation(Boolean elements, Dictionary<String, Object> optionalValues = null)
        {
            this.SetToR(false); // write CurrentGrid to R. 
            StringBuilder cmd = new StringBuilder();

            if (elements)
            {
                cmd.Append("elementCor");
            }
            else
            {
                cmd.Append("constructCor");
            }
            cmd.Append("(");
            cmd.Append(this.CurrentInterview.GridName);
            cmd.Append(getOptionalValues(optionalValues, InterviewService.CorrelationAcceptedValues()));
            cmd.Append(")");
            NumericMatrix dt = this.R.Evaluate(cmd.ToString())[0].AsNumericMatrix();
            this.AppendRScript(cmd.ToString());
            return dt;
        }

        /// <summary>
        /// Root mean square correlation
        /// To calulate the RMS correlation
        /// 
        /// As a measure for element similarity correlations between elements are frequently used.
        /// Note that product moment correlations as a measure of similarity are flawed as they 
        /// are not invariant to construct reflection (Bell, 2010; Mackay, 1992). 
        /// 
        /// A correlation index invariant to construct reflection is Cohen’s rc measure (1969), 
        /// which can be calculated using the argument rc=TRUE which is the default option.
        /// http://docu.openrepgrid.org/elements_correlation.html
        /// </summary>
        /// <param name="Elements">if true, use statsElements, if false, use statsConstructs</param>
        /// <param name="InitGrid">if true, write Grid to R before evaluation. if false, use the one currently in R</param>
        /// <param name="optionalValues">Dictionary of optional Values</param>
        /// <returns></returns>
        public DataFrame CorrelationRMS(Boolean elements, Dictionary<String, Object> optionalValues = null)
        {
            this.SetToR(false); // write CurrentGrid to R. 
            StringBuilder cmd = new StringBuilder();

            if (elements)
            {
                cmd.Append("elementRmsCor");
            }
            else
            {
                cmd.Append("constructRmsCor");
            }
            cmd.Append("(");
            cmd.Append(this.CurrentInterview.GridName);
            cmd.Append(getOptionalValues(optionalValues, InterviewService.CorrelationRMSAcceptedValues()));
            cmd.Append(")");
            DataFrame dt = this.R.Evaluate(cmd.ToString())[0].AsDataFrame();
            this.AppendRScript(cmd.ToString());
            return dt;
        }

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
        public NumericMatrix Distance(Boolean elements, Dictionary<String, Object> optionalValues = null)
        {
            this.SetToR(false); // write CurrentGrid to R. 
            StringBuilder cmd = new StringBuilder();

            cmd.Append("distance(");
            cmd.Append(this.CurrentInterview.GridName);
            cmd.Append(", along = ");
            if (elements)
            {
                cmd.Append(2);
            }
            else
            {
                cmd.Append(1);
            }
            cmd.Append(getOptionalValues(optionalValues, InterviewService.DistanceAcceptedValues()));
            cmd.Append(")");

            NumericMatrix dt = this.R.Evaluate(cmd.ToString())[0].AsNumericMatrix();
            this.AppendRScript(cmd.ToString());
            return dt;


        }

        #region Standardized Distances for Elements

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
        public NumericMatrix DistanceSlater(Dictionary<String, Object> optionalValues = null)
        {
            this.SetToR(false); // write CurrentGrid to R. 
            StringBuilder cmd = new StringBuilder();

            cmd.Append("distanceSlater(");
            cmd.Append(this.CurrentInterview.GridName);
            cmd.Append(getOptionalValues(optionalValues, InterviewService.DistanceSlaterAcceptedValues()));
            cmd.Append(")");
            this.AppendRScript(cmd.ToString());
            NumericMatrix dt = this.R.Evaluate(cmd.ToString())[0].AsNumericMatrix();
            return dt;
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
        public NumericMatrix DistanceHartmann(Dictionary<String, Object> optionalValues = null, Boolean progress = true, Boolean distributions = false)
        {
            this.SetToR(false); // write CurrentGrid to R. 
            StringBuilder cmd = new StringBuilder();

            cmd.Append("distanceHartmann(");
            cmd.Append(this.CurrentInterview.GridName);
            cmd.Append(getOptionalValues(optionalValues, InterviewService.DistanceHartmannAcceptedValues()));
            cmd.Append(")");
            this.AppendRScript(cmd.ToString());
            NumericMatrix dt = this.R.Evaluate(cmd.ToString())[0].AsNumericMatrix();
            return dt;
        }

        /// <summary>
        /// Calculate power-transformed Hartmann distances. 
        /// </summary>
        /// <param name="optionalValues"></param> 
        /// <returns></returns>
        /// <remarks>
        /// Hartmann (1992) suggested a transformation of Slater (1977) distances to make them 
        /// independent from the size of a grid. Hartmann distances are supposed to yield stable 
        /// cutoff values used to determine 'significance' of inter-element distances. It can be 
        /// shown that Hartmann distances are still affected by grid parameters like size and the 
        /// range of the rating scale used (Heckmann, 2012). The function distanceNormalize applies 
        /// a Box-Cox (1964) transformation to the Hartmann distances in order to remove the skew 
        /// of the Hartmann distance distribution. The normalized values show to have more stable 
        /// cutoffs (quantiles) and better properties for comparison across grids of different size 
        /// and scale range. 
        /// The function distanceNormalize can also return the quantiles of the sample distribution 
        /// and only the element distances consideres 'significant' according to the quantiles defined
        /// </remarks>
        public NumericMatrix DistanceNormalized(Dictionary<String, Object> optionalValues = null)
        {
            this.SetToR(false); // write CurrentGrid to R. 
            StringBuilder cmd = new StringBuilder();

            cmd.Append("distanceNormalized(");
            cmd.Append(this.CurrentInterview.GridName);
            cmd.Append(getOptionalValues(optionalValues, InterviewService.DistanceHartmannAcceptedValues()));
            cmd.Append(")");
            this.AppendRScript(cmd.ToString());
            NumericMatrix dt = this.R.Evaluate(cmd.ToString())[0].AsNumericMatrix();
            return dt;
        }

        #endregion


        #endregion

        #endregion

        #region Constructs

        #region Correlations


        /// <summary>
        /// Somer's d is an assymetric association measure as it depends on which variable is set as dependent and independent. The direction of dependency needs to be specified. 
        /// </summary>
        /// <param name="dependent"> A string denoting the direction of dependency in the output table (as d is assymetrical). Possible values are "columns" (the default) for setting the columns as dependent, "rows" for setting the rows as the dependent variable and "symmetric" for the symmetrical Somers' d measure (the mean of the two directional values for code"columns" and "rows").</param>
        /// <param name="trim"> The number of characters a construct is trimmed to (default is 30). If NA no trimming occurs. Trimming simply saves space when displaying correlation of constructs with long names.</param>
        /// <param name="ShowConstructIndex">Whether to print the number of the construct (default is TRUE).</param>
        /// <returns></returns>
        public RDotNet.NumericMatrix ConstructD(Dictionary<String, Object> optionalValues = null)
        {
            this.SetToR(false);
            StringBuilder cmd = new StringBuilder();

            cmd.Append("constructD(");
            cmd.Append(this.CurrentInterview.GridName);
            cmd.Append(getOptionalValues(optionalValues, InterviewService.SomerDAcceptedValues()));
            cmd.Append(")");
            this.AppendRScript(cmd.ToString());
            NumericMatrix dt = this.R.Evaluate(cmd.ToString())[0].AsNumericMatrix();
            return dt;

        }

        #endregion

        #region PCA

        /// <summary>
        /// Principal components analysis (PCA)
        /// Does an eigen value decomposition and returns eigen values, loadings, and degree of fit for a specified number of components. Basically it is just doing a principal components analysis (PCA) for n principal components of either a correlation or covariance matrix. Can show the residual correlations as well. The quality of reduction in the squared correlations is reported by comparing residual correlations to original correlations. Unlike princomp, this returns a subset of just the best nfactors. The eigen vectors are rescaled by the sqrt of the eigen values to produce the component loadings more typical in factor analysis. 
        /// Various methods for rotation and methods for the calculation of the correlations are available. Note that the number of factors has to be specified. For more information on the PCA function itself type ?principal. 
        /// </summary>
        public void ConstructPCA(Dictionary<String, Object> optionalValues = null)
        {
            this.SetToR(false);
            StringBuilder cmd = new StringBuilder();

            cmd.Append("constructPca(");
            cmd.Append(this.CurrentInterview.GridName);
            cmd.Append(getOptionalValues(optionalValues, InterviewService.PCAAcceptedValues()));
            cmd.Append(")");
            this.AppendRScript(cmd.ToString());
            this.R.Evaluate(cmd.ToString());

        }

        #endregion

        #endregion


        #region Constructs and Elements


        #region Cluster

        /// <summary>
        /// cluster is a preliminary implementation of a cluster function. It supports various distance measures as well as cluster methods. More is to come. 
        /// </summary> 
        public void cluster(
            Dictionary<String, Object> optionalValues = null)
        {
            this.SetToR(false);
            StringBuilder cmd = new StringBuilder();

            cmd.Append(this.CurrentInterview.GridName);
            cmd.Append("<-cluster(");
            cmd.Append(this.CurrentInterview.GridName);
            cmd.Append(getOptionalValues(optionalValues, InterviewService.ClusterAcceptedValues()));
            cmd.Append(")");
            this.AppendRScript(cmd.ToString());
            this.R.Evaluate(cmd.ToString());

            this.GetFromR(false);
             
        }
        /// <summary>
        /// cluster is a preliminary implementation of a cluster function. It supports various distance measures as well as cluster methods. More is to come. 
        /// </summary> 
        public void BertinCluster(            Dictionary<String, Object> optionalValues = null)
        {
            this.SetToR(false);
            StringBuilder cmd = new StringBuilder();


            cmd.Append("bertinCluster(");
            cmd.Append(this.CurrentInterview.GridName);
            cmd.Append(getOptionalValues(optionalValues, InterviewService.ClusterAcceptedValues()));
            cmd.Append(")");
            this.AppendRScript(cmd.ToString());
            this.R.Evaluate(cmd.ToString());
             

        }
        #endregion

        #endregion

        #region Visualisation

        public void bertin(  Dictionary<String, Object> optionalValues = null){ 
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
