using ToDoList.Models;

namespace ToDoList.Repositories
{
    public class InMemoryTodoRepository : ITodoRepository

    {
        private readonly List<ToDoItem>_todos= new List<ToDoItem>();

        private int _nextId = 1;

        public List<ToDoItem> GetAll()
        {
            return _todos;

        }

        public ToDoItem? GetById(int id)
        {
           return _todos.FirstOrDefault(todo=>todo.Id==id);
        }



        public void Add(ToDoItem item)
        {
            item.Id = _nextId++;
            _todos.Add(item);
        }

        public void Update(ToDoItem item)
        {
            var existing = GetById(item.Id);
            if (existing != null)
            {
                existing.Title = item.Title;
                existing.Description = item.Description;
                existing.IsCompleted = item.IsCompleted;
            }
        }

      
        public void Delete(int id)
        {
            var item = GetById(id);

            if(item != null)
            {
                _todos.Remove(item);
            }
        }

      

        
    }
}
