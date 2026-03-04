using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoManager.Services {
    public class TodoStorageFactory : ITodoStorageFactory {
        private readonly Dictionary<string, Func<ITodoStorage>> FFactories;

        public TodoStorageFactory() => FFactories = new Dictionary<string, Func<ITodoStorage>>();

        public void Register(string vExtention, Func<ITodoStorage> vFactory) => FFactories[vExtention] = vFactory;

        public ITodoStorage Create(string vFilePath) {
            string wExtention = Path.GetExtension(vFilePath);

            if (wExtention != null && FFactories.TryGetValue(wExtention, out var wFactory)) {
                return wFactory();
            }

            throw new NotSupportedException("サポートされていないファイル形式です。");
        }
    }
}
        
