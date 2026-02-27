using System;

namespace ToDoManager.Models {
    /// <summary>
    /// ToDoアイテムに対するソートの種類と、ソートのロジックを定義するクラス
    /// </summary>
    public class SortStrategy {
        #region フィールド
        public static readonly SortStrategy FAddedOrder = new SortStrategy(x => x.Id);
        public static readonly SortStrategy FDueDate = new SortStrategy(x => x.DueDate);
        #endregion

        /// <summary>
        /// ソートのロジックを定義する。TodoItemを受け取り、ソートに使用する値を返す。
        /// </summary>
        public Func<TodoItem, object> SortFunction { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vKeySelector">ToDoアイテムを受け取り、ソートに使用する値を取得する処理（ラムダ式）</param>
        private SortStrategy(Func<TodoItem, object> vSortFunction) => SortFunction = vSortFunction;
    }
}
