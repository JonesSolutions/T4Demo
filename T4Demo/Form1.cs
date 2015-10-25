using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            HelloWorld helloWorld = new HelloWorld();
            //instantiate your object
            Name myName = new T4Demo.Name();
            myName.FirstName = "Brian";
            //Add your object to the Template's Session
            helloWorld.Session = new Dictionary<string, object>();
            helloWorld.Session.Add("Name", myName);
            helloWorld.Initialize();
            //print to file
            string output = helloWorld.TransformText();
            System.IO.File.WriteAllText(@"..\..\output\HelloWorld.cs", output);
            button1.Text = "done";
        }
    }
}
//RuntimeTextTemplate1 test = new RuntimeTextTemplate1();
//string pageContent = test.TransformText();
//System.IO.File.WriteAllText("test.cs", pageContent);
//test.Session = new Dictionary<string, object>();
//            Test myTest = new Test() { count = 100 };
//test.Session.Add("Test", new Test() { count = 100 } );
//            test.Initialize();