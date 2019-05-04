using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IEntityCollection<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
        T GetByID(int id);
        //int GetEntityTablesCount();
        int GetEntitiesCount();
    }
}
