using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TEST_BINAR2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream stream = new FileStream(@"..\..\znaky.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter binarpis = new BinaryWriter(stream);

            foreach (string x in textBox1.Lines)
            {
                binarpis.Write(x[0]);
            }
            binarpis.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream stream = new FileStream(@"..\..\znaky.dat", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader binarcti = new BinaryReader(stream);
            BinaryWriter binarpis = new BinaryWriter(stream);

            binarcti.BaseStream.Position = 9;

            while (binarcti.BaseStream.Position < binarcti.BaseStream.Length)
            {
                char zmena = '*';
                binarpis.Write(zmena);
                binarcti.BaseStream.Position += 9;

            }
            binarcti.Close();
            binarpis.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FileStream stream = new FileStream(@"..\..\znaky.dat", FileMode.Open, FileAccess.Read);
            BinaryReader binarcti = new BinaryReader(stream);

           // binarcti.BaseStream.Position = 0;

            while (binarcti.BaseStream.Position < binarcti.BaseStream.Length)
            {
                listBox1.Items.Add(binarcti.ReadChar());
            }
            binarcti.Close();
        }
    }
}
