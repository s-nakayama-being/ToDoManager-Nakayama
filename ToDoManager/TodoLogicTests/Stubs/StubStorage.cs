using System.Collections.Generic;
using System.Linq;
using ToDoManager.Models;
using ToDoManager.Services;

namespace ToDoManagerTests.Stubs {
    /// <summary>
    /// 単体テスト用のデータの保存・読込クラス
    /// </summary>
    internal class StubStorage : ITodoStorage {
        /// <summary>
        /// 保存メソッドが呼ばれた際に、引数として渡されたアイテムの一覧を保持
        /// </summary>
        public List<TodoItem> SavedItems { get; private set; }

        /// <summary>
        /// ファイルを読込を行わず、あらかじめ用意したテスト用のデータを返す
        /// </summary>
        /// <param name="vFilePath">読込元のファイルパス</param>
        /// <returns>テスト用のToDoアイテム一覧</returns>
        public IEnumerable<TodoItem> Load(string vFilePath) => new List<TodoItem>() {
                new TodoItem { Id = 55, Title = "Test", Content = "Test Content" }
            };

        /// <summary>
        /// 実際のファイル保存は行わず、渡されたデータを保存アイテムのプロパティとして記録
        /// </summary>
        /// <param name="vFilePath">保存先のファイルパス</param>
        /// <param name="vItems">保全対象のデータ</param>
        public void Save(string vFilePath, IEnumerable<TodoItem> vItems) => SavedItems = vItems.ToList();
    }
}
