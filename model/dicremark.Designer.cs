namespace doc_reviewer_1._2.model
{
    partial class dicremark
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dicremark));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnsearch1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsearch = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnlast1 = new System.Windows.Forms.Button();
            this.btnnext1 = new System.Windows.Forms.Button();
            this.btnbefore1 = new System.Windows.Forms.Button();
            this.btnfirst1 = new System.Windows.Forms.Button();
            this.labRecordCount = new System.Windows.Forms.Label();
            this.labPageIndex = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1924, 700);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel1.Controls.Add(this.btnsearch1);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnsearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1924, 893);
            this.splitContainer1.SplitterDistance = 120;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnsearch1
            // 
            this.btnsearch1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnsearch1.Location = new System.Drawing.Point(900, 32);
            this.btnsearch1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsearch1.Name = "btnsearch1";
            this.btnsearch1.Size = new System.Drawing.Size(120, 40);
            this.btnsearch1.TabIndex = 19;
            this.btnsearch1.Text = "搜索";
            this.btnsearch1.UseVisualStyleBackColor = true;
            this.btnsearch1.Click += new System.EventHandler(this.btnsearch_BtnClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1100, 32);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 40);
            this.button1.TabIndex = 14;
            this.button1.Text = "添加附件类型";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(200, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "请输入要查询的附件类型名称：";
            // 
            // btnsearch
            // 
            this.btnsearch.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnsearch.Location = new System.Drawing.Point(500, 38);
            this.btnsearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(363, 28);
            this.btnsearch.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnlast1);
            this.splitContainer2.Panel2.Controls.Add(this.btnnext1);
            this.splitContainer2.Panel2.Controls.Add(this.btnbefore1);
            this.splitContainer2.Panel2.Controls.Add(this.btnfirst1);
            this.splitContainer2.Panel2.Controls.Add(this.labRecordCount);
            this.splitContainer2.Panel2.Controls.Add(this.labPageIndex);
            this.splitContainer2.Size = new System.Drawing.Size(1924, 765);
            this.splitContainer2.SplitterDistance = 700;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnlast1
            // 
            this.btnlast1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnlast1.Location = new System.Drawing.Point(700, 5);
            this.btnlast1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnlast1.Name = "btnlast1";
            this.btnlast1.Size = new System.Drawing.Size(110, 40);
            this.btnlast1.TabIndex = 24;
            this.btnlast1.Text = "尾页";
            this.btnlast1.UseVisualStyleBackColor = true;
            // 
            // btnnext1
            // 
            this.btnnext1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnnext1.Location = new System.Drawing.Point(500, 5);
            this.btnnext1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnnext1.Name = "btnnext1";
            this.btnnext1.Size = new System.Drawing.Size(110, 40);
            this.btnnext1.TabIndex = 23;
            this.btnnext1.Text = "下一页";
            this.btnnext1.UseVisualStyleBackColor = true;
            // 
            // btnbefore1
            // 
            this.btnbefore1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnbefore1.Location = new System.Drawing.Point(300, 5);
            this.btnbefore1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnbefore1.Name = "btnbefore1";
            this.btnbefore1.Size = new System.Drawing.Size(110, 40);
            this.btnbefore1.TabIndex = 22;
            this.btnbefore1.Text = "上一页";
            this.btnbefore1.UseVisualStyleBackColor = true;
            // 
            // btnfirst1
            // 
            this.btnfirst1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnfirst1.Location = new System.Drawing.Point(100, 5);
            this.btnfirst1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnfirst1.Name = "btnfirst1";
            this.btnfirst1.Size = new System.Drawing.Size(110, 40);
            this.btnfirst1.TabIndex = 21;
            this.btnfirst1.Text = "首页";
            this.btnfirst1.UseVisualStyleBackColor = true;
            // 
            // labRecordCount
            // 
            this.labRecordCount.AutoSize = true;
            this.labRecordCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labRecordCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labRecordCount.Location = new System.Drawing.Point(1100, 5);
            this.labRecordCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labRecordCount.Name = "labRecordCount";
            this.labRecordCount.Size = new System.Drawing.Size(0, 20);
            this.labRecordCount.TabIndex = 20;
            // 
            // labPageIndex
            // 
            this.labPageIndex.AutoSize = true;
            this.labPageIndex.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPageIndex.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labPageIndex.Location = new System.Drawing.Point(900, 5);
            this.labPageIndex.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labPageIndex.Name = "labPageIndex";
            this.labPageIndex.Size = new System.Drawing.Size(0, 20);
            this.labPageIndex.TabIndex = 19;
            // 
            // dicremark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 893);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "dicremark";
            this.Text = "dicremark";
            this.Load += new System.EventHandler(this.dicremark_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox btnsearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnsearch1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnlast1;
        private System.Windows.Forms.Button btnnext1;
        private System.Windows.Forms.Button btnbefore1;
        private System.Windows.Forms.Button btnfirst1;
        private System.Windows.Forms.Label labRecordCount;
        private System.Windows.Forms.Label labPageIndex;
    }
}