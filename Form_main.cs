using doc_reviewer_1._2.model;
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

namespace doc_reviewer_1._2
{
    public partial class Form_main : MetroForm
    {
        public Form_main()
        {
            InitializeComponent();
        }



        private void 开始审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start_audit frm2 = new start_audit();
            
            frm2.TopLevel = false;
            frm2.FormBorderStyle = FormBorderStyle.None;
            frm2.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm2);
            frm2.Show();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 文件查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doc_qury frm2 = new Doc_qury();
            frm2.TopLevel = false;
            frm2.FormBorderStyle = FormBorderStyle.None;
            frm2.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm2);
            frm2.Show();
        }

        private void 敏感词维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dicsen frm2 = new dicsen();
            frm2.TopLevel = false;
            frm2.FormBorderStyle = FormBorderStyle.None;
            frm2.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm2);
            frm2.Show();
        }

        private void 文件标签维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dicremark frm2 = new dicremark();
            frm2.TopLevel = false;
            frm2.FormBorderStyle = FormBorderStyle.None;
            frm2.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm2);
            frm2.Show();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.White;
            menuStrip1.Location = new Point(40, 20);
            main_pic frm2 = new main_pic();
            frm2.TopLevel = false;
            frm2.FormBorderStyle = FormBorderStyle.None;
            frm2.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm2);
            frm2.Show();
        }

        private void 主页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main_pic frm2 = new main_pic();
            frm2.TopLevel = false;
            frm2.FormBorderStyle = FormBorderStyle.None;
            frm2.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm2);
            frm2.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
