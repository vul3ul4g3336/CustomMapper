using CustomMapper.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper.ExpressionMappers
{
    internal class ConstantExpressionMap : AExpressionMap
    {
        public override object Map(object obj , ExpressionModel model)
        {
            return model.SourceValue;
        }
    }
}
