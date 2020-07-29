using System.Collections.Generic;
using System.Linq;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Services
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoItemContext databaseContext;

        public ToDoRepository(ToDoItemContext toDoItemContext)
        {
            databaseContext = toDoItemContext;
        }

        public IEnumerable<ToDoItem> All
        {
            get { return databaseContext.Items; }
        }

        public bool DoesItemExist(string id)
        {
            return databaseContext.Items.Any(item => item.ID == id);
        }

        public ToDoItem Find(string id)
        {
            return databaseContext.Items.FirstOrDefault(item => item.ID == id);
        }

        public void Insert(ToDoItem item)
        {
            databaseContext.Add(item);
            databaseContext.SaveChanges();
        }

        public void Update(ToDoItem item)
        {
            databaseContext.Remove(Find(item.ID));
            databaseContext.Add(item);
            databaseContext.SaveChanges();
        }

        public void Delete(string id)
        {
            databaseContext.Remove(this.Find(id));
            databaseContext.SaveChanges();
        }
    }
}
