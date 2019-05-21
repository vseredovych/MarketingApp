using System.Collections.ObjectModel;
using System.Collections.Generic;
using DAL.Operations;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Collections
{
    public class MerchantsCollections : IEntityCollection<Merchant>
    {
        private List<Merchant> users;
        private MerchantsOperations userOperations;

        public MerchantsCollections()
        {
            userOperations = new MerchantsOperations();
            users = new List<Merchant>();
            users = userOperations.GetAll();
        }

        public void Add(Merchant user)
        {
            userOperations.Insert(user);
            users.Clear();
            users = userOperations.GetAll();
        }
        public void Update(Merchant user)
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

        public List<Merchant> GetAll()
        {
            return users;
        }
        public Merchant GetByID(int id)
        {
            return users[id];
        }
        public int GetEntitiesCount()
        {
            return users.Count;
        }
    }
}
