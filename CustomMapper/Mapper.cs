using CustomMapper.ExpressionMappers;
using CustomMapper.Extensions;
using CustomMapper.Mappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper
{
    internal class Mapper
    {
        // x => [x.ForMember().ForMember().ForMember().ForMember().ForMember().ForMember().ForMember().ForMember().ForMember()]

        public static TDestination Map<TSource, TDestination>(TSource source, //.for.for
            Action<MappingExpression<TSource, TDestination>> expression = null) where TDestination : class, new()
        {
            TDestination destination = new TDestination();
            var propertySource = typeof(TSource).GetProperties();
            var propertyDestination = typeof(TDestination).GetProperties();
            object destObj = null;
            foreach (var property in propertySource)
            {
                var temp = property.GetValue(source);
                if (temp == null)
                    continue;
                var ans = propertyDestination.FirstOrDefault(x => x.Name == property.Name);
                if (ans == null)
                    continue;


                //if (property.PropertyType != ans.PropertyType)
                //    newInfo = ChangeTpye(ans.PropertyType, property.GetValue(source));

                destObj = Mapping(source, property, ans);
                ans.SetValue(destination, destObj);


            }
            MappingExpression<TSource, TDestination> mappingExpression = new MappingExpression<TSource, TDestination>();
            expression?.Invoke(mappingExpression);
            foreach (var model in mappingExpression.expressionModels)
            {
                AExpressionMap map = (AExpressionMap)Activator.CreateInstance(Type.GetType("CustomMapper.ExpressionMappers." + model.EnumType));
                var destinationValue = map.Map(source, model);
                model.DestinationProperty.SetValue(destination, Convert.ChangeType(destinationValue, model.DestinationProperty.PropertyType));
                //destObj = Mapping(source, mappingInfo.Key, mappingInfo.Value);
                //mappingInfo.Value.SetValue(destination, destObj);
            }


            //AMap mapper = (AMap)Activator.CreateInstance(Type.GetType("CustomMapper.Mappers."+ enum));
            //object destObj =  mapper.Map(souce,property)
            //ans.SetValue(destination, destObj);

            //if (expression != null && expression2 != null)
            //{
            //    MemberExpression member1 = (MemberExpression)expression.Body;
            //    PropertyInfo info1 = (PropertyInfo)member1.Member;
            //    MemberExpression member2 = expression2.Body as MemberExpression;
            //    PropertyInfo info2 = (PropertyInfo)member2.Member;
            //    var obj = Mapping(source, info1, info2);
            //    info2.SetValue(destination, obj);
            //}

            return destination;
        }

        private static object Mapping(Object sourceObj, PropertyInfo source, PropertyInfo destination)
        {
            CastingType type = CastingTypeExtension.CheckType(destination.PropertyType);
            AMap mapper = (AMap)Activator.CreateInstance(Type.GetType("CustomMapper.Mappers." + type));
            object destObj = mapper.Map(sourceObj, source, destination);
            return destObj;
        }

        //private static PropertyInfo ChangeTpye(Type type, Object obj)
        //{

        //}

    }

}




