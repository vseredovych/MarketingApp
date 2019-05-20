using System.Collections.ObjectModel;
using System.Collections.Generic;
using DAL.Operations;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Collections
{
    public class UsersCollections : IEntityCollection<User>
    {
        private List<User> users;
        private UsersOperations userOperations;
        //private const int EntityTablesCount = 6;

        public UsersCollections()
        {
            userOperations = new UsersOperations();
            users = new List<User>();
            users = userOperations.GetAll();
        }

        public void Add(User user)
        {
            userOperations.Insert(user);
            users.Clear();
            users = userOperations.GetAll();
        }
        public void Update(User user)
        {
            userOperations.Update(user);
            users.Clear();
            users = userOperations.GetAll();
        }
        public void Delete(int id)
        {
            userOperations.Delete((int)users[id].Id);
            users.RemoveAt(id);
        }

        public List<User> GetAll()
        {
            return users;
        }
        public User GetByID(int id)
        {
            return users[id];
        }
        public int GetEntitiesCount()
        {
            return users.Count;
        }
        //public int GetEntityTablesCount()
        //{
        //    return EntityTablesCount;
        //}
    }
}
