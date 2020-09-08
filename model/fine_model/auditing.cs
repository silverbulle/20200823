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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySql.Data.MySqlClient.Memcached;
using word = Microsoft.Office.Interop.Word;

namespace doc_reviewer_1._2.model
{
    public partial class auditing : Form
    {
        public auditing()
        {
            InitializeComponent();
        }

        public JObject GetJObject()
        {
            var jsonText = new JObject { { "filename", label1.Text } };

            return jsonText;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string id = Doc_qury.id_new;
            string state_1 = this.comboBox1.Text;
            string MainFileState;
            if (state_1 == "审核完成")
            {
                MainFileState = "1";
                string responseText = Client_Conn.Client_change_state(id, MainFileState);

                JObject resultresponse = JObject.Parse(responseText);

                string code = resultresponse["code"].ToString();
                if (code == "200")
                {
                    MessageBox.Show("保存成功！！");
                    Form_main frm2 = new Form_main();
                    frm2.Show();
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("保存失败!");
                    return;
                }

            }
            else if (state_1 == "审核未完成")
            {
                MainFileState = "0";
                string responseText = Client_Conn.Client_change_state(id, MainFileState);

                JObject resultresponse = JObject.Parse(responseText);

                string code = resultresponse["code"].ToString();
                if (code == "200")
                {
                    MessageBox.Show("保存成功！！");
                    Form_main frm2 = new Form_main();
                    frm2.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败!");
                    return;
                }
            }
        }

        public static string  path;
        public static string fileName;
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "生成意见书模板")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "word文件（*.doc）|*.doc|数据文件（*.mdf）|*.mdf|日志文件（*.ldf）|*.ldf";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;
                sfd.InitialDirectory = "C:\\";
                sfd.DefaultExt = "YourFileName";
                sfd.FileName = "意见书模板";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    path = System.IO.Path.GetFullPath(sfd.FileName);
                    fileName = System.IO.Path.GetFileName(sfd.FileName);

                    string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                    string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                   
                    string id = Doc_qury.id_new;

                    bool result = Client_Conn.Client_download_reviewWord(Doc_qury.id_new, path, fileName);

                    if (result == true)
                    {
                        MessageBox.Show("下载成功！！！");
                    }
                    else
                    {
                        MessageBox.Show("下载失败！！！");
                    }


