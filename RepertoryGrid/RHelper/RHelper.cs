using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using RDotNet; 

namespace RHelper
{
    /// <summary>
    /// by Felix Lindemann
    /// </summary>
    public class RHelper : IDisposable
    {

        #region Variables

        private REngine rEngine;
        private Boolean autoPrint = false; 
        private int sinkwidth = 1000; 
        private String rHome = @"c:\Program Files\R\R-3.1.2"; 
        private Boolean is64Bit = Environment.Is64BitProcess;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int SinkWidth
        {
            get { return sinkwidth; }
            set
            {
                sinkwidth = value;

                if (this.rEngine != null)
                {
                    this.rEngine.Evaluate(string.Format("options(width = {0})", sinkwidth));

                }
            }
        }

        /// <summary>
        /// The R-Home Directory 
        /// </summary>
        public String RHome
        {
            get { return rHome; }
            set
            {
                rHome = value;
            }
        }

        /// <summary>
        /// R-home as DirectoryInfo
        /// </summary>
        private DirectoryInfo dirRHome
        {
            get
            {
                return new DirectoryInfo(rHome);
            }
        }

        /// <summary>
        /// DirectoryInfo of Binaries
        /// </summary>
        private DirectoryInfo dirRBin
        {
            get
            {
                return new DirectoryInfo(Path.Combine(dirRHome.FullName, "bin\\" + (is64Bit ? "x64" : "i386")));
            }
        }

        /// <summary>
        /// not tested if 32bit Application can run a 64bit R instance and vice Versa.
        /// </summary>
        public Boolean Is64Bit
        {
            get { return is64Bit; }
            set { is64Bit = value; }
        }
         
