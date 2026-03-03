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
        #region 基本機能テスト
        /// <summary>
        /// テスト対象のTodoServiceインスタンスを保持するフィールド
        /// </summary>
        private TodoService FService;

        /// <summary>
        /// テスト前の初期化処理
        /// </summary>
        [SetUp]
        public void Init() {
            FService = new TodoService();
        }

        /// <summary>
        /// AddOrUpdateで新規アイテムが追加されること
        /// </summary>
        [Test]
        public void AddOrUpdate_ToDoの追加() {
            var wItem = new TodoItem { Title = "Test", Content = "TestContent", DueDate = DateTime.Today, IsCompleted = false };

            FService.AddOrUpdate(wItem);

            var wItems = FService.GetItems().ToList();
            Assert.That(wItems.Count, Is.EqualTo(1), "アイテム数が1であること");
            Assert.That(wItems[0].Title, Is.EqualTo("Test"), "タイトルが一致すること");
        }

        /// <summary>
        /// AddOrUpdateで既存アイテムが更新されること
        /// </summary>
        [Test]
        public void AddOrUpdate_ToDoの更新() {
            var wItem = new TodoItem { Title = "Test", Content = "TestContent", DueDate = DateTime.Today, IsCompleted = false };
            FService.AddOrUpdate(wItem);

            wItem.Title = "Updated";
            FService.AddOrUpdate(wItem);

            var wItems = FService.GetItems().ToList();
            Assert.That(wItems.Count, Is.EqualTo(1), "更新のためアイテム数は増えないこと");
            Assert.That(wItems[0].Title, Is.EqualTo("Updated"), "タイトルが更新されていること");
        }
        #endregion

        #region ソート機能テスト
        /// <summary>
        /// SortByDueDateで期限順にソートされること
        /// </summary>
        [Test]
        public void SortByDueDate_期限順ソート() {
            var wItem1 = new TodoItem { Title = "Test1", DueDate = DateTime.Today.AddDays(1) };
            var wItem2 = new TodoItem { Title = "Test2", DueDate = DateTime.Today };
            FService.AddOrUpdate(wItem1);
            FService.AddOrUpdate(wItem2);

            FService.SortByDueDate();

            var wItems = FService.GetItems().ToList();
            Assert.That(wItems[0].Title, Is.EqualTo("Test2"), "期限が早いものが先頭に来ること");
            Assert.That(wItems[1].Title, Is.EqualTo("Test1"), "期限が遅いものが後ろに来ること");
        }

        /// <summary>
        /// SortByAddedOrderで追加順にソートされること
        /// </summary>
        [Test]
        public void SortByAddedOrder_追加順ソート() {
            var wItem1 = new TodoItem { Title = "Test1", DueDate = DateTime.Today.AddDays(1) };
            var wItem2 = new TodoItem { Title = "Test2", DueDate = DateTime.Today };
            FService.AddOrUpdate(wItem1);
            FService.AddOrUpdate(wItem2);

            FService.SortByAddedOrder();

            var wItems = FService.GetItems().ToList();
            Assert.That(wItems[0].Title, Is.EqualTo("Test1"), "追加順（ID順）に並んでいること");
            Assert.That(wItems[1].Title, Is.EqualTo("Test2"));
        }
        #endregion

        #region バリデーション機能テスト
        [TestCase(1, "内容", Description = "タイトル1文字(最小値)：正常系")]
        [TestCase(20, "内容", Description = "タイトル20文字(最大値)：正常系")]
        public void ValidateItem_タイトルが1文字以上20文字以内の場合_例外が発生しない(int vLength, string vContent) {
            var wTitle = new string('a', vLength);

            Assert.That(() => TodoService.ValidateItem(wTitle, vContent), Throws.Nothing);
        }

        [TestCase("", "内容", "タイトルを入力してください", Description = "タイトル空：異常系")]
        [TestCase(null, "内容", "タイトルを入力してください", Description = "タイトル空：異常系")]
        [TestCase("   ", "内容", "タイトルを入力してください", Description = "タイトル空白：異常系")]
        public void ValidateItem_タイトルが空または空白の場合_ArgumentExceptionが発生する(string vTitle, string vContent, string vExpectedErrorMsg) {
            Assert.That(() => TodoService.ValidateItem(vTitle, vContent), Throws.ArgumentException.With.Message.Contain(vExpectedErrorMsg));
        }

        [TestCase(21, "内容", "タイトルは20文字以内で入力してください。", Description = "タイトル21文字(境界値)：異常系")]
        public void ValidateItem_タイトルが21文字以上の場合_ArgumentExceptionが発生する(int vLength, string vContent, string vExpectedErrorMsg) {
            var wTitle = new string('a', vLength);

            Assert.That(() => TodoService.ValidateItem(wTitle, vContent), Throws.ArgumentException.With.Message.Contain(vExpectedErrorMsg));
        }

        [Test]
        public void ValidateItem_タイトル前後に空白がある場合_空白をトリムせず許容する() {
            Assert.That(() => TodoService.ValidateItem(" a ", "内容"), Throws.Nothing);
        }

        [TestCase("タイトル", "", Description = "内容空：正常系")]
        [TestCase("タイトル", null, Description = "内容空：正常系")]
        [TestCase("タイトル", "   ", Description = "内容空白：正常系")]
        public void ValidateItem_内容が空または空白の場合_例外が発生しない(string vTitle, string vContent) {
            Assert.That(() => TodoService.ValidateItem(vTitle, vContent), Throws.Nothing);
        }


        [TestCase("タイトル", 150, Description = "内容150文字(最大値)：正常系")]
        public void ValidateItem_内容が0文字以上150字以内の場合_例外が発生しない(string vTitle, int vLength) {
            var wContent = new string('a', vLength);

            Assert.That(() => TodoService.ValidateItem(vTitle, wContent), Throws.Nothing);
        }

        [TestCase("タイトル", 151, "内容は150文字以内で入力してください。", Description = "内容151文字(境界値)：異常系")]
        public void ValidateItem_内容が151文字以上の場合_ArgumentExceptionが発生する(string vTitle, int vLength, string vExpectedErrorMsg) {
            var wContent = new string('a', vLength);

            Assert.That(() => TodoService.ValidateItem(vTitle, wContent), Throws.ArgumentException.With.Message.Contain(vExpectedErrorMsg));
        }
        #endregion
    }
}
