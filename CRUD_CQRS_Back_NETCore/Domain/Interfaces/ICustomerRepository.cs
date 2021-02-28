using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByEmail(string email);

        Task<Customer> GetByCpfCnpj(string CpfCnpj);
    }
}
