using System;

namespace CachingWithReflection
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CachingAttribute : Attribute
    {
        private DateTime _expirationTime;

        public CachingAttribute(int seconds)
        {
            _expirationTime = DateTime.Now + TimeSpan.FromSeconds(seconds);
        }

        public bool IsCachingExpired { get => DateTime.Now > _expirationTime; }
    }
}
