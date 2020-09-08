using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Windows.Forms.VisualStyles;
using MetroFramework.Forms;

namespace doc_reviewer_1._2
{
    public partial class Login : MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;
            string res = Client_Conn.Client_Login(username, password);
            JObject resultresponse = JObject.Parse(res);
            string code = resultresponse["code"].ToString();
            if (code == "220")
            {
                MessageBox.Show("登录成功！");
                Form_main form_Main = new Form_main();
                
                
                form_Main.Show();
                //frm2.TopLevel = false;
                //frm2.Dock = DockStyle.Fill;
                this.Hide();

            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入用户名！");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("请输入密码！");
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
