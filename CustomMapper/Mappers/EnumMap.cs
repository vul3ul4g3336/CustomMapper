using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper.Mappers
{
    internal class EnumMap : AMap
    {
        public override object Map(object source, PropertyInfo propertyInfo)
        {
            Enum enumSource = (Enum)propertyInfo.GetValue(source, null);
            var destination = Convert.ChangeType(enumSource, propertyInfo.PropertyType);
            return destination;
        }
    }
}
