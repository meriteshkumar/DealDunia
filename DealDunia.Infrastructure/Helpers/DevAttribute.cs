using System;

namespace DealDunia.Infrastructure.Helpers
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DevAttribute : Attribute
    {
        public string DisplayName { get; set; }
        public string XPath { get; set; }
        public string PreviousNode { get; set; }
        public string PreviousNodeValue { get; set; }
    }
}
