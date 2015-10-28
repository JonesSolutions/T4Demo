using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4Demo
{
    class POCO
    {

        private string className;
        private List<Property> properties;
        
        public List<Property> Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }
        
        public class Property
        {
            private string propertyName;
            private string propertyType;

            public string PropertyType
            {
                get { return propertyType; }
                set { propertyType = value; }
            }

            public String PropertyName
            {
                get { return propertyName; }
                set { propertyName = value; }
            }
        }
    }
}
