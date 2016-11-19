using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace InventoryApp
{


    public partial class Form1 : Form
    {
        BindingList<string> Inventory = new BindingList<string>();





        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Inventory.Add(textBox1.Text);
            //string[] row = { textBox1.Text };
            //var listViewItem = new ListViewItem(row);
            //listBox1.Items.Add(listViewItem);
            listBox1.DataSource = null;

            listBox1.DataSource = Inventory;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inventory.Remove(textBox1.Text);


            listBox1.DataSource = null;

            listBox1.DataSource = Inventory;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void WriteToFile()
        {


            Stream stream = File.OpenWrite(Environment.CurrentDirectory + "\\File.txt");
            XmlSerializer xmlSer = new XmlSerializer(typeof(BindingList<string>));
            xmlSer.Serialize(stream, Inventory);

            stream.Close();



            ReadFile(Environment.CurrentDirectory + "\\File.ext");
        }

        public void ReadFile(string strFileName)
        {
            BindingList<string> Inventory;
            using (var reader = new StreamReader(strFileName))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(BindingList<string>), new XmlRootAttribute(""));
                Inventory = (BindingList<string>)deserializer.Deserialize(reader);
            }
        }
    }



}
