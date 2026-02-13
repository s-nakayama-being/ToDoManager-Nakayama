using System;
using System.Linq;
using NUnit.Framework;
using ToDoManager.Models;
using ToDoManager.Services;

namespace ToDoManagerTests {
    /// <summary>
    /// TodoServiceの単体テストクラス
    /// </summary>
    [TestFixture]
    public class TodoServiceTests {
        /// <summary>
        /// AddOrUpdateで新規アイテムが追加されること
        /// </summary>
        [Test]
        public void AddOrUpdate_ToDoの追加() {
            var wService = new TodoService();
            var wItem = new TodoItem { Title = "Test", Content = "TestContent", DueDate = DateTime.Today, IsCompleted = false };
            wService.AddOrUpdate(wItem);
            var wItems = wService.GetItems().ToList();
            Assert.AreEqual(1, wItems.Count);
            Assert.AreEqual("Test", wItems[0].Title);
        }

        /// <summary>
        /// AddOrUpdateで既存アイテムが更新されること
        /// </summary>
        [Test]
        public void AddOrUpdate_ToDoの更新() {
            var wService = new TodoService();
            var wItem = new TodoItem { Title = "Test", Content = "TestContent", DueDate = DateTime.Today, IsCompleted = false };
            wService.AddOrUpdate(wItem);
            wItem.Title = "Updated";
            wService.AddOrUpdate(wItem);
            var wItems = wService.GetItems().ToList();
            Assert.AreEqual(1, wItems.Count);
            Assert.AreEqual("Updated", wItems[0].Title);
        }

        /// <summary>
        /// SortByDueDateで期限順にソートされること
        /// </summary>
        [Test]
        public void SortByDueDate_期限順ソート() {
            var wService = new TodoService();
            var wItem1 = new TodoItem { Title = "Test1", DueDate = DateTime.Today.AddDays(1) };
            var wItem2 = new TodoItem { Title = "Test2", DueDate = DateTime.Today };
            wService.AddOrUpdate(wItem1);
            wService.AddOrUpdate(wItem2);

            wService.SortByDueDate();
            var wItems = wService.GetItems().ToList();

            Assert.AreEqual("Test2", wItems[0].Title);
            Assert.AreEqual("Test1", wItems[1].Title);
        }

        /// <summary>
        /// SortByAddedOrderで追加順にソートされること
        /// </summary>
        [Test]
        public void SortByAddedOrder_追加順ソート() {
            var wService = new TodoService();
            var wItem1 = new TodoItem { Title = "Test1", DueDate = DateTime.Today.AddDays(1) };
            var wItem2 = new TodoItem { Title = "Test2", DueDate = DateTime.Today };
            wService.AddOrUpdate(wItem1);
            wService.AddOrUpdate(wItem2);

            wService.SortByAddedOrder();
            var wItems = wService.GetItems().ToList();

            Assert.AreEqual("Test1", wItems[0].Title);
            Assert.AreEqual("Test2", wItems[1].Title);
        }

        #region バリデーションテスト

        [TestCase("", "内容", "タイトルを入力してください")]
        [TestCase("   ", "内容", "タイトルを入力してください")]
        [TestCase(null, "内容", "タイトルを入力してください")]
        public void ValidateItemはタイトルが無効な場合に例外をスローする(string vTitle, string vContent, string vExpectedErrorMsg) {
            var wEx = Assert.Throws<ArgumentException>(() => TodoService.ValidateItem(vTitle, vContent));

            Assert.That(wEx.Message, Does.Contain(vExpectedErrorMsg));
        }

        [TestCase(20, false, Description = "境界値：20文字は正常")]
        [TestCase(21, true, Description = "境界値：21文字は例外")]
        public void ValidateItemはタイトルの文字数境界を正しく判定する(int vLength, bool vShouldThrow) {
            var wTitle = new string('a', vLength);

            if (vShouldThrow) {
                var wEx = Assert.Throws<ArgumentException>(() => TodoService.ValidateItem(wTitle, "内容"));

                Assert.That(wEx.Message, Does.Contain("タイトルは20文字以内で入力してください。"));
            } else {
                Assert.DoesNotThrow(() => TodoService.ValidateItem(wTitle, "内容"));
            }
        }

        [TestCase(150, false, Description = "境界値：150文字は正常")]
        [TestCase(151, true, Description = "境界値：151文字は例外")]
        public void ValidateItemは内容の文字数境界を正しく判定する(int vLength, bool vShouldThrow) {
            var wContent = new string('a', vLength);

            if (vShouldThrow) {
                var wEx = Assert.Throws<ArgumentException>(() => TodoService.ValidateItem("Title", wContent));

                Assert.That(wEx.Message, Does.Contain("内容は150文字以内で入力してください。"));
            } else {
                Assert.DoesNotThrow(() => TodoService.ValidateItem("Title", wContent));
            }
        }

        [Test]
        public void ValidateItemはタイトル前後の空白をトリムせず許容する() {
            Assert.DoesNotThrow(() => TodoService.ValidateItem(" a ", "内容"));
        }
        #endregion
    }
}
