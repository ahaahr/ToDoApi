using System;
using System.Linq;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext databaseContext;

        public UserRepository(UserContext userContext)
        {
            databaseContext = userContext;
        }

        public bool DoesUserExist(string id)
        {
            return databaseContext.Users.Any(item => item.ID == id);
        }

        public User Find(string id)
        {
            return databaseContext.Users.FirstOrDefault(item => item.ID == id);
        }

        public void Insert(User user)
        {
            databaseContext.Add(user);
            databaseContext.SaveChanges();
        }

        public void Remove(string id)
        {
            databaseContext.Remove(Find(id));
            databaseContext.SaveChanges();
        }
    }
}
