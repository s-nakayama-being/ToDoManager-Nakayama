using System;
using System.Xml.Serialization;

namespace ToDoManager.Models {
    /// <summary>
    /// 優先度を表す列挙型
    /// </summary>
    public enum TodoPriorityEnum {
        // 数字は今後の優先度ソート機能の実装を見据えて記載している
        High = 0,
        Medium = 1,
        Low = 2
    }

    /// <summary>
    /// ToDoアイテムのエンティティクラス
    /// </summary>
    [Serializable]
    public class TodoItem {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// タイトル
        /// </summary>
        [XmlElement("Title")]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [XmlElement("Content")]
        public string Content { get; set; }

        /// <summary>
        /// 期限日
        /// </summary>
        [XmlElement("DueDate")]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// 完了フラグ
        /// </summary>
        [XmlElement("IsCompleted")]
        public bool IsCompleted { get; set; }

        /// <summary>
        /// 優先度（デフォルトはMedium）
        /// </summary>
        [XmlElement("Priority")]
        public TodoPriorityEnum Priority { get; set; } = TodoPriorityEnum.Medium;

        /// <summary>
        /// タイトルと完了状態を表す文字列を返します。
        /// </summary>
        /// <returns>表示用文字列</returns>
        public override string ToString() => $"[{(IsCompleted ? "完了" : "未")}] {Title}";
    }
}
