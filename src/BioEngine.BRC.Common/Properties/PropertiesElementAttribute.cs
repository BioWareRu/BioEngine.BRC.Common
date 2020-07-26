using System;

namespace BioEngine.BRC.Common.Properties
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertiesElementAttribute : Attribute
    {
        public string Name { get; }
        public PropertyElementType Type { get; }
        public bool IsRequired { get; set; }

        public PropertiesElementAttribute(string name, PropertyElementType type = PropertyElementType.String)
        {
            Name = name;
            Type = type;
        }
    }
}
