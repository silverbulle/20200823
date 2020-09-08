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
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MetroFramework.Forms;

namespace doc_reviewer_1._2.model.fine_model
{
    public partial class EditAppendixType : MetroForm
    {
        public EditAppendixType()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type_update_info = Client_Conn.Client_type_update(dicremark.sent_appendix_id, textBox2.Text.Trim());
            JObject resultresponse = JObject.Parse(type_update_info);
            string code = resultresponse["code"].ToString();

            if (code == "500")
            {
                MessageBox.Show("修改失败");
                return;
            }
            else if (code == "200")
            {

                MessageBox.Show("修改成功!");
                this.Close();
            }
        }

        private void EditAppendixType_Load(object sender, EventArgs e)
        {
            textBox1.Text = dicremark.sent_apendix_name;

        }


        public static int dialog_result = 0;
        private void EditAppendixType_FormClosing(object sender, FormClosingEventArgs e)
        {
            dialog_result = 1;
        }
    }
}
