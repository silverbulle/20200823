using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using ImTools;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Web.Security;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using MetroFramework.Forms;

namespace doc_reviewer_1._2.model
{
    public partial class start_audit : Form
    {
        public static string mainfilepath;
        public static string otherfilepath;
        Autosize asc = new Autosize();
        public start_audit()
        {
            InitializeComponent();
        }
        public List<string> name = new List<string>();
        public int total ;
        public List<string> id = new List<string>();
        private void start_audit_Load(object sender, EventArgs e)
        {
            //Font font = new Font("微软雅黑", 10.2);
            this.dataGridView1.RowHeadersVisible = false;
            //this.dataGridView1.AllowUserToAddRows = false;
            DataGridViewComboBoxColumn combox1 = new DataGridViewComboBoxColumn();
            combox1.Name = "combox1";
            combox1.HeaderText = "选择文件类型";
            combox1.Width = 260;
            this.Font = new Font("微软雅黑", 10);
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "btn";
            btn.HeaderText = "选择文件";
            btn.Width = 375;
            DataGridViewButtonColumn delbtn = new DataGridViewButtonColumn();
            delbtn.Name = "delbtn";
            delbtn.HeaderText = "";
            delbtn.Width = 50;
            delbtn.DefaultCellStyle.NullValue = "删除";
            

            dataGridView1.Columns.Insert(0, btn);
            //dataGridView1.Columns.Insert(2, addbtn);
            dataGridView1.Columns.Insert(1, combox1);
            dataGridView1.Columns.Insert(2, delbtn);

            //List<string> name = new List<string>();

            //给combox 、datagridview、checkbox赋值；
            string response_str = Client_Conn.Client_type_Select("1", "10000", "");
            JObject response_type = JObject.Parse(response_str);
            string data = response_type["data"].ToString();
            JObject datalist = JObject.Parse(data);
            total = (int)datalist["total"];
            JArray listinfo = JArray.Parse(datalist["list"].ToString());
            for (int i = 0; i < listinfo.Count(); i++)
            {
                JObject list1 = JObject.Parse(listinfo[i].ToString());
                name.Add(list1["fields"]["name"].ToString());
                id.Add(list1["pk"].ToString());
            }
            int length = (int)datalist["total"];
            for (int i = 0; i < length; i++)
            {
                combox1.Items.Add(name[i].ToString());
                //comboBox1.Items.Add(name[i].ToString());
            }
            comboBox1.Items.Add("规范性文件");
            comboBox1.Items.Add("法律");
            comboBox1.Items.Add("合同");
            //comboBox1.Width = 100;

            panel2.Height = 60;

            int row = 0;
            for (int i = 0; i < listinfo.Count(); i++)
            {
                if (i % 4 == 0 && i != 0)
                {
                    row++;
                    panel2.Height += 50;
                }
                CheckBox box = new CheckBox();

                box.Text = name[i].ToString();
                //box.Text = string.Format("box{0}", i);
                box.Name = string.Format("linklabel{0}", i);
                box.Size = new Size(120, 50);
                
                box.Location = new Point(190 + i%4 * 180,  50 * row);

                this.panel2.Controls.Add(box);

                panel1.Location = new Point((this.Width - panel1.Width) / 2, (this.Height - panel1.Height) / 2);

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        //添加审核文件
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\Users\\HP\\Desktop\\";
            openFileDialog1.Filter = "word文件(.doc;.docx)|*.doc;*.docx|所有文件|*.*";
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);
                mainfilepath = System.IO.Path.GetFullPath(openFileDialog1.FileName);  

            }
        }

        public static List<string> ComboxValue = new List<string>();
        public static List<string> BtnValue = new List<string>();
        public static int comboBox_id;
        public JObject GetJObject() //建立json文件
        {
            
            if (comboBox1.Text == "规范性文件")
            {
                comboBox_id = 0;
            }
            else if (comboBox1.Text == "法律")
            {
                comboBox_id = 1;
            }
            else if (comboBox1.Text == "合同")
            {
                comboBox_id = 2;
            }
            var jsonText = new JObject { { "name", textBox4.Text }, { "type", comboBox_id }, { "submissionUnit", textBox1.Text }, { "submissionTime", dateTimePicker1.Text }, { "issuer", textBox3.Text }, { "issuerDepartment", textBox2.Text }, { "remarks", richTextBox1.Text } };

            for (int i = 0; i < this.dataGridView1.Rows.Count-1; i++)
            {
                //添加附件和附件类型
                string appendix_Type = this.dataGridView1.Rows[i].Cells[1].Value.ToString();

                for (int j = 0; j < total; j++)
                {
                    if (appendix_Type == name[j])
                    {
                        ComboxValue.Add(id[j]);
                    }
                }
                //ComboxValue.Add(this.dataGridView1.Rows[i].Cells[0].Value.ToString());
                BtnValue.Add(this.dataGridView1.Rows[i].Cells[0].Value.ToString());               
            }

            JArray appendixText = new JArray();
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {
                JObject appendixValue = new JObject();
                appendixValue.Add("appendixType", ComboxValue[i]);
                appendixValue.Add("appendixFileName", nickname[i]);
                appendixValue.Add("realName", BtnValue[i]);
                appendixText.Add(appendixValue);
            }

            var appTypeText = new JArray { };
            var JappTYpe = new JObject {  };
            //var appTypeText = new JArray {
            //    new JObject{{ "appendixType", checkedListBox1.CheckedItems[0].ToString() } }
            //    };
            foreach (Control c in panel2.Controls)
            {
                if (c is CheckBox && ((CheckBox)c).Checked == true)
                {
                    string needappendixType = c.Text;
                    for (int i = 0; i < total; i++)
                    {
                        if (needappendixType == name[i])
                        {
                            JappTYpe = new JObject { { "appendixType", id[i] } };
                            //ComboxValue.Add(id[i]);
                        }
                    }
                    appTypeText.Add(JappTYpe);
                }
            }

            jsonText.Add("appendix", appendixText);
            jsonText.Add("needAppendix", appTypeText);

            return jsonText;

        }
        

