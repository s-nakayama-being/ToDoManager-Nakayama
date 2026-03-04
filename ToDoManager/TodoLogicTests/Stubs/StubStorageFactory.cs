using System;
using ToDoManager.Services;

namespace ToDoManagerTests.Stubs {
    internal class StubStorageFactory : ITodoStorageFactory {
        public StubStorage FStorage { get; } = new StubStorage();

        public ITodoStorage Create(string vFilePath) {
            if (vFilePath.EndsWith(".invalid")) throw new NotSupportedException("サポートされていません");

            return FStorage;
        }
    }
}
