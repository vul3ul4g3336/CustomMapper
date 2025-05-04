using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper.Mappers
{
    internal class NormalMap : AMap
    {
        public override object Map(object source, PropertyInfo propertyInfo)
        {
            var value = propertyInfo.GetValue(source);
            var destination = Convert.ChangeType(value, propertyInfo.PropertyType); //123 = Convert.ToInt32("123")
            return destination;
        }
    }
}
