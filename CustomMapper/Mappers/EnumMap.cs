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
        public override object Map(object source, PropertyInfo sourceInfo, PropertyInfo destinationInfo)
        {
            Enum enumSource = (Enum)sourceInfo.GetValue(source, null);
            var destination = Convert.ChangeType(enumSource, sourceInfo.PropertyType);
            return destination;
        }
    }
}
