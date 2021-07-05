using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
         List <T> List();
        T GetById(int id);
        void Create(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }
}