using CustomMapper.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
namespace CustomMapper.ExpressionMappers
{
    internal class MethodCallExpressionMap : AExpressionMap
    {
        public override object Map(object obj, ExpressionModel model)
        {
            var method = model.FuncObject.GetType().GetMethod("Invoke");
            
            var target = method.Invoke(model.FuncObject,new object[] { obj } );
            return target;
        }
    }
}
