using CustomMapper.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper.ExpressionMappers
{
    internal class UnaryExpressionMap : AExpressionMap
    {
        public override object Map(object obj, ExpressionModel model)
        {
            var method = model.FuncObject.GetType().GetMethod("Invoke");
            var target = method.Invoke(model.FuncObject, new object[] { obj });
            return target;
        }
    }
}
