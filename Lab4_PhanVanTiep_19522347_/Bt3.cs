using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Lab4_PhanVanTiep_19522347_
{
    public partial class Bt3 : Form
    {
        public Bt3()
        {
            InitializeComponent();
        }

        private string GetHtlm(string szUrl)
        {
            WebRequest request = WebRequest.Create(szUrl);
            WebResponse webResponse = request.GetResponse();
            Stream datastream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(datastream);
            String responsefromsever = reader.ReadToEnd();
            webResponse.Close();
            return responsefromsever;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = GetHtlm(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Link lỗi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            textBox2.Text = dialog.SelectedPath + "\\";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("vui long nhap ten file");
            }
            else
            if (textBox2.Text == "")
            {
                MessageBox.Show("Chọn địa chỉ lưu");
            }
            else
            {
                try
                {
                    WebClient myClient = new WebClient();
                    Stream response = myClient.OpenRead(textBox1.Text);
                    myClient.DownloadFile(textBox1.Text, textBox2.Text + textBox3.Text + ".html");
                    MessageBox.Show("Download Successful");
                }
                catch
                {

                    MessageBox.Show("Link Url không đúng");

                }

            }
        }

        private void Bt2_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
