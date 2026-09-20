using A4_ModelViewController.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace A4_ModelViewController.Repository
{
    public class MemoryRepository<T> : IRepository<T>
    where T : class
    {
        private readonly List<T> _items = new List<T>();

        public List<T> GetAll()
        {
            return _items;
        }

        public T? GetById(int id)
        {
            return _items.FirstOrDefault(
                item =>
                    (int)item.GetType()
                        .GetProperty("Id")!
                        .GetValue(item)!
                    == id
            );
        }

        public void Add(T entity)
        {
            _items.Add(entity);
        }

        public void Update(T entity)
        {
            T? existingEntity =
                GetById(
                    (int)entity.GetType()
                        .GetProperty("Id")!
                        .GetValue(entity)!
                );

            if (existingEntity != null)
            {
                int index = _items.IndexOf(existingEntity);

                _items[index] = entity;
            }
        }

        public void Delete(int id)
        {
            T? entity = GetById(id);

            if (entity != null)
            {
                _items.Remove(entity);
            }
        }
    }
}
