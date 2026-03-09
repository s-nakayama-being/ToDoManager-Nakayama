using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using ToDoManager.Models;
using ToDoManager.Services;
using ToDoManagerTests.Stubs;

namespace ToDoManagerTests {
    /// <summary>
    /// TodoServiceの単体テストクラス
    /// </summary>
    [TestFixture]
    public class TodoServiceTests {
        #region フィールド・初期化

        private StubStorage FStub;
        private TodoService FService;


        /// <summary>
        /// テスト前の初期化処理
        /// </summary>
        [SetUp]
        public void Init() {
            FStub = new StubStorage();
            FService = new TodoService(vPath => FStub);
        }

        #endregion

        #region 基本機能テスト

        /// <summary>
        /// AddOrUpdateで新規アイテムが追加されること
        /// </summary>
        [Test]
        public void AddOrUpdate_ToDoの追加() {
            var wItem = new TodoItem { Title = "Test", Content = "TestContent", DueDate = DateTime.Today, IsCompleted = false, Priority = TodoPriorityEnum.High };

            FService.AddOrUpdate(wItem);

            var wItems = FService.GetItems().ToList();
            Assert.That(wItems.Count, Is.EqualTo(1), "アイテム数が1であること");
            Assert.That(wItems[0].Title, Is.EqualTo("Test"), "タイトルが一致すること");
            Assert.That(wItems[0].Content, Is.EqualTo("TestContent"), "内容が一致すること");
            Assert.That(wItems[0].DueDate, Is.EqualTo(DateTime.Today), "期限が一致すること");
            Assert.That(wItems[0].IsCompleted, Is.False, "完了状態が一致すること");
            Assert.That(wItems[0].Priority, Is.EqualTo(TodoPriorityEnum.High), "優先度が一致すること");
        }

        /// <summary>
        /// AddOrUpdateで既存アイテムが更新されること
        /// </summary>
        [Test]
        public void AddOrUpdate_ToDoの更新() {
            var wItem = new TodoItem { Title = "Test", Content = "TestContent", DueDate = DateTime.Today, IsCompleted = false, Priority = TodoPriorityEnum.High };
            FService.AddOrUpdate(wItem);

            wItem.Title = "Updated";
            wItem.Content = "UpdatedContent";
            wItem.DueDate = DateTime.Today.AddDays(1);
            wItem.IsCompleted = true;
            wItem.Priority = TodoPriorityEnum.Low;
            FService.AddOrUpdate(wItem);

            var wItems = FService.GetItems().ToList();
            Assert.That(wItems.Count, Is.EqualTo(1), "更新のためアイテム数は増えないこと");
            Assert.That(wItems[0].Title, Is.EqualTo("Updated"), "タイトルが更新されていること");
            Assert.That(wItems[0].Content, Is.EqualTo("UpdatedContent"), "内容が更新されていること");
            Assert.That(wItems[0].DueDate, Is.EqualTo(DateTime.Today.AddDays(1)), "期限が更新されていること");
            Assert.That(wItems[0].IsCompleted, Is.True, "完了状態が更新されていること");
            Assert.That(wItems[0].Priority, Is.EqualTo(TodoPriorityEnum.Low), "優先度が更新されていること");
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

            FService.SortItems(SortStrategy.C_DueDate);

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

            FService.SortItems(SortStrategy.C_AddedOrder);

            var wItems = FService.GetItems().ToList();
            Assert.That(wItems[0].Title, Is.EqualTo("Test1"), "追加順（ID順）に並んでいること");
            Assert.That(wItems[1].Title, Is.EqualTo("Test2"));
        }

        #endregion

        #region 保存・読込機能テスト

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

        #endregion

        #region バリデーション機能テスト（タイトルの部分一致検索）

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

        #endregion

        #region バリデーション機能テスト（タイトルと内容の入力チェック）

        /// <summary>
        /// ValidateItemでタイトルが1文字以上20文字以内の場合、例外が発生しないこと
        /// </summary>
        /// <param name="vLength">タイトルの文字数</param>
        /// <param name="vContent">内容</param>
        [TestCase(1, "内容", Description = "タイトル1文字(最小値)：正常系")]
        [TestCase(20, "内容", Description = "タイトル20文字(最大値)：正常系")]
        public void ValidateItem_タイトルが1文字以上20文字以内の場合_例外が発生しない(int vLength, string vContent) {
            var wTitle = new string('a', vLength);

            Assert.That(() => TodoService.ValidateItem(wTitle, vContent), Throws.Nothing);
        }

        /// <summary>
        /// ValidateItemでタイトルが空または空白の場合、ArgumentExceptionが発生すること
        /// </summary>
        /// <param name="vTitle">タイトル</param>
        /// <param name="vContent">内容</param>
        /// <param name="vExpectedErrorMsg">エラーメッセージの一部</param>
        [TestCase("", "内容", "タイトルを入力してください", Description = "タイトル空：異常系")]
        [TestCase(null, "内容", "タイトルを入力してください", Description = "タイトル空：異常系")]
        [TestCase("   ", "内容", "タイトルを入力してください", Description = "タイトル空白：異常系")]
        public void ValidateItem_タイトルが空または空白の場合_ArgumentExceptionが発生する(string vTitle, string vContent, string vExpectedErrorMsg) {
            Assert.That(() => TodoService.ValidateItem(vTitle, vContent), Throws.ArgumentException.With.Message.Contain(vExpectedErrorMsg));
        }

