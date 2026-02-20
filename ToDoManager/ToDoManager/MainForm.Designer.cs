namespace ToDoManager
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // コントロール宣言（F接頭辞＋パスカル型）
        private System.Windows.Forms.TextBox FTxtTitle;
        private System.Windows.Forms.TextBox FTxtContent;
        private System.Windows.Forms.DateTimePicker FDtpDueDate;
        private System.Windows.Forms.CheckBox FChkDone;
        private System.Windows.Forms.ListBox FLstItems;
        private System.Windows.Forms.Button FBtnAdd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByDueDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByAddedOrderToolStripMenuItem;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.FTxtTitle = new System.Windows.Forms.TextBox();
            this.FTxtContent = new System.Windows.Forms.TextBox();
            this.FDtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.FChkDone = new System.Windows.Forms.CheckBox();
            this.FLstItems = new System.Windows.Forms.ListBox();
            this.FBtnAdd = new System.Windows.Forms.Button();
            this.FTitleLabel = new System.Windows.Forms.Label();
            this.FContentLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByDueDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByAddedOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FBtnXmlLoad = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FTxtTitle
            // 
            this.FTxtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FTxtTitle.Location = new System.Drawing.Point(593, 158);
            this.FTxtTitle.Margin = new System.Windows.Forms.Padding(4);
            this.FTxtTitle.Name = "FTxtTitle";
            this.FTxtTitle.Size = new System.Drawing.Size(265, 22);
            this.FTxtTitle.TabIndex = 5;
            // 
            // FTxtContent
            // 
            this.FTxtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FTxtContent.Location = new System.Drawing.Point(593, 230);
            this.FTxtContent.Margin = new System.Windows.Forms.Padding(4);
            this.FTxtContent.Multiline = true;
            this.FTxtContent.Name = "FTxtContent";
            this.FTxtContent.Size = new System.Drawing.Size(265, 74);
            this.FTxtContent.TabIndex = 6;
            // 
            // FDtpDueDate
            // 
            this.FDtpDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FDtpDueDate.Location = new System.Drawing.Point(593, 316);
            this.FDtpDueDate.Margin = new System.Windows.Forms.Padding(4);
            this.FDtpDueDate.Name = "FDtpDueDate";
            this.FDtpDueDate.Size = new System.Drawing.Size(265, 22);
            this.FDtpDueDate.TabIndex = 7;
            // 
            // FChkDone
            // 
            this.FChkDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FChkDone.Location = new System.Drawing.Point(593, 348);
            this.FChkDone.Margin = new System.Windows.Forms.Padding(4);
            this.FChkDone.Name = "FChkDone";
            this.FChkDone.Size = new System.Drawing.Size(107, 24);
            this.FChkDone.TabIndex = 9;
            this.FChkDone.Text = "完了(F)";
            // 
            // FLstItems
            // 
            this.FLstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FLstItems.ItemHeight = 15;
            this.FLstItems.Location = new System.Drawing.Point(11, 69);
            this.FLstItems.Margin = new System.Windows.Forms.Padding(4);
            this.FLstItems.MinimumSize = new System.Drawing.Size(132, 249);
            this.FLstItems.Name = "FLstItems";
            this.FLstItems.Size = new System.Drawing.Size(548, 559);
            this.FLstItems.TabIndex = 1;
            // 
            // FBtnAdd
            // 
            this.FBtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnAdd.Location = new System.Drawing.Point(593, 72);
            this.FBtnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.FBtnAdd.Name = "FBtnAdd";
            this.FBtnAdd.Size = new System.Drawing.Size(75, 38);
            this.FBtnAdd.TabIndex = 2;
            this.FBtnAdd.Text = "追加(A)";
            this.FBtnAdd.UseVisualStyleBackColor = true;
            this.FBtnAdd.Click += new System.EventHandler(this.FBtnAdd_Click);
            // 
            // FTitleLabel
            // 
            this.FTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FTitleLabel.AutoSize = true;
            this.FTitleLabel.Location = new System.Drawing.Point(589, 130);
            this.FTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FTitleLabel.Name = "FTitleLabel";
            this.FTitleLabel.Size = new System.Drawing.Size(51, 15);
            this.FTitleLabel.TabIndex = 11;
            this.FTitleLabel.Text = "タイトル";
            // 
            // FContentLabel
            // 
            this.FContentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FContentLabel.AutoSize = true;
            this.FContentLabel.Location = new System.Drawing.Point(589, 202);
            this.FContentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FContentLabel.Name = "FContentLabel";
            this.FContentLabel.Size = new System.Drawing.Size(37, 15);
            this.FContentLabel.TabIndex = 12;
            this.FContentLabel.Text = "内容";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Lavender;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.fileToolStripMenuItem.Text = "ファイル";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.loadToolStripMenuItem.Text = "読込(&L)";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.FBtnXmlLoad_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "保存(S)";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.FBtnXml_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.editToolStripMenuItem.Text = "編集";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.addToolStripMenuItem.Text = "追加(A)";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.FBtnAdd_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByDueDateToolStripMenuItem,
            this.sortByAddedOrderToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem.Text = "表示";
            // 
            // sortByDueDateToolStripMenuItem
            // 
            this.sortByDueDateToolStripMenuItem.Name = "sortByDueDateToolStripMenuItem";
            this.sortByDueDateToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sortByDueDateToolStripMenuItem.Text = "期限順(O)";
            this.sortByDueDateToolStripMenuItem.Click += new System.EventHandler(this.SortByDueDateToolStripMenuItem_Click);
            // 
            // sortByAddedOrderToolStripMenuItem
            // 
            this.sortByAddedOrderToolStripMenuItem.Name = "sortByAddedOrderToolStripMenuItem";
            this.sortByAddedOrderToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sortByAddedOrderToolStripMenuItem.Text = "追加順(T)";
            this.sortByAddedOrderToolStripMenuItem.Click += new System.EventHandler(this.SortByAddedOrderToolStripMenuItem_Click);
            // 
            // FBtnXmlLoad
            // 
            this.FBtnXmlLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnXmlLoad.Location = new System.Drawing.Point(783, 590);
            this.FBtnXmlLoad.Margin = new System.Windows.Forms.Padding(4);
            this.FBtnXmlLoad.Name = "FBtnXmlLoad";
            this.FBtnXmlLoad.Size = new System.Drawing.Size(75, 38);
            this.FBtnXmlLoad.TabIndex = 13;
            this.FBtnXmlLoad.Text = "読込(&L)";
            this.FBtnXmlLoad.UseVisualStyleBackColor = true;
            this.FBtnXmlLoad.Click += new System.EventHandler(this.FBtnXmlLoad_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 672);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.FContentLabel);
            this.Controls.Add(this.FTitleLabel);
            this.Controls.Add(this.FTxtTitle);
            this.Controls.Add(this.FTxtContent);
            this.Controls.Add(this.FDtpDueDate);
            this.Controls.Add(this.FChkDone);
            this.Controls.Add(this.FLstItems);
            this.Controls.Add(this.FBtnXmlLoad);
            this.Controls.Add(this.FBtnAdd);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(590, 506);
            this.Name = "MainForm";
            this.Text = "ToDo管理";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FTitleLabel;
        private System.Windows.Forms.Label FContentLabel;
        private System.Windows.Forms.Button FBtnXmlLoad;
    }
}
