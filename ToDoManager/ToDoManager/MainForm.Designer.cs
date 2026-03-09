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
        private System.Windows.Forms.TextBox FTxtSearch;
        private System.Windows.Forms.DateTimePicker FDtpDueDate;
        private System.Windows.Forms.CheckBox FChkDone;
        private System.Windows.Forms.ListBox FLstItems;
        private System.Windows.Forms.Button FBtnAdd;
        private System.Windows.Forms.Button FBtnEdit;
        private System.Windows.Forms.Button FBtnDelete;
        private System.Windows.Forms.Button FBtnSearch;
        private System.Windows.Forms.Button FBtnClear;
        private System.Windows.Forms.Button FBtnLoad;
        private System.Windows.Forms.Label FTitleLabel;
        private System.Windows.Forms.Label FContentLabel;
        private System.Windows.Forms.Label FPriorityLabel;
        private System.Windows.Forms.ComboBox FCmbPriority;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
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
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByDueDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByAddedOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FBtnLoad = new System.Windows.Forms.Button();
            this.FBtnDelete = new System.Windows.Forms.Button();
            this.FBtnEdit = new System.Windows.Forms.Button();
            this.FTxtSearch = new System.Windows.Forms.TextBox();
            this.FBtnSearch = new System.Windows.Forms.Button();
            this.FBtnClear = new System.Windows.Forms.Button();
            this.FPriorityLabel = new System.Windows.Forms.Label();
            this.FCmbPriority = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FTxtTitle
            // 
            this.FTxtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FTxtTitle.Location = new System.Drawing.Point(445, 126);
            this.FTxtTitle.Name = "FTxtTitle";
            this.FTxtTitle.ReadOnly = true;
            this.FTxtTitle.Size = new System.Drawing.Size(200, 19);
            this.FTxtTitle.TabIndex = 9;
            // 
            // FTxtContent
            // 
            this.FTxtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FTxtContent.Location = new System.Drawing.Point(445, 184);
            this.FTxtContent.Multiline = true;
            this.FTxtContent.Name = "FTxtContent";
            this.FTxtContent.ReadOnly = true;
            this.FTxtContent.Size = new System.Drawing.Size(200, 60);
            this.FTxtContent.TabIndex = 11;
            // 
            // FDtpDueDate
            // 
            this.FDtpDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FDtpDueDate.Enabled = false;
            this.FDtpDueDate.Location = new System.Drawing.Point(445, 253);
            this.FDtpDueDate.Name = "FDtpDueDate";
            this.FDtpDueDate.Size = new System.Drawing.Size(200, 19);
            this.FDtpDueDate.TabIndex = 12;
            // 
            // FChkDone
            // 
            this.FChkDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FChkDone.Enabled = false;
            this.FChkDone.Location = new System.Drawing.Point(445, 278);
            this.FChkDone.Name = "FChkDone";
            this.FChkDone.Size = new System.Drawing.Size(80, 19);
            this.FChkDone.TabIndex = 13;
            this.FChkDone.Text = "完了(F)";
            // 
            // FLstItems
            // 
            this.FLstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FLstItems.ItemHeight = 12;
            this.FLstItems.Location = new System.Drawing.Point(8, 55);
            this.FLstItems.MinimumSize = new System.Drawing.Size(100, 200);
            this.FLstItems.Name = "FLstItems";
            this.FLstItems.Size = new System.Drawing.Size(412, 448);
            this.FLstItems.TabIndex = 4;
            this.FLstItems.SelectedIndexChanged += new System.EventHandler(this.FLstItems_SelectedIndexChanged);
            this.FLstItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FLstItems_MouseDown);
            // 
            // FBtnAdd
            // 
            this.FBtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnAdd.Location = new System.Drawing.Point(445, 58);
            this.FBtnAdd.Name = "FBtnAdd";
            this.FBtnAdd.Size = new System.Drawing.Size(56, 30);
            this.FBtnAdd.TabIndex = 5;
            this.FBtnAdd.Text = "追加(&A)";
            this.FBtnAdd.UseVisualStyleBackColor = true;
            this.FBtnAdd.Click += new System.EventHandler(this.FBtnAdd_Click);
            // 
            // FTitleLabel
            // 
            this.FTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FTitleLabel.AutoSize = true;
            this.FTitleLabel.Location = new System.Drawing.Point(442, 104);
            this.FTitleLabel.Name = "FTitleLabel";
            this.FTitleLabel.Size = new System.Drawing.Size(40, 12);
            this.FTitleLabel.TabIndex = 8;
            this.FTitleLabel.Text = "タイトル";
            // 
            // FContentLabel
            // 
            this.FContentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FContentLabel.AutoSize = true;
            this.FContentLabel.Location = new System.Drawing.Point(442, 162);
            this.FContentLabel.Name = "FContentLabel";
            this.FContentLabel.Size = new System.Drawing.Size(29, 12);
            this.FContentLabel.TabIndex = 10;
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
            this.menuStrip1.Size = new System.Drawing.Size(690, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "ファイル";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "読込(&L)";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.FBtnLoad_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "保存(&S)";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.FBtnXml_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.editEToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.editToolStripMenuItem.Text = "編集";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.addToolStripMenuItem.Text = "追加(&A)";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.FBtnAdd_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.deleteToolStripMenuItem.Text = "削除(&D)";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.FBtnDelete_Click);
            // 
            // editEToolStripMenuItem
            // 
            this.editEToolStripMenuItem.Name = "editEToolStripMenuItem";
            this.editEToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.editEToolStripMenuItem.Text = "編集(&E)";
            this.editEToolStripMenuItem.Click += new System.EventHandler(this.FBtnEdit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByDueDateToolStripMenuItem,
            this.sortByAddedOrderToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.viewToolStripMenuItem.Text = "表示";
            // 
            // sortByDueDateToolStripMenuItem
            // 
            this.sortByDueDateToolStripMenuItem.CheckOnClick = true;
            this.sortByDueDateToolStripMenuItem.Name = "sortByDueDateToolStripMenuItem";
            this.sortByDueDateToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.sortByDueDateToolStripMenuItem.Text = "期限順(&O)";
            this.sortByDueDateToolStripMenuItem.Click += new System.EventHandler(this.SortByDueDateToolStripMenuItem_Click);
            // 
            // sortByAddedOrderToolStripMenuItem
            // 
            this.sortByAddedOrderToolStripMenuItem.CheckOnClick = true;
            this.sortByAddedOrderToolStripMenuItem.Name = "sortByAddedOrderToolStripMenuItem";
            this.sortByAddedOrderToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.sortByAddedOrderToolStripMenuItem.Text = "追加順(&T)";
            this.sortByAddedOrderToolStripMenuItem.Click += new System.EventHandler(this.SortByAddedOrderToolStripMenuItem_Click);
            // 
            // FBtnLoad
            // 
            this.FBtnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnLoad.Location = new System.Drawing.Point(589, 473);
            this.FBtnLoad.Name = "FBtnLoad";
            this.FBtnLoad.Size = new System.Drawing.Size(56, 30);
            this.FBtnLoad.TabIndex = 16;
            this.FBtnLoad.Text = "読込(&L)";
            this.FBtnLoad.UseVisualStyleBackColor = true;
            this.FBtnLoad.Click += new System.EventHandler(this.FBtnLoad_Click);
            // 
            // FBtnDelete
            // 
            this.FBtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnDelete.Location = new System.Drawing.Point(516, 58);
            this.FBtnDelete.Name = "FBtnDelete";
            this.FBtnDelete.Size = new System.Drawing.Size(56, 30);
            this.FBtnDelete.TabIndex = 6;
            this.FBtnDelete.Text = "削除(&D)";
            this.FBtnDelete.UseVisualStyleBackColor = true;
            this.FBtnDelete.Click += new System.EventHandler(this.FBtnDelete_Click);
            // 
            // FBtnEdit
            // 
            this.FBtnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnEdit.Location = new System.Drawing.Point(587, 58);
            this.FBtnEdit.Name = "FBtnEdit";
            this.FBtnEdit.Size = new System.Drawing.Size(56, 30);
            this.FBtnEdit.TabIndex = 7;
            this.FBtnEdit.Text = "編集(&E)";
            this.FBtnEdit.UseVisualStyleBackColor = true;
            this.FBtnEdit.Click += new System.EventHandler(this.FBtnEdit_Click);
            // 
            // FTxtSearch
            // 
            this.FTxtSearch.Location = new System.Drawing.Point(9, 30);
            this.FTxtSearch.Name = "FTxtSearch";
            this.FTxtSearch.Size = new System.Drawing.Size(132, 19);
            this.FTxtSearch.TabIndex = 1;
            this.FTxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FTxtSearch_KeyDown);
            // 
            // FBtnSearch
            // 
            this.FBtnSearch.Location = new System.Drawing.Point(144, 30);
            this.FBtnSearch.Name = "FBtnSearch";
            this.FBtnSearch.Size = new System.Drawing.Size(59, 19);
            this.FBtnSearch.TabIndex = 2;
            this.FBtnSearch.Text = "検索(&H)";
            this.FBtnSearch.UseVisualStyleBackColor = true;
            this.FBtnSearch.Click += new System.EventHandler(this.FBtnSearch_Click);
            // 
            // FBtnClear
            // 
            this.FBtnClear.Location = new System.Drawing.Point(208, 30);
            this.FBtnClear.Name = "FBtnClear";
            this.FBtnClear.Size = new System.Drawing.Size(59, 19);
            this.FBtnClear.TabIndex = 3;
            this.FBtnClear.Text = "クリア(&C)";
            this.FBtnClear.UseVisualStyleBackColor = true;
            this.FBtnClear.Click += new System.EventHandler(this.FBtnClear_Click);
            // 
            // FPriorityLabel
            // 
            this.FPriorityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FPriorityLabel.AutoSize = true;
            this.FPriorityLabel.Location = new System.Drawing.Point(442, 312);
            this.FPriorityLabel.Name = "FPriorityLabel";
            this.FPriorityLabel.Size = new System.Drawing.Size(41, 12);
            this.FPriorityLabel.TabIndex = 14;
            this.FPriorityLabel.Text = "優先度";
            // 
            // FCmbPriority
            // 
            this.FCmbPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FCmbPriority.Enabled = false;
            this.FCmbPriority.FormattingEnabled = true;
            this.FCmbPriority.Items.AddRange(new object[] {
            "高",
            "中",
            "低"});
            this.FCmbPriority.Location = new System.Drawing.Point(444, 327);
            this.FCmbPriority.Name = "FCmbPriority";
            this.FCmbPriority.Size = new System.Drawing.Size(200, 20);
            this.FCmbPriority.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 538);
            this.Controls.Add(this.FCmbPriority);
            this.Controls.Add(this.FPriorityLabel);
            this.Controls.Add(this.FBtnClear);
            this.Controls.Add(this.FBtnSearch);
            this.Controls.Add(this.FTxtSearch);
            this.Controls.Add(this.FBtnEdit);
            this.Controls.Add(this.FBtnDelete);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.FContentLabel);
            this.Controls.Add(this.FTitleLabel);
            this.Controls.Add(this.FTxtTitle);
            this.Controls.Add(this.FTxtContent);
            this.Controls.Add(this.FDtpDueDate);
            this.Controls.Add(this.FChkDone);
            this.Controls.Add(this.FLstItems);
            this.Controls.Add(this.FBtnLoad);
            this.Controls.Add(this.FBtnAdd);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(447, 414);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ToDo管理";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
