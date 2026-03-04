namespace ToDoManager.Services {
    public interface ITodoStorageFactory {
        ITodoStorage Create(string vFilePath);
    }
}
