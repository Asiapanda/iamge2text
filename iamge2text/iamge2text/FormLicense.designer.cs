namespace iamge2text
{
    partial class FormLicense
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLicense));
            this.pictureBoxLicense = new System.Windows.Forms.PictureBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.richTextBoxLicense = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLicense)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLicense
            // 
            this.pictureBoxLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLicense.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLicense.Location = new System.Drawing.Point(2, 2);
            this.pictureBoxLicense.Name = "pictureBoxLicense";
            this.pictureBoxLicense.Size = new System.Drawing.Size(320, 280);
            this.pictureBoxLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLicense.TabIndex = 0;
            this.pictureBoxLicense.TabStop = false;
            this.pictureBoxLicense.DoubleClick += new System.EventHandler(this.pictureBoxLicense_DoubleClick);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpen.Font = new System.Drawing.Font("华文行楷", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonOpen.Location = new System.Drawing.Point(2, 288);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(142, 32);
            this.buttonOpen.TabIndex = 1;
            this.buttonOpen.Text = "打开图片";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGenerate.Font = new System.Drawing.Font("华文行楷", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonGenerate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonGenerate.Location = new System.Drawing.Point(180, 288);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(142, 32);
            this.buttonGenerate.TabIndex = 2;
            this.buttonGenerate.Text = "提取注册码>>";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // richTextBoxLicense
            // 
            this.richTextBoxLicense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLicense.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxLicense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxLicense.Location = new System.Drawing.Point(328, 2);
            this.richTextBoxLicense.Name = "richTextBoxLicense";
            this.richTextBoxLicense.ReadOnly = true;
            this.richTextBoxLicense.Size = new System.Drawing.Size(220, 320);
            this.richTextBoxLicense.TabIndex = 3;
            this.richTextBoxLicense.Text = "";
            // 
            // FormLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 323);
            this.Controls.Add(this.richTextBoxLicense);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.pictureBoxLicense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册码截图转Text（截图后直接双击黑线区域进行粘贴）";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLicense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLicense;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.RichTextBox richTextBoxLicense;
    }
}

