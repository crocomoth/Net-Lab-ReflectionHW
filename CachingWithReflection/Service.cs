using CachingWithReflection.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingWithReflection
{
    public class Service
    {
        ReflectionDataConverter dataConverter;

        public Service()
        {
            dataConverter = new ReflectionDataConverter();
        }

        public string GetOrdersByClientId(int id)
        {
            return string.Empty;
        }
    }
}
