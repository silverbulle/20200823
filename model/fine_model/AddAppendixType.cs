using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace doc_reviewer_1._2.model
{
    public partial class AddAppendixType : MetroForm
    {
        public AddAppendixType()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string addBtn = Client_Conn.Client_type_add(textBox1.Text.Trim());

            JObject JaddBtn = (JObject)JsonConvert.DeserializeObject(addBtn);

            string code = JaddBtn["code"].ToString();

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

        public static int DialogResult_1 = 0;
        private void AddAppendixType_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult_1 = 1;
        }
    }
}
