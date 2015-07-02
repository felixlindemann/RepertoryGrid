using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RHelper.model;

namespace OpenRepGridGui.View.uc
{
   public interface IucOptionalValues
    {
          rParameter RParameter { get; set; }
          bool isUsed{ get;   }
          object ParamValue { get; }
    }
}
