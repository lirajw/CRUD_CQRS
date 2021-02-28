using Domain.Comands.Requests;
using Domain.Comands.Responses;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Service.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CustomerService : ICustomerService
    {
        public IMediator _Mediator { get; private set; }
        public ICustomerRepository _Repository { get; private set; }
        public CustomerService(IMediator Mediator, ICustomerRepository Repository)
        {
            _Mediator = Mediator;
            _Repository = Repository;
        }
        public async Task<CreateCustomerResponse> Add(CreateCustomerRequest command)
        {
            var validators = new CreateCustomerValidator(_Repository, command);

            if (!validators.isValid())
                throw new ValidationRuleException(validators.Errors.ToArray());

            return await _Mediator.Send(command);
                        
        }

        public async Task<RemoveCustomerResponse> Remove(Guid ID)
        {
            var removeCustomer = new RemoveCustomerRequest(ID);

            var validators = new RemoveCustomerValidator(removeCustomer);

            if (!validators.isValid())
                throw new ValidationRuleException(validators.Errors.ToArray());

            return await _Mediator.Send(removeCustomer);
        }

        public async Task<UpdateCustomerResponse> Update(UpdateCustomerRequest command)
        {
            var validators = new UpdateCustomerValidator(_Repository, command);

            if (!validators.isValid())
                throw new ValidationRuleException(validators.Errors.ToArray());

            return await _Mediator.Send(command);
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            return _Repository.GetAll();
        }

        public Task<Customer> GetById(Guid id)
        {
            return _Repository.GetById(id);
        }

    }
}
