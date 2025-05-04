using CustomMapper.Mappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                CastingType type = AMap.CheckType(ans.PropertyType);
                AMap mapper = (AMap)Activator.CreateInstance(Type.GetType("CustomMapper.Mappers." + type));
                object destObj = mapper.Map(source, property);
                ans.SetValue(destination, destObj);
            }
            //AMap mapper = (AMap)Activator.CreateInstance(Type.GetType("CustomMapper.Mappers."+ enum));
            //object destObj =  mapper.Map(souce,property)
            //ans.SetValue(destination, destObj);


            return destination;
        }



        public static TDestination Map2<TSource, TDestination>() where TDestination : class, new()
        {
            return null;
        }

    }

}
//object obj = RecursiveMap(Type sourceType,Type destinationType)



