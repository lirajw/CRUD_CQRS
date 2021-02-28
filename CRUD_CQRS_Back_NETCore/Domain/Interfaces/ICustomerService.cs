using Domain.Comands.Requests;
using Domain.Comands.Responses;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICustomerService
    {
        Task<CreateCustomerResponse> Add(CreateCustomerRequest command);
        Task<RemoveCustomerResponse> Remove(Guid ID);
        Task<UpdateCustomerResponse> Update(UpdateCustomerRequest command);
        Task<Customer> GetById(Guid id);
        Task<IEnumerable<Customer>> GetAll();
    }
}
