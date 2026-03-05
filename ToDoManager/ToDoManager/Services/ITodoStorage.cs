using System.Collections.Generic;
using ToDoManager.Models;

namespace ToDoManager.Services {
    /// <summary>
    /// ToDoアイテムの保存・読込処理を定義するインターフェース
    /// </summary>
    public interface ITodoStorage {
        /// <summary>
        /// ファイルからデータを読込
        /// </summary>
        /// <param name="vFilePath">読込先のファイルパス</param>
        /// <returns>読み込まれたToDoアイテムの一覧</returns>
        IEnumerable<TodoItem> Load(string vFilePath);

        /// <summary>
        /// ファイルにデータを保存
        /// </summary>
        /// <param name="vFilePath">保存先のファイルパス</param>
        /// <param name="vItems">保存するToDoアイテムの一覧</param>
        void Save(string vFilePath, IEnumerable<TodoItem> vItems);
    }
}
