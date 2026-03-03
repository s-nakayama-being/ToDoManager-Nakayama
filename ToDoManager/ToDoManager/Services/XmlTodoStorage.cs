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
        /// 指定されたファイルパスからToDoアイテムのリストを読込
        /// </summary>
        /// <param name="vFilePath">読込対象のファイルパス</param>
        /// <returns>読込んだToDoアイテムのコレクション</returns>
        /// <exception cref="FileNotFoundException">指定されたファイルが存在しない場合</exception>
        /// <exception cref="InvalidDataException">ファイルのデータ形式が不正な場合</exception>
        public IEnumerable<TodoItem> Load(string vFilePath) {
            if (!File.Exists(vFilePath)) throw new FileNotFoundException("指定されたファイルがみつかりません。");

            var wSerializer = new XmlSerializer(typeof(List<TodoItem>));

            try {
                using (var wStreamReader = new StreamReader(vFilePath)) {
                    return (List<TodoItem>)wSerializer.Deserialize(wStreamReader);
                }
            } catch (InvalidOperationException ex) {
                throw new InvalidDataException("ファイルのデータ形式が不正です。", ex);
            }
        }

        /// <summary>
        /// 指定されたToDoアイテムのコレクションをXML形式でファイルに保存
        /// </summary>
        /// <param name="vFilePath">保存対象のファイルパス</param>
        /// <param name="vItems">保存するToDoアイテムのコレクション</param>
        public void Save(string vFilePath, IEnumerable<TodoItem> vItems) {
            var wSerializer = new XmlSerializer(typeof(List<TodoItem>));

            using (var wWriter = new StreamWriter(vFilePath)) {
                wSerializer.Serialize(wWriter, vItems.ToList());
            }
        }
    }
}
