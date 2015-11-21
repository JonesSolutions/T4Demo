using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace T4Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string sqlConString;
            string sqlString;
            SqlCommand sqlCommand;

            // sqlConString = String.Format("Server={0};Database={1};User Id={2};Password = {3};", Server.Text,
             //   Database.Text, Username.Text, Password.Text);
            //sqlConString = String.Format("Server={0}; Database={1}; Integrated Security=true;", this.Server.Text.Trim(), this.Database.Text.Trim());

            sqlConString = this.createSqlConnectionStringFromUi();

            SqlConnection sqlConn = new SqlConnection(sqlConString);

            sqlString = @"SELECT
	                         C.[name] AS PropertyName
	                        , EP.value AS PropertyComment
	                        , I.DATA_TYPE AS PropertyType
	                        , T.[name] AS ClassName
	                        , C.is_nullable AS Nullable
	
                        FROM sys.tables AS T	
	                        INNER JOIN sys.schemas AS S 
		                        ON ( T.schema_id = S.schema_id )
	                        INNER JOIN sys.columns AS C
		                        ON ( T.object_id = C.object_id )
	                        INNER JOIN sys.types AS Y
		                        ON ( Y.user_type_id  = C.user_type_id )
	                        INNER JOIN INFORMATION_SCHEMA.COLUMNS AS I
		                        ON ( I.TABLE_SCHEMA = S.[name] AND I.TABLE_NAME = T.[name] AND I.COLUMN_NAME = C.[name] )
	                        LEFT OUTER JOIN sys.extended_properties AS EP
		                        ON ( EP.class = 1 AND EP.major_id = C.object_id AND EP.minor_id = C.column_id AND EP.name = 'MS_Description' )

                        WHERE T.[name] = @tableName
	                        AND S.[name] = @schemaName

                        ORDER BY C.column_id, C.name;";

          
 
            

            sqlCommand = new SqlCommand(sqlString, sqlConn);
            sqlCommand.Parameters.AddWithValue("@tableName", this.Table.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@schemaName", this.Schema.Text.Trim());

            

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand );
            DataSet myPOCODS = new DataSet();
            sqlAdapter.Fill(myPOCODS);

            POCO myPOCO = new POCO();
            myPOCO.ClassName = Table.Text;
            List<POCO.Property> myProperties = new List<POCO.Property>();
            foreach (DataRow row in myPOCODS.Tables[0].Rows)
            {
                POCO.Property myProperty = new POCO.Property();
                myProperty.PropertyName = row["PropertyName"].ToString();
                myProperty.PropertyType = row["PropertyType"].ToString();
                myProperty.Nullable = Convert.ToBoolean(row["Nullable"]);
                myProperty.PropertyComment = row["PropertyComment"].ToString();
                myProperties.Add(myProperty);
            }
            myPOCO.Properties = myProperties;

            POCOTemplate POCOTemplate = new POCOTemplate();
            POCOTemplate.Session = new Dictionary<string, object>();
            POCOTemplate.Session.Add("POCO", myPOCO);
            POCOTemplate.Initialize();

            //print to file
            string output = POCOTemplate.TransformText();
            //output = output.Replace("\r\n", "\n");
            //output = output.Replace("\n", "\r\n");
            System.IO.File.WriteAllText(@"..\..\output\" + Table.Text + ".cs", output);

            button1.Text = myPOCODS.Tables[0].Rows.Count.ToString();

        }

        private string createSqlConnectionStringFromUi()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = this.Server.Text.Trim();
            builder.InitialCatalog = this.Database.Text.Trim();

            builder.IntegratedSecurity = this.UseIntegratedAuthentication.Checked;

            if (!builder.IntegratedSecurity)
            {
                builder.UserID = this.Username.Text.Trim();
                builder.Password = this.Password.Text.Trim();
                
            }

            return builder.ToString();
        }

        private void UseIntegratedAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            //toggle enabling of Username and Password entry as checkbox to Use Integrated Authentication is changed
            this.Username.Enabled = !this.UseIntegratedAuthentication.Checked;
            this.Password.Enabled = !this.UseIntegratedAuthentication.Checked;
        }


    }
}
