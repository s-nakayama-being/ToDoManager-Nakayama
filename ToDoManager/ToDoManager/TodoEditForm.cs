using DevExpress.Utils.Internal;
using System;
using System.Windows.Forms;
using ToDoManager.Models;
using ToDoManager.Services;

namespace ToDoManager {
    /// <summary>
    /// ToDoアイテムの編集フォーム
    /// </summary>
    public partial class TodoEditForm : Form {
        #region フィールド・プロパティ

        /// <summary>
        /// 編集対象のToDoアイテムを取得
        /// </summary>
        public TodoItem Item { get; private set; }

        #endregion

        #region 初期化

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vItem">編集対象のToDoアイテム</param>
        public TodoEditForm(TodoItem vItem) {
            InitializeComponent();
            Item = vItem;
            FTxtTitle.Text = vItem.Title;
            FTxtContent.Text = vItem.Content;
            FDtpDueDate.Value = vItem.DueDate == default(DateTime) ? DateTime.Now : vItem.DueDate;
            FChkDone.Checked = vItem.IsCompleted;
            FCmbPriority.SelectedIndex = (int)vItem.Priority;
        }

        #endregion

        #region privateメソッド

        /// <summary>
        /// バリデーションを実行してToDoアイテムを保存する
        /// </summary>
        private void SaveItem() {
            try {
                Item.Title = FTxtTitle.Text;
                Item.Content = FTxtContent.Text;
                Item.DueDate = FDtpDueDate.Value;
                Item.IsCompleted = FChkDone.Checked;
                Item.Priority = (TodoPriorityEnum)FCmbPriority.SelectedIndex;

                TodoService.ValidateItem(Item.Title, Item.Content);

                DialogResult = DialogResult.OK;
                Close();
            } catch (ArgumentException ex) {
                MessageBox.Show(ex.Message, "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region イベントハンドラ

        private void FBtnSave_Click(object sender, EventArgs e) => SaveItem();
        protected override bool ProcessCmdKey(ref Message vMsg, Keys vKeyData) {
            if (vKeyData == Keys.Enter){
                switch (ActiveControl){
                    case ComboBox wCmb when wCmb == FCmbPriority:
                        wCmb.DroppedDown = !wCmb.DroppedDown;
                        return true;

                    case CheckBox wChk when wChk == FChkDone:
                        wChk.Checked = !wChk.Checked;
                        return true;
                }
            }

            return base.ProcessCmdKey(ref vMsg, vKeyData);
        }

        #endregion
    }
}
