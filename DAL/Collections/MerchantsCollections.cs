using System.Collections.ObjectModel;
using System.Collections.Generic;
using DAL.Operations;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Collections
{
    public class MerchantsCollections : IEntityCollection<Merchant>
    {
        private List<Merchant> merchants;
        private MerchantsOperations merchantOperations;

        public MerchantsCollections()
        {
            merchantOperations = new MerchantsOperations();
            merchants = new List<Merchant>();
            merchants = merchantOperations.GetAll();
        }

        public void Add(Merchant merchant)
        {
            merchantOperations.Insert(merchant);
            merchants.Clear();
            merchants = merchantOperations.GetAll();
        }
        public void Update(Merchant merchant)
        {
            merchantOperations.Update(merchant);
            merchants.Clear();
            merchants = merchantOperations.GetAll();
        }
        public void Delete(int id)
        {
            merchantOperations.Delete((int)merchants[id].Id);
            merchants.RemoveAt(id);
        }

        public List<Merchant> GetAll()
        {
            return merchants;
        }
        public List<Merchant> GetInRange(long start, long end)
        {
            merchants.Clear();
            merchants = merchantOperations.GetInRange(start, end);
            return merchants;
        }
        public List<Merchant> GetMoreThanAverage()
        {
            merchants.Clear();
            merchants = merchantOperations.GetMoreThenAverage();
            return merchants;
        }
        public Merchant GetByID(int id)
        {
            return merchants[id];
        }
        public int GetEntitiesCount()
        {
            return merchants.Count;
        }
    }
}
