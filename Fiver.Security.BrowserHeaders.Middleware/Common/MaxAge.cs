using System;

namespace Fiver.Security.BrowserHeaders.Middleware.Common
{
    public sealed class MaxAge
    {
        private MaxAge(int value)
        {
            this.Value = value;
        }
        
        public int Value { get; }

        public static MaxAge FromSeconds(int value)
        {
            return new MaxAge(value);
        }

        public static MaxAge FromMinutes(int value)
        {
            return FromTimeSpan(TimeSpan.FromMinutes(value));
        }

        public static MaxAge FromDays(int value)
        {
            return FromTimeSpan(TimeSpan.FromDays(value));
        }

        public static MaxAge FromTimeSpan(TimeSpan value)
        {
            return new MaxAge((int)value.TotalSeconds);
        }
    }
}
