using doc_reviewer_1._2.model.fine_model;
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
    public partial class dicsen : Form
    {
        public dicsen()
        {
            InitializeComponent();
        }

        private void dicsen_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;


            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            //string jsonfile = Client_conn.Client_sensitive_Select("1", pageSize.ToString(), null);
            string jsonfile = Client_Conn.Client_sensitive_Select("1", "2000", null);

            jsonget(jsonfile);

            DataGridViewRow row = new DataGridViewRow();

            dataGridView1.ForeColor = Color.Black;
            dataGridView1.RowHeadersWidth = 100;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            dataGridView1.Columns.Add(column_add("id"));
            dataGridView1.Columns.Add(column_add("敏感词"));
            table.Rows.Clear();
            pklist.Clear();
            PageSorter();//分页
            AddBtndgv2(3);
        }
        public void jsonget(string jsonfile)
        {

            JObject resultresponse = JObject.Parse(jsonfile);
            //string code = resultresponse["code"].ToString();
            //string message = resultresponse["message"].ToString();
            string data = resultresponse["data"].ToString();

            //JObject datalist = JObject.Parse(data);

            //string total = datalist["total"].ToString();
            //string list = datalist["list"].ToString();

            JObject datainfo = JObject.Parse(data);
            JArray listinfo = JArray.Parse(datainfo["list"].ToString());
            staticinfo.Listinfo = listinfo;
        }
        /// <summary>
        /// 添加编辑和删除的按钮
        /// </summary>
        private void AddBtndgv2(int begin)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "edit";//添加按钮的名字
            btn.HeaderText = "编辑";//添加按钮列的列名称
            btn.DefaultCellStyle.NullValue = "编辑";//添加按钮显示的名字
            btn.Width = 50;
            dataGridView1.Columns.Add(btn);//在dataGridView2的最后一列添加按钮

            DataGridViewButtonColumn endbtn = new DataGridViewButtonColumn();
            endbtn.Name = "del";
            endbtn.HeaderText = "删除";
            endbtn.DefaultCellStyle.NullValue = "删除";
            endbtn.Width = 50;
            dataGridView1.Columns.Insert(begin, endbtn);//在dataGridView2的指定列添加按钮

        }

        public static string sent_sen_name;
        public static string sent_sen_id;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击button按钮事件
            if (dataGridView1.Columns[e.ColumnIndex].Name == "edit" && e.RowIndex >= 0)
            {
                //说明点击的列是DataGridViewButtonColumn列
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];

                sent_sen_name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                sent_sen_id = pklist[e.RowIndex];

                EditSenWord edit_type = new EditSenWord();
                edit_type.ShowDialog();

                if (EditSenWord.sen_dialog_result == 1)
                {
                    dataGridView1.Rows.Clear();
                    string sea = btnsearch.Text;
                    string jsonfile = Client_Conn.Client_sensitive_Select("1", "2000", sea);
                    JObject resultresponse = JObject.Parse(jsonfile);
                    string data = resultresponse["data"].ToString();
                    JObject datainfo = JObject.Parse(data);
                    JArray listinfo = JArray.Parse(datainfo["list"].ToString());
                    staticinfo.Listinfo = listinfo;
                    DataGridViewRow row = new DataGridViewRow();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    dataGridView1.ForeColor = Color.Black;
                    dataGridView1.RowHeadersWidth = 100;
                    dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                    dataGridView1.Columns.Add(column_add("id"));
                    dataGridView1.Columns.Add(column_add("敏感词"));
                    //dataGridView1.Columns.Add(column_add("pk"));
                    table.Rows.Clear();
                    pklist.Clear();
                    PageSorter();//分页

                    AddBtndgv2(3);
                }

                //MessageBox.Show("点击了编辑按钮！");

            }
            //点击button按钮事件
            if (dataGridView1.Columns[e.ColumnIndex].Name == "del" && e.RowIndex >= 0)
            {
                //说明点击的列是DataGridViewButtonColumn列
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                if (MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string b = pklist[e.RowIndex];
                    //dataGridView1.Rows.Clear();
                    string a = Client_Conn.Client_sensitive_delet(b);
                    pklist.Clear();
                    //DataGridView dg = new DataGridView();    //重新绑定
                    //dataGridView1.Refresh();
                    dataGridView1.Rows.Clear();
                    string sea = btnsearch.Text;
                    string jsonfile = Client_Conn.Client_sensitive_Select("1", "2000", sea);
                    JObject resultresponse = JObject.Parse(jsonfile);
                    string data = resultresponse["data"].ToString();
                    JObject datainfo = JObject.Parse(data);
                    JArray listinfo = JArray.Parse(datainfo["list"].ToString());
                    staticinfo.Listinfo = listinfo;
                    DataGridViewRow row = new DataGridViewRow();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    dataGridView1.ForeColor = Color.Black;
                    dataGridView1.RowHeadersWidth = 100;
                    dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                    dataGridView1.Columns.Add(column_add("id"));
                    dataGridView1.Columns.Add(column_add("敏感词"));
                    //dataGridView1.Columns.Add(column_add("pk"));
                    table.Rows.Clear();
                    PageSorter();//分页
                    AddBtndgv2(3);
                    MessageBox.Show("删除成功!");
                }
                

            }
        }
        DataTable table = new DataTable();
        public int pageSize = 20;// 每页记录数
        public int recordCount = 0;// 总记录数
        public int pageCount = 0;// 总页数
        public int currentPage = 0;// 当前页
        public List<string> pklist = new List<string>();
        /// <summary>
        /// 敏感词分页的方法
        /// </summary>
        /// <param name="str"></param>
        private void PageSorter()
        {


            //创建虚拟表
            DataColumn column1 = new DataColumn("test1", Type.GetType("System.String"));
            DataColumn column2 = new DataColumn("test2", Type.GetType("System.String"));
            //DataColumn column3 = new DataColumn("test3", Type.GetType("System.String"));
            table.Columns.Clear();
            table.Columns.Add(column1);             //将列添加到table表中
            table.Columns.Add(column2);
            //this.Controls.Add(dataGridView1);
            //table.Columns.Add(column3);
            pklist.Clear();
            for (int i = 0; i <= staticinfo.Listinfo.Count() - 1; i++)
            //for (int i = 0; i <= 10; i++)
            {
                DataRow dr = table.NewRow();            //table表创建行

                JObject list1 = JObject.Parse(staticinfo.Listinfo[i].ToString());
                int index = dataGridView1.Rows.Add();
                //index = j;
                //MessageBox.Show("list1 = " + list1);
                //string model = list1["model"].ToString();
                string pk = list1["pk"].ToString();
                string name = list1["fields"]["name"].ToString();
                //string state = list1["fields"]["state"].ToString();
                //MessageBox.Show("model=" + model + "\r\n" + "pk=" + pk + "\r\n" + "name=" + name + "\r\n" + "state=" + state);
                //((DataTable)dataGridView2.DataSource).Rows.Add(list);
                pklist.Add(pk);
                dataGridView1.Rows[index].Cells[0].Value = i+1;
                dataGridView1.Rows[index].Cells[1].Value = name;
                dr["test1"] = i+1;
                dr["test2"] = name;
                //dr["test3"] = "规格型号" + i.ToString();
                table.Rows.Add(dr);                     //将数据加入到table表中

            }
            //staticinfo.Nameremark = dataGridView1.Rows[staticinfo.Idremark].Cells[0].Value.ToString();
            int recordCount = table.Rows.Count;     //记录总行数
            staticinfo.Recordcount = recordCount;
            pageCount = (recordCount / pageSize);
            if ((recordCount % pageSize) > 0)
            {
                pageCount++;
            }

            //默认第一页
            currentPage = 1;

            LoadPage();//调用加载数据的方法
        }
        /// <summary>
        /// LoadPage方法
        /// </summary>
        private void LoadPage()
        {
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            int beginRecord;    //开始指针
            int endRecord;      //结束指针
            DataTable dtTemp;
            dtTemp = table.Clone();

            beginRecord = pageSize * (currentPage - 1);
            if (currentPage == 1) beginRecord = 0;
            endRecord = pageSize * currentPage;

            if (currentPage == pageCount) endRecord = staticinfo.Recordcount;
            for (int i = beginRecord; i < endRecord; i++)
            {
                dtTemp.ImportRow(table.Rows[i]);
            }

            dataGridView1.Rows.Clear();

            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[] { dtTemp.Rows[i][0], dtTemp.Rows[i][1] });
            }

            labPageIndex.Text = "当前页: " + currentPage.ToString() + " / " + pageCount.ToString();//当前页
            labRecordCount.Text = "总行数: " + staticinfo.Recordcount.ToString() + " 行";//总记录数
        }

        private void btnfirst_BtnClick(object sender, EventArgs e)
        {
            if (currentPage == 1)
            { return; }
            currentPage = 1;
            LoadPage();
        }

        private void btnbefore_BtnClick(object sender, EventArgs e)
        {
            if (currentPage == 1)
            { return; }
            currentPage--;
            LoadPage();
        }

        private void btnnext_BtnClick(object sender, EventArgs e)
        {
            if (currentPage == pageCount)
            { return; }
            currentPage++;
            LoadPage();
        }

        private void btnlast_BtnClick(object sender, EventArgs e)
        {
            if (currentPage == pageCount)
            { return; }
            currentPage = pageCount;
            LoadPage();
        }
        int column_key = 0;
        /// <summary>
        /// datagridview添加列方法
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private DataGridViewTextBoxColumn column_add(string name)
        {
            DataGridViewTextBoxColumn txtClum = new DataGridViewTextBoxColumn();
            txtClum.DataPropertyName = "txt" + column_key++.ToString();
            txtClum.Name = "txt" + column_key++.ToString();
            txtClum.HeaderText = name;
            return txtClum;
        }
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                                                e.RowBounds.Location.Y,
                                                dgv.RowHeadersWidth - 4,
                                                e.RowBounds.Height);


            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                                    dgv.RowHeadersDefaultCellStyle.Font,
                                    rectangle,
                                    dgv.RowHeadersDefaultCellStyle.ForeColor,
                                    TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSenWord frm1 = new AddSenWord();
            frm1.ShowDialog();

            if (AddSenWord.dialog_re == 1)
            {
                dataGridView1.Rows.Clear();
                string sea = btnsearch.Text;
                string jsonfile = Client_Conn.Client_sensitive_Select("1", "2000", sea);
                JObject resultresponse = JObject.Parse(jsonfile);
                string data = resultresponse["data"].ToString();
                JObject datainfo = JObject.Parse(data);
                JArray listinfo = JArray.Parse(datainfo["list"].ToString());
                staticinfo.Listinfo = listinfo;
                DataGridViewRow row = new DataGridViewRow();
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.ForeColor = Color.Black;
                dataGridView1.RowHeadersWidth = 100;
                dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                dataGridView1.Columns.Add(column_add("id"));
                dataGridView1.Columns.Add(column_add("敏感词"));
                //dataGridView1.Columns.Add(column_add("pk"));
                table.Rows.Clear();
                pklist.Clear();
                PageSorter();//分页

                AddBtndgv2(3);
            }
        }

        private void btnsearch_BtnClick(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sea = btnsearch.Text;
            string jsonfile = Client_Conn.Client_sensitive_Select("1", "2000", sea);
            JObject resultresponse = JObject.Parse(jsonfile);
            string data = resultresponse["data"].ToString();
            JObject datainfo = JObject.Parse(data);
            JArray listinfo = JArray.Parse(datainfo["list"].ToString());
            if (listinfo.Count() != 0)
            {
                staticinfo.Listinfo = listinfo;
                DataGridViewRow row = new DataGridViewRow();
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.ForeColor = Color.Black;
                dataGridView1.RowHeadersWidth = 100;
                dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                dataGridView1.Columns.Add(column_add("id"));
                dataGridView1.Columns.Add(column_add("敏感词"));
                //dataGridView1.Columns.Add(column_add("pk"));
                table.Rows.Clear();
                pklist.Clear();
                PageSorter();//分页

                AddBtndgv2(3);
            }
            else
            {
                MessageBox.Show(sea + "不存在于数据库中！");
            }

        }
    }
}
