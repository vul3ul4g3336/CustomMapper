using CustomMapper.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper.ExpressionMappers
{
    internal abstract class AExpressionMap
    {
        public abstract object Map(Object obj , ExpressionModel model);


    }
}
