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
using System.Windows.Forms.VisualStyles;
using doc_reviewer_1._2.model.fine_model;
using MetroFramework.Forms;
using MetroFramework;

namespace doc_reviewer_1._2.model
{
    public partial class Doc_qury : Form
    {
        public Doc_qury()
        {
            InitializeComponent();
        }

        public static string id = "";
        public static List<string> appendixName = new List<string>();
        public static List<string> appendixId = new List<string>();
        public static List<List<string>> Lackappendname = new List<List<string>>() { };
        public void refresh()
        {
            staticinfo.Lackappend.Clear();
            staticinfo.Numlackappend.Clear();
            staticinfo.Subtime.Clear();
            staticinfo.Signer.Clear();
            staticinfo.Subunit.Clear();
            staticinfo.Department.Clear();
            staticinfo.Remark.Clear();
            staticinfo.rc.Clear();
            //staticinfo.Returnindex.Clear();
            appendixName.Clear();
            string type = "0";
            string state = "3";
            if (comboBox1.Text == "规范性文件")
            {
                type = "0";
            }
            else if (comboBox1.Text == "法律")
            {
                type = "1";
            }
            else if (comboBox1.Text == "合同")
            {
                type = "2";
            }
            else if (comboBox1.Text == "全部")
            {
                type = "0,1,2";
            }

            if (comboBox2.Text == "审核未完成")
            {
                state = "0";
            }
            else if (comboBox2.Text == "审核完成")
            {
                state = "1";
            }
            else if (comboBox2.Text == "系统处理中")
            {
                state = "2";
            }
            else if (comboBox2.Text == "系统处理完成")
            {
                state = "3";
            }
            //else if (comboBox2.Text == "软删除")
            //{
            //    state = 4;
            //}
            else if (comboBox2.Text == "全部")
            {
                state = "0,1,2,3";
            }

            dataGridView1.Rows.Clear();


            string responseText = Client_Conn.Client_file_select("1", "1000", textBox1.Text, type, state);

            //解析json
            JObject resultresponse = JObject.Parse(responseText);

            string code = resultresponse["code"].ToString();
            string message = resultresponse["message"].ToString();
            string data = resultresponse["data"].ToString();

            JObject datalist = JObject.Parse(data);

            string total = datalist["total"].ToString();
            string list = datalist["list"].ToString();

            JArray listinfo = JArray.Parse(datalist["list"].ToString());
            //staticinfo.Lackappend.Clear();
            staticinfo.Numlackappend.Clear();
            //解析List json
            for (int i = 0; i < listinfo.Count(); i++)
            {
                JObject list_info = JObject.Parse(listinfo[i].ToString());

                string model = list_info["model"].ToString();
                string pk = list_info["pk"].ToString();
                id = pk;
                string fields = list_info["fields"].ToString();
                string name = list_info["fields"]["name"].ToString();  //文件名
                staticinfo.MainName.Add(name);
                string type_1 = list_info["fields"]["type"].ToString();
                string content = list_info["fields"]["content"].ToString();
                string returncontent = list_info["fields"]["returncontent"].ToString();  //返回的主体结果

                staticinfo.rc.Add(returncontent);
                string url = list_info["fields"]["url"].ToString();
                string filename = list_info["fields"]["filename"].ToString();
                string submissionunit = list_info["fields"]["submissionunit"].ToString();  //送审单位
                staticinfo.Subunit.Add(submissionunit);
                string submissiontime = list_info["fields"]["submissiontime"].ToString();  //送达时间
                staticinfo.Subtime.Add(submissiontime);
                string issuer = list_info["fields"]["issuer"].ToString();  //签发人姓名
                staticinfo.Signer.Add(issuer);
                string issuerdepartment = list_info["fields"]["issuerdepartment"].ToString(); //签发人科室
                staticinfo.Department.Add(issuerdepartment);
                string remarks = list_info["fields"]["remarks"].ToString(); //备注
                staticinfo.Remark.Add(remarks);
                string lastedittime = list_info["fields"]["lastedittime"].ToString();
                string reviewopinion = list_info["fields"]["reviewopinion"].ToString();
                string state_1 = list_info["fields"]["state"].ToString();
                string reviewwordurl = list_info["fields"]["reviewwordurl"].ToString();
                string appendix = list_info["fields"]["appendix"].ToString();  //已有附件
                string needappendix = list_info["fields"]["needAppendix"].ToString(); //缺少附件


                JObject appendixlist = JObject.Parse(appendix); //附件信息
                string appendix_total = appendixlist["total"].ToString();
                string appendix_list = appendixlist["list"].ToString();

                JArray appendix_listinfo = JArray.Parse(appendixlist["list"].ToString());
                staticinfo.Numappend.Add(appendix_listinfo.Count());
                for (int j = 0; j < appendix_listinfo.Count(); j++)
                {
                    JObject appendix_list_info = JObject.Parse(appendix_listinfo[j].ToString());

                    string appendix_model = appendix_list_info["model"].ToString();
                    string appendix_pk = appendix_list_info["pk"].ToString();

                    appendixId.Add(appendix_pk);
                    staticinfo.Appendpk.Add(appendix_pk);
                    string appendix_fields = appendix_list_info["fields"].ToString();
                    string appendix_file_id = appendix_list_info["fields"]["file_id"].ToString();
                    string appendix_name = appendix_list_info["fields"]["name"].ToString();

                    appendixName.Add(appendix_name);
                    staticinfo.Append.Add(appendix_name);
                    string appendix_url = appendix_list_info["fields"]["url"].ToString();
                    string appendix_appendixtype_id = appendix_list_info["fields"]["appendixtype_id"].ToString();
                    string appendix_state_1 = appendix_list_info["fields"]["state"].ToString();
                }


                JObject needappendixlist = JObject.Parse(needappendix);
                string needappendix_total = needappendixlist["total"].ToString();
                string needappendix_list = needappendixlist["list"].ToString();

                JArray needappendix_listinfo = JArray.Parse(needappendixlist["list"].ToString());
                staticinfo.Numlackappend.Add(needappendix_listinfo.Count());
                for (int k = 0; k < needappendix_listinfo.Count(); k++)
                {
                    JObject needappendix_list_info = JObject.Parse(needappendix_listinfo[k].ToString());

                    string needappendix_model = needappendix_list_info["model"].ToString();
                    string needappendix_pk = needappendix_list_info["pk"].ToString();
                    string needappendix_fields = needappendix_list_info["fields"].ToString();
                    string needappendix_file_id = needappendix_list_info["fields"]["file_id"].ToString();
                    //string needappendix_name = needappendix_list_info["fields"]["name"].ToString();
                    //string needappendix_url = needappendix_list_info["fields"]["url"].ToString();
                    string needappendix_appendixtype_id = needappendix_list_info["fields"]["appendixtype_id"].ToString();//缺少附件
                    staticinfo.Lackappend.Add(needappendix_appendixtype_id);
                    string needappendix_state_1 = needappendix_list_info["fields"]["state"].ToString();
                }

                int index = this.dataGridView1.Rows.Add();

                dataGridView1.Rows[index].Cells[0].Value = id;
                dataGridView1.Rows[index].Cells[1].Value = name;//文件名
                if (type_1 == "0")
                {
                    dataGridView1.Rows[index].Cells[2].Value = "规范性文件";
                }
                else if (type_1 == "1")
                {
                    dataGridView1.Rows[index].Cells[2].Value = "法律";
                }
                else if (type_1 == "2")
                {
                    dataGridView1.Rows[index].Cells[2].Value = "合同";
                }
                dataGridView1.Rows[index].Cells[3].Value = submissionunit;//送审单位
                dataGridView1.Rows[index].Cells[4].Value = submissiontime;//送达时间
                dataGridView1.Rows[index].Cells[5].Value = issuer;//签发人姓名
                dataGridView1.Rows[index].Cells[6].Value = issuerdepartment;//签发人科室
                dataGridView1.Rows[index].Cells[7].Value = remarks;
                if (reviewwordurl == "")
                {
                    dataGridView1.Rows[index].Cells[8].Value = "否";
                }
                else
                {
                    dataGridView1.Rows[index].Cells[8].Value = "是";
                }
                //审查意见书
                dataGridView1.Rows[index].Cells[9].Value = lastedittime;//修改时间

                if (state_1 == "0")
                {
                    dataGridView1.Rows[index].Cells[10].Value = "审核未完成";
                }
                else if (state_1 == "1")
                {
                    dataGridView1.Rows[index].Cells[10].Value = "审核完成";
                }
                else if (state_1 == "2")
                {
                    dataGridView1.Rows[index].Cells[10].Value = "系统处理中";
                }
                else if (state_1 == "3")
                {
                    dataGridView1.Rows[index].Cells[10].Value = "系统处理完成";
                }
                else if (state_1 == "4")
                {
                    dataGridView1.Rows[index].Cells[10].Value = "软删除";
                }

                //dataGridView1.Rows[index].Cells[11].Value = state_1;//状态

            }

            this.dataGridView1.Columns[0].Visible = false;
        }

