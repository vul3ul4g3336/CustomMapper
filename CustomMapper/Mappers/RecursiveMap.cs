using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper.Mappers
{
    internal class RecursiveMap : AMap
    {
        public override object Map(object source, PropertyInfo propertyInfo)
        {

            MethodInfo methodInfo = typeof(Mapper).GetMethod("Map");

            var methodType = methodInfo.MakeGenericMethod(propertyInfo.PropertyType, propertyInfo.PropertyType);

            object type = methodType.Invoke(null, new object[] { propertyInfo.GetValue(source) });

            return type;

        }
    }
}
