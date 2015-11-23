using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4Demo
{
    class POCO
    {
        #region Variables


        private string className;
        private List<Property> properties;
        #endregion
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
            private bool nullable;
            private string propertyComment;

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

            public bool Nullable
            {
                get { return nullable; }
                set { nullable = value; }
            }

            public string PropertyComment
            {
                get { return this.propertyComment; }
                set { this.propertyComment = value; }
            }



            //methods to output template text

            public string ToPublcPropertyTemplateText()
            {
                /*
                 public string  LastName
		            {
			            get {return _LastName;}
			            set {_LastName = value;}
		            } 
                 */ 

                StringBuilder sb = new StringBuilder();

                string cSharpType = this.getCsharpType();

                //TODO: add comment if applicable

                if (!String.IsNullOrWhiteSpace(this.PropertyComment))
                {
                    sb.AppendFormat("// {0}", this.PropertyComment);
                    sb.AppendLine();

                }


                sb.Append("public ");  

                sb.Append(cSharpType);

                if (this.Nullable && cSharpType != "string")
                {
                    sb.Append("?");
                }

                

                sb.AppendFormat(" {0}", this.PropertyName);
                sb.AppendLine();

                sb.AppendLine("{");

                sb.AppendFormat("\tget {{ return this._{0}; }}", this.PropertyName);
                sb.AppendLine();

                sb.AppendFormat("\tset {{ this._{0} = value; }}", this.PropertyName);
                sb.AppendLine();

                sb.AppendLine("}");
                

                return sb.ToString();
            }

            public string ToProtectedFieldTemplateText()
            {
                StringBuilder sb = new StringBuilder();

                string cSharpType = this.getCsharpType();

                sb.Append("protected ");


                sb.Append(cSharpType);

                if (this.Nullable && cSharpType != "string")
                {
                    sb.Append("?");
                }

                sb.AppendFormat(" _{0};", this.PropertyName);



                return sb.ToString();

            }

            //get the C# type based on the SQL data type in the PropertyType property
            // the PropertyType value should be a base SQL Server data type
            // mapping based on https://msdn.microsoft.com/en-us/library/ms131092.aspx
            private string getCsharpType()
            {
                string result = null;

                if (this.PropertyType == null)
                {
                    throw new Exception("PropertyType value cannot be null");
                }

                switch (this.PropertyType.ToLower().Trim())
                {
                    case "bigint":
                        result = "int64";
                        break;

                    case "binary":
                    case "varbinary":
                        result = "btye[]";
                        break;

                    case "bit":
                        result = "bool";
                        break;

                    case "char":
                    case "nchar":
                    case "ntext":
                    case "text":
                    case "nvarchar":
                    case "varchar":
                    case "xml":
                        result = "string";
                        break;

                    case "date":
                    case "datetime":
                    case "datetimeoffset":
                    case "datetime2":
                        result = "DateTime";
                        break;

                    case "decimal":
                    case "money":
                    case "smallmoney":
                        result = "decimal";
                        break;

                    case "float":
                        result = "double";
                        break;

                    case "int":
                        result = "int";
                        break;

                    case "real":
                        result = "single";
                        break;

                    case "smallint":
                        result = "int16";
                        break;

                    case "time":
                        result = "TimeSpan";
                        break;

                    case "tinyint":
                        result = "btye";
                        break;

                    case "uniqueidentifier":
                        result = "Guid";
                        break;




                        

                    default:
                        result = "object";
                        break;
                }

                return result;


            }
            
        }
    }
}
