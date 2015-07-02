using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RHelper.model
{
   public class rParameter
    {
       public rParameter()
       {
       }
       public rParameter(Boolean _isOptional, String _varName, string _description, Object _values, Type _type)
       {
           this.isOptional = _isOptional;
           this.VarName = _varName;
           this.Description = _description;
           this.PossibleValues =_values;
           this.VariableType = _type;

       }
        public Boolean isOptional { get; set; }
        public String VarName { get; set; }
        public String Description { get; set; }
        public Object PossibleValues { get; set; }
        public Type VariableType { get; set; }
    }
}
