using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ToDoManager.Models;

namespace ToDoManager.Services {
    /// <summary>
    /// XML形式でToDoアイテムの保存・読込処理を行うクラス
    /// </summary>
    public class XmlTodoStorage : ITodoStorage {
        /// <summary>
        /// XML形式のファイルからToDoリストを復元
        /// </summary>
        /// <param name="vFilePath">読込先のファイルパス</param>
        /// <returns>読み込まれたToDoアイテムの一覧</returns>
        /// <exception cref="FileNotFoundException">指定されたファイルが存在しない場合</exception>
        /// <exception cref="InvalidDataException">ファイルのデータ形式が不正な場合</exception>
        public IEnumerable<TodoItem> Load(string vFilePath) {
            if (!File.Exists(vFilePath)) throw new FileNotFoundException("指定されたファイルがみつかりません。");

            var wSerializer = new XmlSerializer(typeof(List<TodoItem>));

            try {
                using (var wStreamReader = new StreamReader(vFilePath)) {
                    return (List<TodoItem>)wSerializer.Deserialize(wStreamReader) ?? new List<TodoItem>();
                }
            } catch (Exception ex) {
                throw new InvalidDataException($"ファイルのデータ形式が不正です: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// ToDoリストをXML形式ファイルとして保存
        /// </summary>
        /// <param name="vFilePath">保存先のファイルパス</param>
        /// <param name="vItems">保存するToDoアイテムの一覧</param>
        public void Save(string vFilePath, IEnumerable<TodoItem> vItems) {
            var wSerializer = new XmlSerializer(typeof(List<TodoItem>));

            using (var wWriter = new StreamWriter(vFilePath)) {
                wSerializer.Serialize(wWriter, vItems.ToList());
            }
        }
    }
}
