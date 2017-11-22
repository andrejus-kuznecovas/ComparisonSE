using System.Collections.Generic;

namespace Login.Source.Controllers.Auth
{
    public class FormattedResponse
    {
        public List<Property> properties = new List<Property>();
        public bool Success { get; set; }

        public void AddProperty(string name, object value, bool isArray)
        {
            properties.Add(new Property(name, value, isArray));
        }

        public bool HasProperty(string name)
        {
            foreach (Property property in properties)
            {
                if (property.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public Property GetProperty(string name)
        {
            foreach (Property property in properties)
            {
                if (property.Name == name)
                {
                    return property;
                }
            }
            return null;
        }

    }

    public class Property
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public bool IsArray { get; set; }

        public Property(string name, object value, bool isArray)
        {
            this.Name = name;
            this.Value = value;
            this.IsArray = isArray;
        }
    }
}