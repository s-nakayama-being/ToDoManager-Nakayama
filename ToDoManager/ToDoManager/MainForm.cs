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

        private readonly TodoService FService;

        public MainForm() {
            InitializeComponent();

            TodoStorage.Register(".json", () => new JsonTodoStorage());
            TodoStorage.Register(".xml", () => new XmlTodoStorage());

            FService = new TodoService(TodoStorage.Create);

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
            var wSearchedItems = FService.SearchByTitle(FTxtSearch.Text);

            // 今後、#602534で実装されたソート機能をこの行に追加することを想定

            UpdateList(wSearchedItems);
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
                    } catch (ArgumentException ex) {
                        MessageBox.Show(this, ex.Message, "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } catch (Exception ex) {
                        MessageBox.Show(this, $"保存に失敗しました：{ex.Message}", "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        } catch (Exception ex) {
                            MessageBox.Show(this, $"保存に失敗しました：{ex.Message}", "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void FBtnSave_Click(object sender, EventArgs e) {
            using (var wDialog = new SaveFileDialog()) {
                wDialog.Filter = FService.FileFilter;

                if (wDialog.ShowDialog() == DialogResult.OK) {
                    try {
                        FService.Export(wDialog.FileName);
                        MessageBox.Show(this, "データを保存しました", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show(this, $"データの保存に失敗しました：{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void FBtnLoad_Click(object sender, EventArgs e) {
            using (var wDialog = new OpenFileDialog()) {
                wDialog.Filter = FService.FileFilter;

                if (wDialog.ShowDialog() == DialogResult.OK) {
                    try {
                        FService.Import(wDialog.FileName);
                        RefreshList();
                        MessageBox.Show(this, "データを読み込みました", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show(this, $"データの読み込みに失敗しました：{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void SortByDueDateToolStripMenuItem_Click(object sender, EventArgs e) => FService.SortByDueDate();
        private void SortByAddedOrderToolStripMenuItem_Click(object sender, EventArgs e) => FService.SortByAddedOrder();

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