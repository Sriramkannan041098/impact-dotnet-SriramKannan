using System;
using System.Collections.Generic;
using System.Text;

namespace A3_AdvancedDesignPatterns.RepositoryPattern
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        T? GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}
