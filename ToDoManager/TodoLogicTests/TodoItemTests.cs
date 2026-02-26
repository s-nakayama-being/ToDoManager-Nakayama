using NUnit.Framework;
using ToDoManager.Models;

namespace ToDoManagerTests {
    /// <summary>
    /// TodoItemの単体テストクラス
    /// </summary>
    [TestFixture]
    public class TodoItemTests {
        /// <summary>
        /// ToStringが完了状態に応じたフォーマットを返すこと
        /// </summary>
        /// <param name="vIsCompleted">完了フラグ</param>
        /// <param name="vExpected">期待される文字列</param>
        [TestCase(true, "[完了] Test")]
        [TestCase(false, "[未] Test")]
        public void ToString_フォーマットの確認(bool vIsCompleted, string vExpected) {
            var wItem = new TodoItem { Title = "Test", IsCompleted = vIsCompleted };

            var wResult = wItem.ToString();

            Assert.That(wResult, Is.EqualTo(vExpected));
        }
    }
}
