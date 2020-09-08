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
    public partial class EditSenWord : MetroForm
    {
        public EditSenWord()
        {
            InitializeComponent();
        }

        private void EditSenWord_Load(object sender, EventArgs e)
        {
            textBox1.Text = dicsen.sent_sen_name;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string type_update_info = Client_Conn.Client_type_update(dicremark.sent_appendix_id, textBox2.Text.Trim());
            string senWord_update_info = Client_Conn.Client_sensitive_update(dicsen.sent_sen_id, textBox2.Text.Trim());
            JObject resultresponse = JObject.Parse(senWord_update_info);
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

        public static int sen_dialog_result = 0;
        private void EditSenWord_FormClosing(object sender, FormClosingEventArgs e)
        {
            sen_dialog_result = 1;
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
