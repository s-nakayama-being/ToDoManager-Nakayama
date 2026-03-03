using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ToDoManager.Models;

namespace ToDoManager.Services {
    /// <summary>
    /// ToDoアイテムの管理や永続化を行うサービスクラス
    /// </summary>
    public class TodoService {
        #region フィールド

        private List<TodoItem> FItems = new List<TodoItem>();
        private int FNextId = 1;
        public const string C_ExtJson = ".json";
        public const string C_ExtXml = ".xml";
        private readonly Dictionary<string, Func<ITodoStorage>> FStorageFactories;

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TodoService() {
            FStorageFactories = new Dictionary<string, Func<ITodoStorage>>(StringComparer.OrdinalIgnoreCase) {
                { C_ExtJson, () => new JsonTodoStorage() },
                { C_ExtXml, () => new XmlTodoStorage() }
            };

            FItems = new List<TodoItem>();
        }

        #region publicメソッド

        /// <summary>
        /// ToDoアイテムの一覧を取得する
        /// </summary>
        /// <returns>登録されているToDoアイテムの読み取り専用リスト</returns>
        public IReadOnlyList<TodoItem> GetItems() {
            return FItems;
        }

        /// <summary>
        /// ToDoアイテムの入力値を検証する
        /// </summary>
        /// <param name="vTitle">タイトル</param>
        /// <param name="vContent">内容</param>
        /// <exception cref="ArgumentException">バリデーションエラー時</exception>
        public static void ValidateItem(string vTitle, string vContent) {
            if (string.IsNullOrWhiteSpace(vTitle)) throw new ArgumentException("タイトルを入力してください。");

            if (vTitle.Length > 20) throw new ArgumentException($"タイトルは20文字以内で入力してください。現在の文字数:{vTitle.Length}");

            if (vContent != null && vContent.Length > 150) throw new ArgumentException($"内容は150文字以内で入力してください。現在の文字数:{vContent.Length}");
        }

        /// <summary>
        /// ToDoアイテムを追加または更新
        /// </summary>
        /// <param name="vItem">追加または更新するToDoアイテム</param>
        public void AddOrUpdate(TodoItem vItem) {
            if (vItem == null) throw new ArgumentNullException(nameof(vItem));

            if (vItem.Id == 0) {
                Add(vItem);
            } else {
                Update(vItem);
            }
        }

        /// <summary>
        /// 指定したToDoアイテムを削除
        /// </summary>
        /// <param name="vId">削除対象のID</param>
        public void Delete(int vId) {
            var wItem = FItems.FirstOrDefault(x => x.Id == vId);

            if (wItem != null) FItems.Remove(wItem);
        }

        /// <summary>
        /// 新しいToDoアイテムをコレクションに追加
        /// </summary>
        /// <param name="vItem">ToDoアイテム</param>
        private void Add(TodoItem vItem) {
            vItem.Id = FNextId++;
            FItems.Add(vItem);
        }

        /// <summary>
        /// 既存のToDoアイテムの内容を更新
        /// </summary>
        /// <param name="vItem">ToDoアイテム</param>
        private void Update(TodoItem vItem) {
            TodoItem wExisting = FItems.FirstOrDefault(x => x.Id == vItem.Id);
            if (wExisting == null) throw new InvalidOperationException("更新対象のToDoが存在しません。");

            wExisting.Title = vItem.Title;
            wExisting.Content = vItem.Content;
            wExisting.DueDate = vItem.DueDate;
            wExisting.IsCompleted = vItem.IsCompleted;
        }

        private ITodoStorage GetStorage(string vFilePath) {
            string wExtension = Path.GetExtension(vFilePath);

            if (wExtension != null && FStorageFactories.TryGetValue(wExtension, out var wFactory)) wFactory();

            throw new NotSupportedException("サポートされていないファイル形式です");
        }

        /// <summary>
        /// ToDoアイテムを任意のファイルで保存
        /// </summary>
        public void Export(string vFilePath) {
            if (string.IsNullOrWhiteSpace(vFilePath)) throw new ArgumentException("ファイルパスが指定されていません。");

            ITodoStorage wStorage = GetStorage(vFilePath);
            wStorage.Save(vFilePath, FItems);
        }

        /// <summary>
        /// 任意のファイルからToDoアイテムを読込
        /// </summary>
        public void Import(string vFilePath) {
            if (string.IsNullOrWhiteSpace(vFilePath)) throw new ArgumentException("ファイルパスが指定されていません。");
            if (!File.Exists(vFilePath)) throw new FileNotFoundException("指定されたファイルが存在しません。");

            ITodoStorage wStorage = GetStorage(vFilePath);
            var wLoadedItems = wStorage.Load(vFilePath);

            FItems = wLoadedItems.ToList();
            FNextId = FItems.Any() ? FItems.Max(x => x.Id) + 1 : 1;
        }

        /// <summary>
        /// 期限順にソート
        /// </summary>
        public void SortByDueDate() {
            var wTodoItems = FItems.OrderBy(x => x.DueDate).ToList();
        }

        /// <summary>
        /// 追加順にソート
        /// </summary>
        public void SortByAddedOrder() {
            for (int i = 0; i < FItems.Count - 1; i++) {
                int wMinIndex = i;
                for (int j = i + 1; j < FItems.Count; j++) {
                    if (FItems[j].Id < FItems[wMinIndex].Id) {
                        wMinIndex = j;
                    }
                }
                if (wMinIndex != i) {
                    var wTemp = FItems[i];
                    FItems[i] = FItems[wMinIndex];
                    FItems[wMinIndex] = wTemp;
                }
            }
        }

        /// <summary>
        /// タイトルの部分一致で検索
        /// </summary>
        /// <param name="vKeyword">検索キーワード</param>
        public IEnumerable<TodoItem> SearchByTitle(string vKeyword) {
            if (string.IsNullOrWhiteSpace(vKeyword)) return FItems;

            var wCompareInfo = CultureInfo.CurrentCulture.CompareInfo;

            return FItems.Where(x => wCompareInfo.IndexOf(x.Title, vKeyword, CompareOptions.IgnoreCase | CompareOptions.IgnoreWidth) >= 0);
        }

        #endregion
    }
}