                    word.Application app = new word.Application();
                    app.Documents.Add(localFilePath);
                    app.Visible = true;

                }

                
            }
            else if (button3.Text == "下载意见书")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "word文件（*.doc）|*.doc|数据文件（*.mdf）|*.mdf|日志文件（*.ldf）|*.ldf";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;
                sfd.InitialDirectory = "C:\\";
                sfd.DefaultExt = "YourFileName";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    path = System.IO.Path.GetFullPath(sfd.FileName);
                    fileName = System.IO.Path.GetFileName(sfd.FileName);

                    string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                    string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                    string id = Doc_qury.id_new;

                    bool result = Client_Conn.Client_download_reviewWord(Doc_qury.id_new, path, fileName);

                    if (result == true)
                    {
                        MessageBox.Show("下载成功！！！");
                    }
                    else
                    {
                        MessageBox.Show("下载失败！！！");
                    }
                }

                
            }

            
        }

        public JObject GetObject()
        {
            var jsonText = new JObject { { "id", Doc_qury.id_new }, { "reviewWord", label1.Text.Trim() } };
            return jsonText;

        }

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

                string image_file_Type = "reviewWord";
                postContent.Add(new ByteArrayContent(File.ReadAllBytes(imgfile)), image_file_Type, imgfile);
                //添加并发送附件
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

        public static string ReviewWord;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "C:\\";    //打开对话框后的初始目录
            fileDialog.Filter = "word文件(.doc;.docx)|*.doc;*.docx|所有文件|*.*";
            fileDialog.RestoreDirectory = false;
            //若为false，则打开对话框后为上次的目录。若为true，则为初始目录
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                label1.Text = System.IO.Path.GetFileName(fileDialog.FileName);
                ReviewWord = System.IO.Path.GetFullPath(fileDialog.FileName);

                string url = "http://39.105.91.30:6667/law/file/uploadReviewWord";

                JObject jsonT = GetObject();
                JObject jsonText = JObject.Parse(jsonT.ToString());

                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("jsonText", jsonText.ToString());

                string filepath = ReviewWord;
                //string Key = "reviewWord";
                string responseText = PostJsonData(url, dic, filepath);
                JObject resultresponse = JObject.Parse(responseText);

                string code = resultresponse["code"].ToString();
                if (code == "200")
                {
                    MessageBox.Show("上传成功！");
                }
                else
                {
                    MessageBox.Show("上传失败！");
                }

            }
            
        }

        public int count;
        /// <summary>
        /// 对返回的主体数据进行解析
        /// </summary>
        /// <param name="file"></param>
        public void parsejson(string file)
        {
            int length = 0;

            //string tt = "\\r\\n公司：\\r\\n";
            //int s = tt.Length;
            JObject jObject = JObject.Parse(file);

            foreach (JToken child in jObject.Children())
            {
                var property1 = child as JProperty;
                //MessageBox.Show(property1.Name + ":" + property1.Value);
                string title1 = property1.Name.ToString().Replace(" ", "").Replace(" ", "");
                title1 = title1.Replace("\r\n", "");
                //title1 = title1.Replace("\"","");
                richTextBox1.AppendText(title1);
                JObject first = JObject.Parse(property1.Value.ToString());
                string second1 = first["type1"].ToString().Replace("[", "");
                string second2 = first["type2"].ToString().Replace("[", "");
                string second3 = first["type3"].ToString().Replace("[", "");
                string second4 = first["type4"].ToString().Replace("[", "");
                string second5 = first["type5"].ToString().Replace("[", "");
                string thirst1 = second1.Replace("]", "").Trim();
                string thirst2 = second2.Replace("]", "").Trim();
                string thirst3 = second3.Replace("]", "").Trim();
                string thirst4 = second4.Replace("]", "").Trim();
                string thirst5 = second5.Replace("]", "").Trim();
                string four1 = thirst1.Replace(" ", "").Replace(" ", "").Replace("\t", "");
                string four2 = thirst2.Replace(" ", "").Replace(" ", "").Replace("\t", "");
                string four3 = thirst3.Replace(" ", "").Replace(" ", "").Replace("\t", "");
                string four4 = thirst4.Replace(" ", "").Replace(" ", "").Replace("\t", "");
                string four5 = thirst5.Replace(" ", "").Replace(" ", "").Replace("\t", "");
                string five1 = four1.Replace("\r\n", "");
                string five2 = four2.Replace("\r\n", "");
                string five3 = four3.Replace("\r\n", "");
                string five4 = four4.Replace("\r\n", "");
                string five5 = four5.Replace("\r\n", "");
                string str = title1;
                length = str.Length + length;
                //length = length + 2;

                if (five1 == "") { }
                else
                {
                    five1 = five1.Replace("\"", "");
                    string[] senArray = five1.Split(',');
                    foreach (string com1 in senArray)
                    {
                        int com = title1.IndexOf(com1);
                        if (com == -1) { }
                        else
                        {
                            richTextBox1.Select(length - str.Length + com, com1.Length);
                            richTextBox1.SelectionColor = Color.DeepPink;
                        }
                    }

                    richTextBox1.AppendText("\r\n公司:" + five1 + "\r\n");
                    //richTextBox1.AppendText("公司" + five1 );
                    richTextBox1.Select(length, five1.Length + 5);

                    richTextBox1.SelectionColor = Color.DeepPink;
                    length = five1.Length + 5 + length;

                };
                if (five2 == "") { }
                else
                {
                    five2 = five2.Replace("\"", "");
                    richTextBox1.AppendText("\r\n废止条例:" + five2 + "\r\n");

                    richTextBox1.Select(length, five2.Length + 7);

                    richTextBox1.SelectionColor = Color.Blue;
                    length = five2.Length + 7 + length;

                };
                if (five3 == "") { }
                else
                {
                    five3 = five3.Replace("\"", "");
                    richTextBox1.AppendText("\r\n错误依据:" + five3 + "\r\n");

                    richTextBox1.Select(length, five3.Length + 7);

                    richTextBox1.SelectionColor = Color.Chocolate;
                    length = five3.Length + 7 + length;

                };
                if (five4 == "") { }
                else
                {                    
                    count = SubstringCount(five4, "@");
                    five4 = five4.Replace("\"", "").Replace(",@","@").Replace("@", "\r\n");

                    richTextBox1.AppendText("\r\n相关依据:" + five4 + "\r\n");

                    richTextBox1.Select(length, five4.Length + 7);

                    richTextBox1.SelectionColor = Color.Purple;
                    length = five4.Length + 7 + length - count;

                };
                if (five5 == "") { }
                else
                {
                    five5 = five5.Replace("\"", "");
                    string[] senArray = five5.Split(',');
                    foreach (string sen1 in senArray)
                    {
                        int sen = title1.IndexOf(sen1);
                        if (sen == -1) { }
                        else
                        {
                            if (five1.Length == five2.Length && five3.Length == five4.Length && five2.Length == five3.Length && five2.Length == 0)
                            {
                                richTextBox1.Select(length - str.Length + sen, sen1.Length);
                                richTextBox1.SelectionColor = Color.Red;
                                richTextBox1.SelectionFont = new System.Drawing.Font("宋体du", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                            }
                            else
                            {
                                if (five1.Length != 0)
                                {
                                    richTextBox1.Select(length - str.Length + sen - 5 - five1.Length, sen1.Length);
                                    richTextBox1.SelectionColor = Color.Red;
                                    richTextBox1.SelectionFont = new System.Drawing.Font("宋体du", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                                }
                                else { };
                                if (five2.Length != 0)
                                {
                                    richTextBox1.Select(length - str.Length + sen - 7 - five2.Length, sen1.Length);
                                    richTextBox1.SelectionColor = Color.Red;
                                    richTextBox1.SelectionFont = new System.Drawing.Font("宋体du", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                                }
                                else { };
                                if (five3.Length != 0)
                                {
                                    richTextBox1.Select(length - str.Length + sen - 7 - five3.Length, sen1.Length);
                                    richTextBox1.SelectionColor = Color.Red;
                                    richTextBox1.SelectionFont = new System.Drawing.Font("宋体du", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                                }
                                else { };
                                if (five4.Length != 0)
                                {
                                    richTextBox1.Select(length - str.Length + sen - 7 - five4.Length + count, sen1.Length);
                                    richTextBox1.SelectionColor = Color.Red;
                                    richTextBox1.SelectionFont = new System.Drawing.Font("宋体du", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                                }

                            }
                        }
                    }
                    //int a = richTextBox1.Find("条例");
                    //Getstring("条例");

                    richTextBox1.AppendText("\r\n敏感词:" + five5 + "\r\n");
                    richTextBox1.Select(length, five5.Length + 6);

                    richTextBox1.SelectionColor = Color.White;

                    length = five5.Length + 6 + length;

                };


            }
        }





        public static List<string> vs = new List<string>();
        public static List<string> append1 = new List<string>();
        public static List<string> append2 = new List<string>();
        public static List<string> rname = new List<string>();
        public static List<List<string>> resresponseText1 = new List<List<string>>();
        public static List<List<string>> resresponseText2 = new List<List<string>>();
        public static List<List<string>> resresponseText3 = new List<List<string>>();
        public static string s;
        int n = 0;
        //int q = 0;
        private void auditing_Load(object sender, EventArgs e)
        {
            //splitContainer2.Panel1.Height = 100;
            //splitContainer3.Panel.Height = 200;
            splitContainer4.Height = 800;

            for(int j =0;j < staticinfo.Numlackappend.Count(); j++)
            {
                for (int i = 0; i < staticinfo.Numlackappend[j]; i++)
                {
                    vs.Add(staticinfo.Lackappend[n++]);

                }
                s = "";
                s = string.Join(",", vs.ToArray());
                vs.Clear();
                if (s != "")
                {
                    string resresponseText = Client_Conn.Client_Nameappend_Select("1", "100", s);
                    JObject resultresponse = JObject.Parse(resresponseText);
                    string data = resultresponse["data"].ToString();
                    JObject datalist = JObject.Parse(data);
                    string list = datalist["list"].ToString();
                    JArray listinfo = JArray.Parse(datalist["list"].ToString());
                    rname = new List<string>();
                    for (int x = 0; x < listinfo.Count(); x++)
                    {

                        JObject list_info = JObject.Parse(listinfo[x].ToString());
                        string name = list_info["fields"]["name"].ToString();
                        rname.Add(name);
                    }
                    resresponseText1.Add(rname);
                }
                else
                {
                    rname.Clear();
                    resresponseText1.Add(rname);
                }

            }

            if (Doc_qury.state_new == "是")
            {
                button3.Text = "下载意见书";
            }
            else if (Doc_qury.state_new == "否")
            {
                button3.Text = "生成意见书模板";
            }
            //staticinfo.Numlackappend.Clear();
            int index_1 = staticinfo.Returnindex;
            
            lackappend1.Text = string.Join(",", resresponseText1[index_1].ToArray());
            resresponseText1.Clear();
            rname.Clear();

            submittime1.Text = staticinfo.Subtime[index_1];
            signer1.Text = staticinfo.Signer[index_1];
            submitunit1.Text = staticinfo.Subunit[index_1];
            department1.Text = staticinfo.Department[index_1];
            remark1.Text = staticinfo.Remark[index_1];
            parsejson(staticinfo.rc[index_1]);
        }

        //动态生成控件
        public string appendix_id;
        private void splitContainer4_Panel2_Paint(object sender, PaintEventArgs e)
        {
            n = 0;

            for (int i = 0; i < staticinfo.Numappend.Count(); i++)
            {
                append1 = new List<string>();
                append2 = new List<string>();
                for (int j = 0; j < staticinfo.Numappend[i]; j++)
                {
                    append1.Add(staticinfo.Append[n]);//附件名称
                    append2.Add(staticinfo.Appendpk[n++]);//附件id
                    //if (n > staticinfo.Numappend.Count()) { MessageBox.Show("error!!!!!!!"); }
                }
                resresponseText2.Add(append1);

                resresponseText3.Add(append2);

            }
            string test1 = string.Join(",", resresponseText2[staticinfo.Returnindex].ToArray());
            string[] sArray = test1.Split(',');
            string id = string.Join(",", resresponseText3[staticinfo.Returnindex].ToArray());
            string[] idlist = id.Split(',');

            for (int m = 0; m < sArray.Count(); m++)
            {
                LinkLabel linkLabel = new LinkLabel();
                //linkLabel.ForeColor = Color.FromArgb(255, 255, 0, 0);
                
                linkLabel.Text =  sArray[m];
                linkLabel.LinkColor = Color.Black;
                linkLabel.LinkBehavior = LinkBehavior.NeverUnderline;
                //linkLabel.
                //linkLabel.Text = string.Join(",", resresponseText2[staticinfo.Returnindex].ToArray());
                linkLabel.Name = idlist[m];
                linkLabel.Location = new Point(110 + 120 * m, 5);



                linkLabel.Click += new System.EventHandler(this.linkLabel1_LinkClicked);
                this.splitContainer4.Panel2.Controls.Add(linkLabel);
            }
            
            resresponseText2.Clear();
        }

        //下载附件
        public static string path_appendix;
        public static string filename_appendix;
        public void linkLabel1_LinkClicked(Object sender, System.EventArgs e)
        {
            string id = ((LinkLabel)sender).Name;
            //MessageBox.Show(linklabelName);

            int i = 0;

            SaveFileDialog filedialog = new SaveFileDialog();
            filedialog.Filter = "word文件（*.doc）|*.doc|数据文件（*.mdf）|*.mdf|日志文件（*.ldf）|*.ldf";
            filedialog.FilterIndex = 1;
            filedialog.RestoreDirectory = true;
            filedialog.InitialDirectory = "C:\\";
            filedialog.DefaultExt = "YourFileName";
            //filedialog.FileName =  
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                path_appendix = System.IO.Path.GetFullPath(filedialog.FileName);
                filename_appendix = System.IO.Path.GetFileName(filedialog.FileName);

                string localFilePath = filedialog.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                bool result = Client_Conn.Client_appendixfile_download(id, path_appendix, filename_appendix);
                if (result == true)
                {
                    MessageBox.Show("下载成功！！！");
                }
                else
                {
                    MessageBox.Show("下载失败！！！");
                }
            }
            i++;
            
        }
        /// <summary>
        /// 计算字符串中子串出现的次数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="substring">子串</param>
        /// <returns>出现的次数</returns>
        static int SubstringCount(string str, string substring)
        {
            if (str.Contains(substring))
            {
                string strReplaced = str.Replace(substring, "");
                return (str.Length - strReplaced.Length) / substring.Length;
            }

            return 0;
        }


        private void splitContainer5_Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public void linkLabel2_LinkClicked(Object sender, System.EventArgs e)
        {
           
        }
    }
}
