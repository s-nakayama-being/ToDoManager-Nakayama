using System;
using System.IO;
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

        [TearDown]
        public void Cleanup() {
            if (File.Exists("todos.xml")) {
                File.Delete("todos.xml");
            }
        }

        [Test]
        public void Export_正常なToDoリストを保存する場合_例外が発生しない() {
            var wItem = new TodoItem { Title = "テスト", DueDate = DateTime.Today, IsCompleted = false };
            FService.AddOrUpdate(wItem);

            FService.Export();

            Assert.That(File.Exists("todos.xml"), Is.True, "ファイルが作成されること");
            var wXmlContent = File.ReadAllText("todos.xml");
            Assert.That(wXmlContent, Does.Contain("<Title>テスト</Title>"), "保存されたXMLにアイテムのタイトルが含まれること");
        }

        [Test]
        public void Import_正常なXmlファイルからデータを読み込む場合_例外が発生しない() {
            var wValidateXml =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
                    <ArrayOfTodoItem>
                        <TodoItem>
                            <Id>1</Id>
                            <Title>テスト</Title>
                            <IsCompleted>false</IsCompleted>
                        </TodoItem>
                    </ArrayOfTodoItem>";
            File.WriteAllText("todos.xml", wValidateXml);

            bool wImportResult = FService.Import();

            Assert.That(wImportResult, Is.True, "正常なXmlファイルからの読込はtrueを返すこと");
            var wLoadedItems = FService.GetItems().ToList();
            Assert.That(wLoadedItems.Count, Is.EqualTo(1), "アイテムが1件読み込まれること");
            Assert.That(wLoadedItems[0].Title, Is.EqualTo("テスト"), "読み込まれたアイテムのタイトルが一致すること");
        }

        [Test]
        public void Import_ファイルが存在しない場合_falseを返す() {
            bool wImportResult = FService.Import();

            Assert.That(wImportResult, Is.False, "ファイルが存在しない場合はfalseを返すこと");
        }

        [TestCase("<InvalidData>不正データ</InvalidData>", Description = "不正なXmlタグ：異常系")]
        [TestCase("", Description = "空ファイル：異常系")]
        [TestCase("ただのテキスト", Description = "Xml形式ではない内容：異常系")]
        public void Import_ファイルのデータ形式が不正な場合_InvalidDataExceptionが発生する(string vFileContent) {
            File.WriteAllText("todos.xml", vFileContent);

            Assert.That(() => FService.Import(), Throws.TypeOf<InvalidDataException>(), "ファイルのデータ形式が不正な場合はInvalidDataExceptionが発生すること");
        }
    }
}
