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
        /// <param name="vFilePath">読込対象のファイルパス</param>
        /// <returns>読込んだToDoアイテムのコレクション</returns>
        IEnumerable<TodoItem> Load(string vFilePath);

        /// <summary>
        /// ファイルにデータを保存
        /// </summary>
        /// <param name="vFilePath">保存対象のファイルパス</param>
        /// <param name="vItems">保存するToDoアイテムのコレクション</param>
        void Save(string vFilePath, IEnumerable<TodoItem> vItems);
    }
}
