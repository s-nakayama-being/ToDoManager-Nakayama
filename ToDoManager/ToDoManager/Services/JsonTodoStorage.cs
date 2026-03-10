using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using ToDoManager.Models;

namespace ToDoManager.Services {
    /// <summary>
    /// JSON形式でToDoアイテムの保存・読込処理を行うクラス
    /// </summary>
    public class JsonTodoStorage : ITodoStorage {
        /// <summary>
        /// JSON形式のファイルからToDoリストを復元
        /// </summary>
        /// <param name="vFilePath">読込先のファイルパス</param>
        /// <returns>読み込まれたToDoアイテムの一覧</returns>
        /// <exception cref="FileNotFoundException">指定されたファイルが存在しない場合</exception>
        public IEnumerable<TodoItem> Load(string vFilePath) {
            if (!File.Exists(vFilePath)) throw new FileNotFoundException("指定されたファイルが見つかりません");

            try {
                var wJsonString = File.ReadAllText(vFilePath);

                var wOptions = new JsonSerializerOptions {
                    Converters = { new JsonStringEnumConverter() } // 優先度などのEnumを文字列としてシリアライズ/デシリアライズすることを想定
                };

                return JsonSerializer.Deserialize<List<TodoItem>>(wJsonString, wOptions) ?? new List<TodoItem>();
            } catch (Exception ex) {
                throw new InvalidDataException($"ファイルのデータ形式が不正です: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// ToDoリストをJSON形式ファイルとして保存
        /// </summary>
        /// <param name="vFilePath">保存先のファイルパス</param>
        /// <param name="vItems">保存するToDoアイテムの一覧</param>
        public void Save(string vFilePath, IEnumerable<TodoItem> vItems) {
            var wOptions = new JsonSerializerOptions {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };

            string wJsonString = JsonSerializer.Serialize(vItems, wOptions);
            File.WriteAllText(vFilePath, wJsonString);
        }
    }
}