        private void button_Click(object sender, EventArgs e)
        {
            this.refresh();
            

        }


        public static string id_new;
        public static string state_new;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "DetailBtn" && e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                staticinfo.Returnindex = e.RowIndex;
                id_new = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                state_new = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString() == "系统处理中")
                {
                    MetroMessageBox.Show(this,"处理中文件不可查看！");
                    //MessageBox.Show("处理中文件不可查看！");
                    return;
                }
                else
                {
                    auditing_new frm = new auditing_new();
                    frm.Show();
                }


            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "SupBtn" && e.RowIndex >= 0)
            {
                
            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "DeletBtn" && e.RowIndex >= 0)
            {
                string message_id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString() == "系统处理中")
                {
                    MetroMessageBox.Show(this, "处理中文件不可删除！"); 
                    //MessageBox.Show("处理中文件不可删除！");
                    return;
                }
                else
                {
                    if (MetroMessageBox.Show(this,"确定删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string responsText = Client_Conn.Client_file_delet(message_id);
                        //this.dataGridView1.Rows.Clear();

                        JObject resultresponse = JObject.Parse(responsText);

                        string code = resultresponse["code"].ToString();

                        if (code == "200")
                        {
                            MessageBox.Show("删除成功！");
                        }
                        else if (code == "500")
                        {
                            MessageBox.Show("删除失败！");
                        }
                        this.refresh();
                    }
                }   

            }
        }

        //重新请求，刷新


        private void Doc_qury_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            dataGridView1.ForeColor = Color.Black;
            //staticinfo.Numlackappend.Clear();
            AddBtndgv2();
            this.refresh();
        }

        private void AddBtndgv2()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "DetailBtn";//添加按钮的名字
            btn.HeaderText = "操作";//添加按钮列的列名称
            btn.DefaultCellStyle.NullValue = "详情";//添加按钮显示的名字
            

            //DataGridViewButtonColumn supbtn = new DataGridViewButtonColumn();
            //supbtn.Name = "SupBtn";
            //supbtn.HeaderText = "补充";
            //supbtn.DefaultCellStyle.NullValue = "补充";
            //dataGridView1.Columns.Add(supbtn);


            DataGridViewButtonColumn delbtn = new DataGridViewButtonColumn();
            delbtn.Name = "DeletBtn";
            delbtn.HeaderText = "删除";
            delbtn.DefaultCellStyle.NullValue = "删除";
            dataGridView1.Columns.Add(delbtn);//在dataGridView2的最后一列添加按钮

            dataGridView1.Columns.Insert(11, btn);//在dataGridView2的指定列添加按钮
        }


    }
}
