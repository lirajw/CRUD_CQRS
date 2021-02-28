using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T model);
        void Remove(Guid ID);
        void Update(T model);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();


    }
}
