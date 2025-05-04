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
        public override object Map(object source, PropertyInfo propertyInfo)
        {
            var obj = propertyInfo.PropertyType.GenericTypeArguments;
            Type newListType = null;
            if (propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                newListType = typeof(List<>).MakeGenericType(obj);
            }
            else if (propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(HashSet<>))
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
            var list = (IEnumerable)propertyInfo.GetValue(source);


            MethodInfo method = newListType.GetMethod("Add");


            object destination = Activator.CreateInstance(propertyInfo.PropertyType);
            //MethodInfo methodInfo = typeof(RecursiveMap).GetMethod("Map");

            MethodInfo centerMap = typeof(Mapper).GetMethod("Map");
            var MethodType = centerMap.MakeGenericMethod(obj[0], obj[0]);



            //var methodType = methodInfo.MakeGenericMethod(obj);
            foreach (var item in list) //[1.2.3.4.5] -> ["1"]
            {

                var type = MethodType.Invoke(null, new object[] { item });
                method.Invoke(newList, new object[] { type }); ///int
            }
            return newList;
        }
    }
}
