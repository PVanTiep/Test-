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
    public partial class Bt2 : Form
    {
        public Bt2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create(textBox1.Text);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(textBox2.Text);
            //request.ContentType = "application/x-www-form-urlencoder";
            request.ContentLength = byteArray.Length;
            Stream dataSteam = request.GetRequestStream();
            dataSteam.Write(byteArray, 0, byteArray.Length);
            dataSteam.Close();

            WebResponse response = request.GetResponse();
            MessageBox.Show(((HttpWebResponse)response).StatusDescription);
            try{
                dataSteam = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataSteam);
                richTextBox1.Text = reader.ReadToEnd();
                reader.Close();
            }
            catch{

            }
            response.Close();
        }
    }
}
