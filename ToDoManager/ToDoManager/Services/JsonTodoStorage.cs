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
        public IEnumerable<TodoItem> Load(string vFilePath) {
            if (!File.Exists(vFilePath)) throw new FileNotFoundException("指定されたファイルが見つかりません");

            var wJsonString = File.ReadAllText(vFilePath);

            var wOptions = new JsonSerializerOptions {
                Converters = { new JsonStringEnumConverter() } // 優先度などのEnumを文字列としてシリアライズ/デシリアライズすることを想定
            };

            return JsonSerializer.Deserialize<List<TodoItem>>(wJsonString, wOptions);
        }

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
