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
       public rParameter(Boolean _isOptional, String _varName, string _description, Object _values, Type _type, int _maxLength, int _minLength, int _length)
       {
           this.isOptional = _isOptional;
           this.VarName = _varName;
           this.Description = _description;
           this.PossibleValues =_values;
           this.VariableType = _type;
           this.MaxLength = _maxLength;
           this.MinLength = _minLength;
           this.Length = _length;
       }
        public Boolean isOptional { get; set; }
        public String VarName { get; set; }
        public String Description { get; set; }
        public Object PossibleValues { get; set; }
        public Type VariableType { get; set; }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
        public int Length { get; set; }
    }
}
