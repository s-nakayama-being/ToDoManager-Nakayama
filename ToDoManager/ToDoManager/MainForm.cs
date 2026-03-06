using System;
using System.Collections.Generic;
using System.Linq;
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

        private SortStrategy FCurrentSort = SortStrategy.C_AddedOrder;

        public MainForm() {
            InitializeComponent();

            RefreshList();
        }

        #endregion

        #region UI操作

        /// <summary>
        /// ToDoリストを更新
        /// </summary>
        private void UpdateList(IEnumerable<TodoItem> vItems) {
            FLstItems.Items.Clear();

            FLstItems.Items.AddRange(vItems.ToArray());
        }

        /// <summary>
        /// 指定された条件を適用して画面を再描画
        /// </summary>
        private void RefreshList() {
            FService.SortItems(FCurrentSort);

            var wSearchedItems = FService.SearchByTitle(FTxtSearch.Text);

            UpdateList(wSearchedItems);
        }

        /// <summary>
        /// ソートメニューの状態を更新
        /// </summary>
        /// <param name="vSortType"></param>
        private void UpdateSortMenuState() {
            sortByDueDateToolStripMenuItem.Checked = (FCurrentSort == SortStrategy.C_DueDate);
            sortByAddedOrderToolStripMenuItem.Checked = (FCurrentSort == SortStrategy.C_AddedOrder);
        }

        /// <summary>
        /// 指定されたソートを適用し、ToDoリストを更新
        /// </summary>
        /// <param name="vSortType">ソートの種類</param>
        private void ApplySort(SortStrategy vSortType) {
            if (FCurrentSort == vSortType) return;

            FCurrentSort = vSortType;

            RefreshList();
            UpdateSortMenuState();
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
                        RefreshList();
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
                        try {
                            FService.AddOrUpdate(wForm.Item);
                            RefreshList();
                        } catch (Exception wEx) {
                            MessageBox.Show(this, $"保存に失敗しました：{wEx.Message}", "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// アイテムを削除
        /// </summary>
        private void DeleteItem() {
            if (!(FLstItems.SelectedItem is TodoItem wSelectedItem)) {
                MessageBox.Show("削除する項目を選択してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var wResult = MessageBox.Show($"「{wSelectedItem.Title}」を削除してもよろしいですか？", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (wResult != DialogResult.OK) return;

            FService.Delete(wSelectedItem.Id);

            RefreshList();
        }

        #endregion

        #region イベントハンドラ

        private void FBtnAdd_Click(object sender, EventArgs e) => AddItem();
        private void FBtnEdit_Click(object sender, EventArgs e) => EditItem();
        private void FBtnDelete_Click(object sender, EventArgs e) => DeleteItem();
        private void FBtnXml_Click(object sender, EventArgs e) => FService.Export();
        private void SortByDueDateToolStripMenuItem_Click(object sender, EventArgs e) => ApplySort(SortStrategy.C_DueDate);
        private void SortByAddedOrderToolStripMenuItem_Click(object sender, EventArgs e) => ApplySort(SortStrategy.C_AddedOrder);
        private void FBtnLoad_Click(object sender, EventArgs e) {
            if (FService.Import()) {
                RefreshList();
                MessageBox.Show(this, "データを読み込みました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                MessageBox.Show(this, "指定ファイルが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FBtnSearch_Click(object sender, EventArgs e) => RefreshList();
        private void FTxtSearch_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
                RefreshList();
            }
        }
        private void FBtnClear_Click(object sender, EventArgs e) {
            FTxtSearch.Clear();
            RefreshList();
        }

        #endregion
    }
}
