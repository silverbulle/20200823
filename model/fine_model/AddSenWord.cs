using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using MySqlX.XDevAPI.Relational;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MetroFramework.Forms;

namespace doc_reviewer_1._2.model
{
    public partial class AddSenWord : MetroForm
    {
        public AddSenWord()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sRemoteInfo = Client_Conn.Client_sensitive_add(textBox1.Text.Trim());

            JObject JsRemoteInfo = (JObject)JsonConvert.DeserializeObject(sRemoteInfo);
            //转回json

            string code = JsRemoteInfo["code"].ToString();

            if (code == "500")
            {
                MessageBox.Show("添加失败!");
                return;
            }
            else if (code == "200")
            {
                MessageBox.Show("添加成功！");
                this.Close();
            }
        }

        public static int dialog_re = 0;
        private void AddSenWord_FormClosing(object sender, FormClosingEventArgs e)
        {
            dialog_re = 1;
        }
    }
}
