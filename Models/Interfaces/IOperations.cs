using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOperations<T> where T : class
    {
        List<T> GetAll();
        T GetByID(long id);
        void Insert(T item);
        void Update(T item);
        void Delete(long id);
        long GetScalarValue(string commandText);
    }
}

