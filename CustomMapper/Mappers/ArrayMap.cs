using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper.Mappers
{
    internal class ArrayMap : AMap
    {
        public override object Map(object source, PropertyInfo propertyInfo)
        {

            Array objArray = (Array)propertyInfo.GetValue(source); //int[]
            if (objArray == null)
                return null;
            //var arrayLength = int.Parse(objArray.GetType().GetProperties().FirstOrDefault(x => x.Name == "Length").GetValue(objArray).ToString());
            var newArray = Array.CreateInstance(objArray.GetType().GetElementType(), objArray.Length); // 
            for (int i = 0; i < objArray.Length; i++)
            {
                newArray.SetValue(objArray.GetValue(i), i);
            }
            return newArray;
        }
    }
}
