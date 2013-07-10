namespace RegularGlossary
{
    partial class FrmRegularyShow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegularyShow));
            this.lsbSearchName = new System.Windows.Forms.ListBox();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.txtExplain = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBind = new System.Windows.Forms.Button();
            this.ckbSetWindowPos = new System.Windows.Forms.CheckBox();
            this.ckbSearchType = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblAbout = new System.Windows.Forms.Label();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsbSearchName
            // 
            this.lsbSearchName.FormattingEnabled = true;
            this.lsbSearchName.ItemHeight = 12;
            this.lsbSearchName.Location = new System.Drawing.Point(3, 32);
            this.lsbSearchName.Name = "lsbSearchName";
            this.lsbSearchName.Size = new System.Drawing.Size(180, 172);
            this.lsbSearchName.TabIndex = 0;
            this.lsbSearchName.SelectedIndexChanged += new System.EventHandler(this.lsbSearchName_SelectedIndexChanged);
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(51, 5);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(132, 21);
            this.txtSearchName.TabIndex = 2;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            // 
            // txtExplain
            // 
            this.txtExplain.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExplain.Location = new System.Drawing.Point(189, 32);
            this.txtExplain.Multiline = true;
            this.txtExplain.Name = "txtExplain";
            this.txtExplain.ReadOnly = true;
            this.txtExplain.Size = new System.Drawing.Size(350, 172);
            this.txtExplain.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(287, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBind
            // 
            this.btnBind.Location = new System.Drawing.Point(364, 3);
            this.btnBind.Name = "btnBind";
            this.btnBind.Size = new System.Drawing.Size(52, 23);
            this.btnBind.TabIndex = 6;
            this.btnBind.Text = "刷新";
            this.btnBind.UseVisualStyleBackColor = true;
            this.btnBind.Click += new System.EventHandler(this.btnBind_Click);
            // 
            // ckbSetWindowPos
            // 
            this.ckbSetWindowPos.AutoSize = true;
            this.ckbSetWindowPos.Location = new System.Drawing.Point(233, 7);
            this.ckbSetWindowPos.Name = "ckbSetWindowPos";
            this.ckbSetWindowPos.Size = new System.Drawing.Size(48, 16);
            this.ckbSetWindowPos.TabIndex = 7;
            this.ckbSetWindowPos.Text = "前置";
            this.ckbSetWindowPos.UseVisualStyleBackColor = true;
            this.ckbSetWindowPos.CheckedChanged += new System.EventHandler(this.ckbSetWindowPos_CheckedChanged);
            // 
            // ckbSearchType
            // 
            this.ckbSearchType.AutoSize = true;
            this.ckbSearchType.Checked = true;
            this.ckbSearchType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbSearchType.Location = new System.Drawing.Point(4, 7);
            this.ckbSearchType.Name = "ckbSearchType";
            this.ckbSearchType.Size = new System.Drawing.Size(48, 16);
            this.ckbSearchType.TabIndex = 8;
            this.ckbSearchType.Text = "名称";
            this.ckbSearchType.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(437, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(68, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除选中";
            this.ttMain.SetToolTip(this.btnDelete, "删除只是将那行的数据清空，并不能真正删除该行");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Location = new System.Drawing.Point(516, 9);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(11, 12);
            this.lblAbout.TabIndex = 9;
            this.lblAbout.Text = "?";
            this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 208);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(541, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblMessage
            // 
            this.tsslblMessage.Name = "tsslblMessage";
            this.tsslblMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // FrmRegularyShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(541, 230);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.ckbSearchType);
            this.Controls.Add(this.ckbSetWindowPos);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnBind);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtExplain);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.lsbSearchName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRegularyShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "正则词典";
            this.Load += new System.EventHandler(this.RegularyShow_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbSearchName;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.TextBox txtExplain;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBind;
        private System.Windows.Forms.CheckBox ckbSetWindowPos;
        private System.Windows.Forms.CheckBox ckbSearchType;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblMessage;
    }
}

