using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Lista();
        T ReturnById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }
}
