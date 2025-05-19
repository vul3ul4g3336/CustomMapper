using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper.Extensions
{
    public static class CastingTypeExtension
    {
        public static CastingType CheckType(Type type)
        {
            if (type.IsArray)
            {

                return CastingType.ArrayMap;
            }
            else if (typeof(IEnumerable).IsAssignableFrom(type) && type != typeof(string))
            {

                return CastingType.EnumerableMap;
            }
            else if (type.IsClass == true && type != typeof(string))
            {

                return CastingType.RecursiveMap;


            }
            else if (type.IsEnum == true)
            {
                return CastingType.EnumMap;
            }
            else
            {
                return CastingType.NormalMap;

            }
        }
    }
}
