using ToDoList.Models;

namespace ToDoList.Repositories
{
    public interface ITodoRepository
    {
        List<ToDoItem> GetAll();

        void Add(ToDoItem item);

        void Update(ToDoItem item);
        void Delete(int id);
        ToDoItem? GetById(int id);
    }
}
