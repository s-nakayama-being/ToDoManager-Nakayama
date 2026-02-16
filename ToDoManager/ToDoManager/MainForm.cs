using System;
using System.Drawing;
using System.Windows.Forms;
using ToDoManager.Models;
using ToDoManager.Services;

namespace ToDoManager {
    /// <summary>
    /// メインのToDo管理フォーム
    /// </summary>
    public partial class MainForm : Form {
        #region フィールド・初期化
        private readonly TodoService FService = new TodoService();
              
        public MainForm() {
            InitializeComponent();

            InitializeDetailArea();

            UpdateList();
        }
        #endregion

        #region UI操作
        /// <summary>
        /// 詳細表示エリアのコントロールを初期化
        /// </summary>
        private void InitializeDetailArea() {
            FTxtTitle.ReadOnly = true;
            FTxtContent.ReadOnly = true;
            FDtpDueDate.Enabled = false;
            FChkDone.Enabled = false;
        }

        /// <summary>
        /// ToDoリストを更新
        /// </summary>
        private void UpdateList() {
            FLstItems.Items.Clear();
            foreach (var wItem in FService.GetItems()) FLstItems.Items.Add(wItem);
        }
        #endregion

        #region ToDo操作
        /// <summary>
        /// 追加アイテムを処理
        /// </summary>
        private void AddItem() {
            using (var wForm = new TodoEditForm(new TodoItem())) {
                if (wForm.ShowDialog() == DialogResult.OK) {
                    try {
                        FService.AddOrUpdate(wForm.Item);
                        UpdateList();
                    } catch (ArgumentException wEx) {
                        MessageBox.Show(this, wEx.Message, "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } catch (Exception wEx) {
                        MessageBox.Show(this, $"保存に失敗しました：{wEx.Message}", "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// アイテムを編集
        /// </summary>
        private void EditItem() {
            if (FLstItems.SelectedItem is TodoItem wSelected) {
                using (var wForm = new TodoEditForm(wSelected)) {
                    if (wForm.ShowDialog() == DialogResult.OK) {
                        FService.AddOrUpdate(wForm.Item);
                        UpdateList();
                    }
                }
            }
        }

        /// <summary>
        /// 選択されたアイテムの詳細を表示する
        /// </summary>
        /// <param name="vItem">表示対象のアイテム</param>
        private void DisplaySelectedItemDetails(TodoItem vItem) {
            FTxtTitle.Text = vItem.Title;
            FTxtTitle.BackColor = SystemColors.Control;
            FTxtContent.Text = vItem.Content;
            FDtpDueDate.Text = vItem.DueDate.ToString("yyyy/M/d");

            if (FChkDone is CheckBox wChk) wChk.Checked = vItem.IsCompleted;

            if (!vItem.IsCompleted && vItem.DueDate<DateTime.Today) FTxtTitle.BackColor = Color.Yellow;
        }

        /// <summary>
        /// 詳細表示エリアをクリアする
        /// </summary>
        private void ClearDetailDisplay() {
            FTxtTitle.Text = string.Empty;
            FTxtContent.Text = string.Empty;
            FDtpDueDate.Text = string.Empty;

            if (FChkDone is CheckBox wChk) wChk.Checked = false;

            FTxtTitle.BackColor = SystemColors.Control;
        }
        #endregion

        #region イベントハンドラ
        private void FBtnAdd_Click(object sender, EventArgs e) => AddItem();
        private void FBtnEdit_Click(object sender, EventArgs e) => EditItem();
        private void FBtnXml_Click(object sender, EventArgs e) => FService.Export();
        private void SortByDueDateToolStripMenuItem_Click(object sender, EventArgs e) => FService.SortByDueDate();
        private void SortByAddedOrderToolStripMenuItem_Click(object sender, EventArgs e) => FService.SortByAddedOrder();
        private void FBtnXmlLoad_Click(object sender, EventArgs e) {
            if (FService.Import()) {
                UpdateList();
                MessageBox.Show(this, "データを読み込みました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                MessageBox.Show(this, "指定ファイルが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FLstItems_SelectedIndexChanged(object sender, EventArgs e) {
            if (FLstItems.SelectedItem is TodoItem wSelectedItem) {
                DisplaySelectedItemDetails(wSelectedItem);
            } else {
                ClearDetailDisplay();
            }
        }
        private void FLstItems_MouseDown(object sender, MouseEventArgs e) {
            int wIndex = FLstItems.IndexFromPoint(e.Location);

            if (wIndex == ListBox.NoMatches) FLstItems.SelectedIndex = -1;
        }
        #endregion
    }
}
