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
        public override object Map(object source, PropertyInfo sourceInfo, PropertyInfo destinationInfo)
        {

            MethodInfo methodInfo = typeof(Mapper).GetMethod("Map");

            var methodType = methodInfo.MakeGenericMethod(sourceInfo.PropertyType, destinationInfo.PropertyType);

            object type = methodType.Invoke(null, new object[] { sourceInfo.GetValue(source), null });

            return type;

        }
    }
}
