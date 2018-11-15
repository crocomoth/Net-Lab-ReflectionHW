using System;

namespace CachingWithReflection
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CachingAttribute : Attribute
    {
        public int CachingTime { get; set; }

        public CachingAttribute(int seconds)
        {
            CachingTime = seconds;
        }
    }
}