        /// <summary>
        /// ValidateItemでタイトルが21文字以上の場合、ArgumentExceptionが発生すること
        /// </summary>
        /// <param name="vLength">タイトルの文字数</param>
        /// <param name="vContent">内容</param>
        /// <param name="vExpectedErrorMsg">エラーメッセージの一部</param>
        [TestCase(21, "内容", "タイトルは20文字以内で入力してください。", Description = "タイトル21文字(境界値)：異常系")]
        public void ValidateItem_タイトルが21文字以上の場合_ArgumentExceptionが発生する(int vLength, string vContent, string vExpectedErrorMsg) {
            var wTitle = new string('a', vLength);

            Assert.That(() => TodoService.ValidateItem(wTitle, vContent), Throws.ArgumentException.With.Message.Contain(vExpectedErrorMsg));
        }

        /// <summary>
        /// ValidateItemでタイトルの前後に空白がある場合、空白をトリムせず許容すること
        /// </summary>
        [Test]
        public void ValidateItem_タイトル前後に空白がある場合_空白をトリムせず許容する() {
            Assert.That(() => TodoService.ValidateItem(" a ", "内容"), Throws.Nothing);
        }

        /// <summary>
        /// ValidateItemで内容が空または空白の場合、例外が発生しないこと
        /// </summary>
        /// <param name="vTitle">タイトル</param>
        /// <param name="vContent">内容</param>
        [TestCase("タイトル", "", Description = "内容空：正常系")]
        [TestCase("タイトル", null, Description = "内容空：正常系")]
        [TestCase("タイトル", "   ", Description = "内容空白：正常系")]
        public void ValidateItem_内容が空または空白の場合_例外が発生しない(string vTitle, string vContent) {
            Assert.That(() => TodoService.ValidateItem(vTitle, vContent), Throws.Nothing);
        }

        /// <summary>
        /// ValidateItemで内容が0文字以上150文字以内の場合、例外が発生しないこと
        /// </summary>
        /// <param name="vTitle">タイトル</param>
        /// <param name="vLength">内容の文字数</param>
        [TestCase("タイトル", 150, Description = "内容150文字(最大値)：正常系")]
        public void ValidateItem_内容が0文字以上150字以内の場合_例外が発生しない(string vTitle, int vLength) {
            var wContent = new string('a', vLength);

            Assert.That(() => TodoService.ValidateItem(vTitle, wContent), Throws.Nothing);
        }

        /// <summary>
        /// ValidateItemで内容が151文字以上の場合、ArgumentExceptionが発生すること
        /// </summary>
        /// <param name="vTitle">タイトル</param>
        /// <param name="vLength">内容の文字数</param>
        /// <param name="vExpectedErrorMsg">エラーメッセージの一部</param>
        [TestCase("タイトル", 151, "内容は150文字以内で入力してください。", Description = "内容151文字(境界値)：異常系")]
        public void ValidateItem_内容が151文字以上の場合_ArgumentExceptionが発生する(string vTitle, int vLength, string vExpectedErrorMsg) {
            var wContent = new string('a', vLength);

            Assert.That(() => TodoService.ValidateItem(vTitle, wContent), Throws.ArgumentException.With.Message.Contain(vExpectedErrorMsg));
        }

        #endregion

        #region 保存・読込機能テスト

        [Test]
        public void Export_正常なファイルパスの場合_ストレージのSaveが呼び出されること() {
            var wItem = new TodoItem { Title = "ExportTest" };
            FService.AddOrUpdate(wItem);

            FService.Export("dummy.json");

            Assert.That(FStub.SavedItems, Is.Not.Null);
            Assert.That(FStub.SavedItems.Count, Is.EqualTo(1));
            Assert.That(FStub.SavedItems[0].Title, Is.EqualTo("ExportTest"));
        }

        [Test]
        public void Import_正常なファイルパスの場合_ストレージのLoadが呼び出されること() {
            FService.Import("dummy.json");

            var wItems = FService.GetItems().ToList();
            Assert.That(wItems[0].Id, Is.EqualTo(55));
            Assert.That(wItems[0].Title, Is.EqualTo("Test"));
        }

        [TestCase(null, Description = "ファイルパス空：異常系")]
        [TestCase("", Description = "ファイルパス空：異常系")]
        [TestCase("   ", Description = "ファイルパス空白：異常系")]
        public void Export_ファイルパスが空の場合_ArgumentExceptionが発生すること(string vFilePath) {
            Assert.That(() => FService.Export(vFilePath), Throws.ArgumentException);
        }

        [TestCase(null, Description = "ファイルパス空：異常系")]
        [TestCase("", Description = "ファイルパス空：異常系")]
        [TestCase("   ", Description = "ファイルパス空白：異常系")]
        public void Import_ファイルパスが空の場合_ArgumentExceptionが発生すること(string vFilePath) {
            Assert.That(() => FService.Import(vFilePath), Throws.ArgumentException);
        }

        [Test]
        public void Create_サポートされていない拡張子の場合_NotSupportedExceptionが発生すること() {
            Assert.That(() => TodoStorage.Create("test.invalid"), Throws.TypeOf<NotSupportedException>());
        }

        #endregion
    }
}
