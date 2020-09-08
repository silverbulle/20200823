namespace doc_reviewer_1._2.model
{
    partial class AddAppendixType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAppendixType));
            this.Button1 = new MetroFramework.Controls.MetroButton();
            this.textBox1 = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Button1.Location = new System.Drawing.Point(211, 183);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(110, 35);
            this.Button1.TabIndex = 2;
            this.Button1.Text = "添加";
            this.Button1.UseSelectable = true;
            this.Button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            // 
            // 
            // 
            this.textBox1.CustomButton.Image = null;
            this.textBox1.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.textBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(211, 99);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(110, 30);
            this.textBox1.TabIndex = 4;
            this.textBox1.UseSelectable = true;
            this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // AddAppendixType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 313);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddAppendixType";
            this.Text = "添加附件类型";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddAppendixType_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton Button1;
        private MetroFramework.Controls.MetroTextBox textBox1;
    }
}