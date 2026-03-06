using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoManager.Models {
    /// <summary>
    /// ToDoアイテムに対するソートの種類と、ソートのロジックを定義するクラス
    /// </summary>
    public class SortStrategy {
        #region フィールド

        /// <summary>
        /// 追加順のソート条件
        /// </summary>
        public static readonly SortStrategy C_AddedOrder = new SortStrategy(x => x.OrderBy(y => y.Id));

        /// <summary>
        /// 期限順のソート条件
        /// </summary>
        public static readonly SortStrategy C_DueDate = new SortStrategy(x => x.OrderBy(y => y.DueDate));

        #endregion

        /// <summary>
        /// ソート処理の実体を保持するデリゲート
        /// </summary>
        private readonly Func<IEnumerable<TodoItem>, IOrderedEnumerable<TodoItem>> FSortFunction;

        /// <summary>
        /// コンストラクタ
        /// </summary
        /// <param name="vSortFunction">適用するソート処理</param>
        private SortStrategy(Func<IEnumerable<TodoItem>, IOrderedEnumerable<TodoItem>> vSortFunction) => this.FSortFunction = vSortFunction;

        /// <summary>
        /// 指定されたToDoリストに対して、ソートを適用
        /// </summary>
        /// <param name="vItems">対象のToDoリスト</param>
        /// <returns>ソート済みのToDoリスト</returns>
        public IOrderedEnumerable<TodoItem> ApplySort(IEnumerable<TodoItem> vItems) => this.FSortFunction(vItems);

    }
}
