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

            sqlConString = String.Format("Server={0};Database={1};User Id={2};Password = {3};", Server.Text,
                Database.Text, Username.Text, Password.Text);

            SqlConnection sqlConn = new SqlConnection(sqlConString);

            sqlString = "Select " +
                        "     clmns.name PropertyName, " +
                        "     baset.name PropertyType, " +
                        "     tbl.Name    ClassName " +
                        "FROM " +
                        "     sys.tables AS tbl " +
                        "INNER JOIN sys.all_columns AS clmns " +
                        "    ON clmns.object_id = tbl.object_id " +
                        "LEFT OUTER JOIN sys.types AS baset " +
                        "    ON (baset.user_type_id = clmns.system_type_id " +
                        "        and baset.user_type_id = baset.system_type_id)  " +
                        "            or((baset.system_type_id = clmns.system_type_id) " +
                        "                 and(baset.user_type_id = clmns.user_type_id) " +
                        "                 and(baset.is_user_defined = 0) " +
                        "                and(baset.is_assembly_type = 1)) " +
                        "Where tbl.name = '{0}'";

            sqlString = String.Format(sqlString, Table.Text);

            sqlCommand = new SqlCommand(sqlString, sqlConn);

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
                myProperties.Add(myProperty);
            }
            myPOCO.Properties = myProperties;

            POCOTemplate POCOTemplate = new POCOTemplate();
            POCOTemplate.Session = new Dictionary<string, object>();
            POCOTemplate.Session.Add("POCO", myPOCO);
            POCOTemplate.Initialize();
            //print to file
            string output = POCOTemplate.TransformText();
            output = output.Replace("\r\n", "\n");
            output = output.Replace("\n", Environment.NewLine);
            System.IO.File.WriteAllText(@"..\..\output\" + Table.Text + ".cs", output);

            button1.Text = myPOCODS.Tables[0].Rows.Count.ToString();

        }


    }
}