        //发送请求并得到json
        public static string PostJsonData(string url, Dictionary<string, string> dic, string imgfile)
        {
            string str = "";
            try
            {
                HttpClient client = new HttpClient();
                var postContent = new MultipartFormDataContent();


                string boundary = string.Format("--{0}", DateTime.Now.Ticks.ToString("x"));
                postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");
                //postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");

                string image_file_Type = "file";
                postContent.Add(new ByteArrayContent(File.ReadAllBytes(imgfile)), image_file_Type, imgfile);
                //添加并发送附件
                for (int i = 0; i < count; i++)
                {
                    string appendixfilename = nickname[i].ToString();
                    string appendixfilepath = NewDirectory[i].ToString();
                    postContent.Add(new ByteArrayContent(File.ReadAllBytes(appendixfilepath)), appendixfilename, appendixfilepath);
                }
                foreach (var key in dic.Keys)
                {
                    postContent.Add(new StringContent(dic[key].ToString()), key);
                }
                HttpResponseMessage response = client.PostAsync(url, postContent).Result;
                str = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception ex)
            {
                MessageBox.Show("PostJsonData:" + ex.ToString());
            }
            return str;

        }

        public static int count;
        //提交按钮
        private void button3_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "")
            {
                MessageBox.Show("请选择文件类型！");
            }
            else if (textBox4.Text == "   ")
            {
                MessageBox.Show("请上传文件！");
            }
            else
            {
                JObject jsonT = GetJObject();
                JObject jsonText = JObject.Parse(jsonT.ToString());

                //MessageBox.Show(jsonT.ToString());
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("jsonText", jsonText.ToString());

                count = this.dataGridView1.Rows.Count - 1;

                string response = PostJsonData("http://39.105.91.30:6667/law/file/add", dic, mainfilepath);
                JObject resultresponse = JObject.Parse(response);
                string code = resultresponse["code"].ToString();

                if (code == "500")
                {
                    MessageBox.Show("上传失败!");
                }
                else if (code == "200")
                {
                    MessageBox.Show("上传成功! ");
                    clean(this.panel1);
                    clean(this.panel2);
                    clean(this.panel3);
                    clean(this.panel4);
                    //clean(this.FindForm());
                    Doc_qury frm2 = new Doc_qury();
                    frm2.Show();
                    //Application.Restart();

                }


                //MessageBox.Show("清空完成！");
            }
        }

        public static void clean(Control contain)  //接收Form窗体
        {
            for (int i = 0; i < contain.Controls.Count; i++)
            {
                foreach (Control control in contain.Controls[i].Controls)
                {
                    if (control is TextBox)
                    {
                        (control as TextBox).Text = "";
                    }
                    if (control is CheckBox)
                    {
                        (control as CheckBox).Checked = false;
                    }
                    if (control is ComboBox)
                    {
                        (control as ComboBox).SelectedIndex = 0;
                    }
                    if (control is RichTextBox)
                    {
                        (control as RichTextBox).Text = "";
                    }
                    if (control is DateTimePicker)
                    {
                        (control as DateTimePicker).Value = DateTime.Now;
                    }
                    if (control is DataGridView)
                    {
                        (control as DataGridView).Rows.Clear();
                    }

                    //其它控件类似以上操作即可
                }
            }
        }






        public List<string> appendixfilepath = new List<string>();
        public static List<string> NewDirectory = new List<string>();
        public static List<string> nickname = new List<string>();
        public int index = 0;
        public List<string> appendixTypename = new List<string>();
        public int Rowindex = 0;
        //点击表格中的下拉框和按钮
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string folder = System.Environment.CurrentDirectory + "\\cache\\";
            if (false == System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "addbtn" && e.RowIndex >= 0)
            {
                dataGridView1.Rows.Add();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "btn" && e.RowIndex >= 0)
            {
                //OpenFileDialog fileDialog = new OpenFileDialog();
                openFileDialog2.InitialDirectory = "C:\\Users\\HP\\Desktop\\";
                openFileDialog2.Filter = "word文件(.doc;.docx)|*.doc;*.docx|所有文件|*.*";
                openFileDialog2.RestoreDirectory = false;

                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    this.dataGridView1.CurrentCell.Value = System.IO.Path.GetFileName(openFileDialog2.SafeFileName);
                    //appendixfilepath[e.RowIndex] = System.IO.Path.GetFileName(fileDialog.FileName);
                    appendixfilepath.Add(System.IO.Path.GetFullPath(openFileDialog2.FileName));

                    string path = System.IO.Path.GetDirectoryName(openFileDialog2.FileName);//C: \Users\HP
                    string time = DateTime.Now.ToString("yyyyMMddHHmmss");

                    nickname.Add(time + "_" + index + ".doc");
                    //nicknamepath.Add(path + "\\" + time + "_" + index + ".doc");

                    //string NewPath = System.Environment.CurrentDirectory;


                    NewDirectory.Add(folder + time + ".doc");

                    File.Copy(appendixfilepath[index], NewDirectory[index]);
                    //File.Move(NewDirectory, nicknamepath[index]);
                    index = index + 1;

                    appendixTypename.Add(this.dataGridView1.CurrentCell.Value.ToString());
                    Rowindex++;
                }

            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "delbtn" && e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                //int index = e.RowIndex;

                if (MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                        return;
                    }
                    
                }
            }
            this.panel2.Refresh();
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
