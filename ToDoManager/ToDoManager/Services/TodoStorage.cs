using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace ToDoManager.Services {
    /// <summary>
    /// ToDoアイテムの保存形式の登録管理と、適切なインスタンスの生成を担うクラス
    /// </summary>
    public class TodoStorage {
        /// <summary>
        /// 拡張子と、それに対応するストレージインスタンス生成ロジックのマッピングを保持
        /// </summary>
        private static readonly ConcurrentDictionary<string, Func<ITodoStorage>> C_Registry = new ConcurrentDictionary<string, Func<ITodoStorage>>();

        /// <summary>
        /// 特定の拡張子に対応するストレージ生成ロジックを登録
        /// </summary>
        /// <param name="vExtension">登録対象の拡張子</param>
        /// <param name="vFactory">対応するクラスのインスタンス</param>
        public static void Register(string vExtension, Func<ITodoStorage> vFactory) => C_Registry[vExtension] = vFactory;

        /// <summary>
        /// ファイル選択ダイアログで使用可能なフィルターの文字列を生成
        /// </summary>
        /// <returns>フィルター文字列</returns>
        public static string GetFilter() {
            var wFilter = new List<string>();
            foreach (var wKey in C_Registry.Keys) {
                var wDescription = wKey.Substring(1).ToUpper();
                wFilter.Add($"{wDescription}ファイル (*{wKey})|*{wKey}");
            }

            wFilter.Add("すべてのファイル(*.*)|*.*");
            return string.Join("|", wFilter);
        }

        /// <summary>
        /// 拡張子に基づいてインスタンスを生成
        /// </summary>
        /// <param name="vFilePath">指定されたファイルパス</param>
        /// <returns>生成された各拡張子のインスタンス</returns>
        /// <exception cref="NotSupportedException">サポートされていないファイルの場合</exception>
        public static ITodoStorage Create(string vFilePath) {
            var wExtension = Path.GetExtension(vFilePath)?.ToLower();

            if (!string.IsNullOrWhiteSpace(wExtension) && C_Registry.TryGetValue(wExtension, out var wFactory)) {
                return wFactory();
            }

            throw new NotSupportedException($"サポートされていないファイルです: {wExtension}");
        }
    }
}
