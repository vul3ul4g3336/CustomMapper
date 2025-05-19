using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper.Mappers
{
    public abstract class AMap
    {
        public abstract object Map(object source, PropertyInfo sourceInfo, PropertyInfo destinationInfo);


    }
}
