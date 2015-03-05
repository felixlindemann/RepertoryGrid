using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDotNet;

namespace RepertoryGrid.BaseClasses
{
   

    public delegate void RExececutedEventHandler(RExececutedEventArgs e);

    public class RExececutedEventArgs : EventArgs
    {

        public String RCmd { get; set; }
        public String Output { get; set; }
        public SymbolicExpression Result { get; set; }
        public Exception RExececutedException { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c">The Executed Command</param>
        /// <param name="o">The output reported from sink</param>
        /// <param name="s">The returned Symbolic Expression</param>
        /// <param name="ex">an Exception raised</param>
        ///
        public RExececutedEventArgs(String c, String o, SymbolicExpression s = null, Exception ex = null)
        {
            this.RCmd = c;
            this.Output = o;
            this.Result = s;
            this.RExececutedException = ex;
        }


    }
}
