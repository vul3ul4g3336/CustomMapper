using CustomMapper.Mappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper.Mappers
{
    internal class EnumerableMap : AMap
    {
        public override object Map(object source, PropertyInfo sourceInfo, PropertyInfo destinationInfo)
        {
            var obj = sourceInfo.PropertyType.GenericTypeArguments;
            Type newListType = null;
            if (destinationInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                newListType = typeof(List<>).MakeGenericType(obj);
            }
            else if (destinationInfo.PropertyType.GetGenericTypeDefinition() == typeof(HashSet<>))
            {
                newListType = typeof(HashSet<>).MakeGenericType(obj);
            }
            var newList = Activator.CreateInstance(newListType); //List<int>
            //IList list = (IList)source.GetType().GetProperty("list").GetValue(source);

            //MethodInfo method = newListType.GetMethod("Add");

            //foreach (var i in list)
            //{
            //    method.Invoke(newList, new object[] { i });
            //}
            var list = (IEnumerable)sourceInfo.GetValue(source);


            MethodInfo method = newListType.GetMethod("Add");


            //object destination = Activator.CreateInstance(destinationInfo.PropertyType);
            //MethodInfo methodInfo = typeof(RecursiveMap).GetMethod("Map");

            MethodInfo centerMap = typeof(Mapper).GetMethod("Map");
            var MethodType = centerMap.MakeGenericMethod(obj[0], obj[0]);



            //var methodType = methodInfo.MakeGenericMethod(obj);
            foreach (var item in list) //[1.2.3.4.5] -> ["1"]
            {

                var type = MethodType.Invoke(null, new object[] { item, null });
                method.Invoke(newList, new object[] { type }); ///int
            }
            return newList;
        }
    }
}
