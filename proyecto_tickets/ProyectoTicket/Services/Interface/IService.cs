using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTicket.Services.Interface
{
    public interface IService<T>
    {
        public void Add(T entity);
        public bool Update(int id, T entity);
        public bool Delete(int id);
        public List<T> GetAll();
        public T? GetById(int id);
    }
}