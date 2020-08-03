using ToDoApi.Models;

namespace ToDoApi.Interfaces
{
    public interface IUserRepository
    {
        bool DoesUserExist(string id);
        User Find(string id);
        void Insert(User user);
        void Remove(string id);
    }
}
