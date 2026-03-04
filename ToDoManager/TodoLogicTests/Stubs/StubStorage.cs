using System.Collections.Generic;
using System.Linq;
using ToDoManager.Models;
using ToDoManager.Services;

namespace ToDoManagerTests.Stubs {
    internal class StubStorage : ITodoStorage {
        public List<TodoItem> SavedItems { get; private set; }

        public IEnumerable<TodoItem> Load(string vFilePath) => new List<TodoItem>() {
                new TodoItem { Id = 55, Title = "MockTitle", Content = "MockContent" }
            };

        public void Save(string vFilePath, IEnumerable<TodoItem> vItems) => SavedItems = vItems.ToList();
    }
}
