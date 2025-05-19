using CustomMapper.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper
{
    internal class MappingExpression<TSource, TDestination>
    {

        public List<ExpressionModel> expressionModels = new List<ExpressionModel>();
        public MappingExpression<TSource, TDestination> ForMember<TDestProp, TMember>(Expression<Func<TSource, TDestProp>> expression, Expression<Func<TDestination, TMember>> expression2)
        {
            ExpressionModel model = new ExpressionModel();
            MemberExpression destMemberExpression = expression2.Body as MemberExpression;              
            model.DestinationProperty = (PropertyInfo)destMemberExpression.Member;
            //ConstantExpression    //常數
            if (expression.Body is ConstantExpression constantExpression)
            {
                
                model.EnumType = ExpressionEnum.ConstantExpressionMap;
                model.SourceValue = constantExpression.Value;
                // constantExpression.Value; // 1 true "123"
            }
            // Property屬性呼叫
            else if (expression.Body is MemberExpression memberExpression)
            {
                model.EnumType = ExpressionEnum.MemberExpressionMap;
              
            }
            
            else // 利用反射來簡化 region內的code
            {
                var enumType = expression.Body.GetType().BaseType.Name == "Expression" ? expression.Body.GetType().Name : expression.Body.GetType().BaseType.Name;
                model.EnumType = (ExpressionEnum)Enum.Parse(typeof(ExpressionEnum), enumType + "Map");
                model.FuncObject = expression.Compile();
            }
            #region 
            // BinaryExpression      // 二元運算，例如加法
            //else if (expression.Body is BinaryExpression binaryExpression)
            //{

            //    model.EnumType = ExpressionEnum.BinaryExpressionMap;
            //    model.FuncObject = expression.Compile();
            //}
            // ConditionalExpression // 條件運算 (三元運算子)
            //if (expression.Body is ConditionalExpression conditionalExpression)
            //{

            //    // 範例：x => x.Age > 18 ? "Adult" : "Child"
            //    model.EnumType = ExpressionEnum.ConditionalExpressionMap;
            //    model.FuncObject = expression.Compile();
            //}

            //// UnaryExpression       // 一元運算，例如取反
            //if (expression.Body is UnaryExpression unaryExpression)
            //{

            //    model.EnumType = ExpressionEnum.UnaryExpressionMap;
            //    model.FuncObject = expression.Compile();
            //    // 範例：x => !x.IsEnabled
            //}
            ////函式呼叫
            //if (expression.Body is MethodCallExpression methodCallExpression)
            //{
            //    var enumType = expression.Body.GetType().BaseType.Name;
            //    model.EnumType = ExpressionEnum.MethodCallExpressionMap;
            //    model.FuncObject = expression.Compile();
            //    //ConstantExpression exp  = (ConstantExpression)methodCallExpression.Arguments[0];
            //    //model.SourceValue = exp.Value;
            //    // 範例：x => x.Name.ToUpper()
            //}
            #endregion
            expressionModels.Add(model);
            return this;
        }
    }
}
