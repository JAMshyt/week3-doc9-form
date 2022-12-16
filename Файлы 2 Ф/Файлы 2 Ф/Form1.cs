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

namespace Файлы_2_Ф
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("..\\..\\..\\..\\..\\text.txt");
            while (true)
            {
                string a = reader.ReadLine();
                if (a == null) break;
                if (a.Contains(' '))
                {
                    richTextBox1.Text+=a+"\n";
                }
            }
            reader.Close();
        }
    }
}
