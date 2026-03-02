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

        [TestCase(null, Description = "null：異常系")]
        [TestCase("", Description = "空文字：異常系")]
        [TestCase("　", Description = "全角スペース：異常系")]
        [TestCase(" ", Description = "半角スペース：異常系")]
        public void SearchByTitle_キーワードが空文字やスペースのみの場合_Todo全件が返る(string vKeyword) {
            FService.AddOrUpdate(new TodoItem { Title = "Test1" });
            FService.AddOrUpdate(new TodoItem { Title = "Test2" });

            var wResult = FService.SearchByTitle(vKeyword).ToList();

            Assert.That(wResult, Has.Count.EqualTo(2), "空文字やスペースの場合は全件返されること");
        }


        [TestCase("test", new[] { 1, 3 }, Description = "大文字小文字を区別せず、タイトルのみ部分一致：正常系")]
        [TestCase("TEST", new[] { 1, 3 }, Description = "大文字検索の場合、小文字を含むタイトルがヒットする：正常系")]
        [TestCase("他のテスト", new int[0], Description = "タイトルと部分一致しない場合はヒットしない：正常系")]
        public void SearchByTitle_キーワードが正常な場合_部分一致で検索される(string vKeyword, int[] vExpectedHitIds) {
            FService.AddOrUpdate(new TodoItem { Title = "New Test" });
            FService.AddOrUpdate(new TodoItem { Title = "NoName", Content = "Test" });
            FService.AddOrUpdate(new TodoItem { Title = "Another TEST", Content = "他のテスト" });

            var wSelectedIds = FService.SearchByTitle(vKeyword).Select(x => x.Id).ToList();

            Assert.That(wSelectedIds, Is.EquivalentTo(vExpectedHitIds));
        }
    }
}
