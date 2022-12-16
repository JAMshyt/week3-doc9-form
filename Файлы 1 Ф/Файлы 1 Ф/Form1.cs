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

namespace Файлы_1_Ф
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            string[] t = textBox1.Text.Split(' ');
            double[] num = new double[t.Length];

            FileStream f = new FileStream("..\\..\\..\\out.dat", FileMode.Open);
            BinaryWriter writer = new BinaryWriter(f);
            double stop = 0;
            try
            {
                 stop = Convert.ToDouble(textBox2.Text);
            }
            catch { MessageBox.Show("Ошибка"); }
            for (int i = 0; i < t.Length; i++)
            {
                num[i] = Convert.ToDouble(t[i]);
                writer.Write((i + 1) + ") " + num[i] + "\n");
            }
            writer.Close();

            using (FileStream z = new FileStream("..\\..\\..\\out.dat", FileMode.Open))
            {
                int j = 0;
                byte[] bb = new byte[z.Length];
                z.Read(bb, 0, bb.Length);
                string[] n = Encoding.UTF8.GetString(bb).Split('\n');
                do
                {
                    if (j == num.Length) break;
                    if (num[j] < stop & ((j + 1) % 2 == 0 | (j + 1) % 2 == 2))
                    {
                        richTextBox1.Text += n[j] + "\n";
                    }
                    j++;
                } while (true);
            }
        }
    }
}
