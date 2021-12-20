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
using EasyEncryption;

namespace laba2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                if(!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    string encrypedString = crypter.Encrypt(richTextBox1.Text, textBox1.Text);
                    StreamWriter fileWriter = new StreamWriter("EncryptedString.txt");
                    fileWriter.Write(encrypedString);
                    fileWriter.Close();
                    richTextBox1.Text = encrypedString;
                }
                else
                {
                    MessageBox.Show("Введите ключ!");
                }
            }
            else
            {
                MessageBox.Show("Введите текст!");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadCFG = new OpenFileDialog();
            loadCFG.Filter = "Text file(*.txt)|*.txt|All files(*.*)|*.*";
            DialogResult result = loadCFG.ShowDialog();
            if (result == DialogResult.OK)
            {
                StreamReader fileReader = new StreamReader(loadCFG.OpenFile());
                richTextBox2.Text =  fileReader.ReadToEnd();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(richTextBox2.Text))
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    richTextBox2.Text = crypter.Decrypt(richTextBox2.Text, textBox2.Text);
                }
                else
                {
                    MessageBox.Show("Введите ключ!");
                }
            }
            else
            {
                MessageBox.Show("Введите текст для расшифровки!");
            }
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
