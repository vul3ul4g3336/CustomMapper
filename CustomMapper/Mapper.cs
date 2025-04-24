using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper
{
    internal class Mapper
    {
        public static TDestination Map<TSource, TDestination>(TSource source) where TDestination : class, new()
        {
            TDestination destination = new TDestination();
            var propertySource = typeof(TSource).GetProperties();
            var propertyDestination = typeof(TDestination).GetProperties();
            foreach (var property in propertySource)
            {
                var ans = propertyDestination.FirstOrDefault(x => x.Name == property.Name);
                if (ans == null)
                    continue;

                //enum 對轉 + List 集合 + 陣列[]
                if (ans.PropertyType.IsArray && property.PropertyType.IsArray)
                {
                    Array objArray = (Array)property.GetValue(source); //int[]
                    var arrayLength = int.Parse(objArray.GetType().GetProperties().FirstOrDefault(x => x.Name == "Length").GetValue(objArray).ToString());
                    var newArray = Array.CreateInstance(objArray.GetType().GetElementType(), arrayLength); // 


                    for (int i = 0; i < arrayLength; i++)
                    {
                        newArray.SetValue(objArray.GetValue(i), i);
                    }
                    // List<int> -> List<string>
                    ans.SetValue(destination, newArray);
                }
                else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
                {
                    var obj = property.PropertyType.GenericTypeArguments;
                    var newListType = typeof(List<>).MakeGenericType(obj);
                    var newList = Activator.CreateInstance(newListType); //List<int>
                    var sourceList = property.GetValue(source);
                    IEnumerable list = (IEnumerable)sourceList;

                    MethodInfo method = newListType.GetMethod("Add");

                    foreach (var item in list) //[1.2.3.4.5] -> ["1"]
                    {
                        method.Invoke(newList, new object[] { RecursiveMap(item, ans.PropertyType.GenericTypeArguments[0]) }); ///int
                    }
                    ans.SetValue(destination, newList);
                }
                else if (ans.PropertyType.IsClass == true && ans.PropertyType != typeof(string))
                {

                    var dest = RecursiveMap(property.PropertyType, ans.PropertyType);
                    ans.SetValue(destination, dest);

                }
                else if (property.PropertyType.IsEnum == true)
                {
                    Enum enumSource = (Enum)property.GetValue(source, null);
                    ans.SetValue(destination, enumSource.ToString());
                }
                else
                {
                    ans.SetValue(destination, property.GetValue(source));

                }

            }
            return destination;
        }
        private static object RecursiveMap(object source, Type destinationType)
        {
            object destination = Activator.CreateInstance(destinationType);
            MethodInfo methodInfo = typeof(Mapper).GetMethod("Map");
            var methodType = methodInfo.MakeGenericMethod(source.GetType(), destinationType);
            var type = methodType.Invoke(destination, new object[] { source });
            return type;
        }
        //object obj = RecursiveMap(Type sourceType,Type destinationType)

    }
}