        public Boolean AutoPrint
        {
            get { return autoPrint; }
            set
            {
                autoPrint = value;
                this.rEngine.AutoPrint = value;
            }
        }
         
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor Method
        /// 
        /// Checks for Checking existing and choosing R 
        /// x64/i386
        /// </summary>
        /// <param name="autoprint">is needed for debugging purposes</param>
        public RHelper( )
        {
            if (dirRHome.Exists)
            {
                if (dirRBin.Exists)
                {

                    REngine.SetEnvironmentVariables(dirRBin.FullName, dirRHome.FullName);
                    this.rEngine = REngine.GetInstance();
                    this.AutoPrint = autoPrint;
                    // Use for Debug Purpose.
                    // Update sinkwidt in rEngine instance
                    this.SinkWidth = this.sinkwidth;
                    return;
                }
            }
            // throw Exceptions, if R Could not be found.
            if (is64Bit) throw new SystemException("an installation of R 64bit is required.");
            throw new SystemException("an installation of R 32bit is required.");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Commands will be execucted linewise by default.
        /// Before a command is executed, the sink command is executed to 
        /// divert the R output to a temp-File 
        /// https://stat.ethz.ch/R-manual/R-devel/library/base/html/sink.html
        /// After the Command is executed, the content from the tmp-file 
        /// is read and included in the event RExececuted while it is fired. 
        /// </summary>
        /// <param name="cmd">the Commands to be Executed. can be multiline</param>
        /// <param name="widht">sink may produce newline if width is to small</param>
        /// <returns>the result of the evaluated commands</returns>
        public List<SymbolicExpression> Evaluate(String cmd, Boolean linewise = true)
        {
            List<SymbolicExpression> rs = new List<SymbolicExpression>();
            if (linewise)
            {
                // Make array by splitting each line
                String[] a = cmd.Split(Environment.NewLine.ToCharArray());

                // iterate for each Command
                foreach (string str in a)
                {
                    // Remove Blank Spaces at beginning and end
                    String strCMD = str.Trim();
                    // do not execute for empty lines
                    if (strCMD.Length > 0)
                    {
                        rs.Add(EvaluateLine(strCMD));
                    }
                }
            }
            else
            {
                rs.Add(EvaluateLine(cmd));
            }
            return rs;

        }

        /// <summary>
        /// Commands will be execucted linewise by default.
        /// Before a command is executed, the sink command is executed to 
        /// divert the R output to a temp-File 
        /// https://stat.ethz.ch/R-manual/R-devel/library/base/html/sink.html
        /// After the Command is executed, the content from the tmp-file 
        /// is read and included in the event RExececuted while it is fired. 
        /// </summary>
        /// <param name="scriptfile">the script that should be executed</param> 
        /// <returns>the result of the evaluated commands</returns>
        public List<SymbolicExpression> Evaluate(FileInfo scriptfile)
        {
            if (!scriptfile.Exists)
            {
                throw new FileNotFoundException();
            }
            String cmd = File.ReadAllText(scriptfile.FullName);
            return Evaluate(cmd);

        }

        /// <summary>
        /// Locale function for executing to avoid loop
        /// </summary>
        /// <param name="cmd">the line to be executed.</param>
        /// <returns></returns>
        private SymbolicExpression EvaluateLine(String cmd)
        {

            String result = "";
            // getTempfile name for sink 
            FileInfo f = new FileInfo(Path.GetTempFileName());
            SymbolicExpression s = null;
            try
            {
                // Activate sink
                this.Execute(string.Format("sink(\"{0}\")", f.FullName.Replace("\\", "/")));

                // Evaluate Command and add Result to result list.
                s = rEngine.Evaluate(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // End sink
                this.Execute("sink()");

                // read sink-Output from tempfile
                result = File.ReadAllText(f.FullName);

                // delete tempfile
                this.Execute(string.Format("unlink(\"{0}\")", f.FullName.Replace("\\", "/")));

                // fire Event
                CommandExecuted(new RExececutedEventArgs(cmd, result, s));
            }
            return s;
        }

        /// <summary>
        /// Execute Command without fireing Event
        /// </summary>
        /// <param name="cmd"></param>
        public void Execute(String cmd)
        {
            rEngine.Evaluate(cmd);
        }

        public  Boolean isValidVariableName(string value)
        {
            Boolean result = true;
       //Todo
            // http://www.r-bloggers.com/testing-for-valid-variable-names/
            return result;
        }

        #endregion

        #region get Converted R-variables from R

        public int getInt(string cmd)
        {
            return this.getIntegerVector(cmd)[0];
        }

        public String getString(string cmd)
        {
            return this.getCharacterVector(cmd)[0];
        }

        public IntegerVector getIntegerVector(string cmd)
        {
            return this.rEngine.Evaluate(cmd).AsInteger();
        }
        public NumericVector getNumericVector(string cmd)
        {
            return this.rEngine.Evaluate(cmd).AsNumeric();
        }

        public CharacterVector getCharacterVector(string cmd)
        {
            return this.rEngine.Evaluate(cmd).AsCharacter();
        }

        public GenericVector getGenericVector(string cmd)
        {
            return this.rEngine.Evaluate(cmd).AsList();
        }

        #endregion

        #region Transform

        /// <summary>
        /// Fill a DataGridView control from a R DataFrame object
        /// </summary>
        /// <param name="df">the DataFrame</param>
        /// <param name="dgv">the Grid to be added.</param>
        /// <param name="digits">the number of digitis for Rounding.</param>
        public static void FillDataGridViewFromR(DataFrame df, DataGridView dgv, int digits)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();


            for (int i = 0; i < df.ColumnCount; ++i)
            {
                dgv.ColumnCount++;
                dgv.Columns[i].Name = df.ColumnNames[i];
            }

            for (int i = 0; i < df.RowCount; ++i)
            {
                dgv.RowCount++;
                dgv.Rows[i].HeaderCell.Value = df.RowNames[i];

                for (int k = 0; k < df.ColumnCount; ++k)
                {

                    try
                    {


                        dgv[k, i].Value = Math.Round((double)df[i, k], digits);

                    }
                    catch (Exception)
                    {
                        dgv[k, i].Value = df[i, k];
                    }

                }

            }


        }

        /// <summary>
        /// Fill a DataGridView control from a R NumericMatrix object
        /// </summary>
        /// <param name="df">the NumericMatrix</param>
        /// <param name="dgv">the Grid to be added.</param>
        /// <param name="digits">the number of digitis for Rounding.</param>

        public static void FillDataGridViewFromR(NumericMatrix df, DataGridView dgv, int digits)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();


            for (int i = 0; i < df.ColumnCount; ++i)
            {
                dgv.ColumnCount++;
                dgv.Columns[i].Name = df.ColumnNames[i];
            }

            for (int i = 0; i < df.RowCount; ++i)
            {
                dgv.RowCount++;
                dgv.Rows[i].HeaderCell.Value = df.RowNames[i];

                for (int k = 0; k < df.ColumnCount; ++k)
                {

                    dgv[k, i].Value = Math.Round(df[i, k], digits);

                }

            }


        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Event for communicating results of executed commands
        /// </summary>

        public event RExececutedEventHandler rExec;
        protected virtual void CommandExecuted(RExececutedEventArgs e)
        {
            RExececutedEventHandler handler = rExec;
            if (handler != null)
            {
                handler(e);
            }
        }

        #endregion

        #region Dispose

        public void Dispose()
        {

            if (this.rEngine != null)
            {
                if (this.rEngine.IsRunning)
                {
                    // if any plots are open, they have to be closed 
                    // before shooting down R
                    int I = this.getInt("length(dev.list())");
                    for (int i = 0; i < I; i++)
                    {
                        this.EvaluateLine("dev.off()");
                    }
                }
                // Shoot down
                this.rEngine.Dispose();
                this.rEngine = null;

            }

        }

        #endregion
    }
}
