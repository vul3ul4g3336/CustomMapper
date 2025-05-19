using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper.DataModels
{
    internal class ExpressionModel
    {
        public ExpressionEnum EnumType { get; set; }

        public object FuncObject { get; set; }

        public PropertyInfo SourceProperty { get; set; }

        public PropertyInfo DestinationProperty { get; set; }

        public object SourceValue { get; set; }
    }
}
