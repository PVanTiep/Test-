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
    public partial class Bt1 : Form
    {
        public Bt1()
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
    }
}
