using Domain.Comands.Requests;
using Domain.Comands.Responses;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        ICustomerRepository _repository;

        public CreateCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Task<CreateCustomerResponse> Handle(CreateCustomerRequest command, CancellationToken cancellationToken)
        {

            try
            {
                var customer = new Customer(Guid.NewGuid(),
                            command.Name,
                            command.Age,
                            command.CPFCNPJ,
                            command.IE,
                            command.IEIsento,
                            command.Telephone,
                            command.Email,
                            command.CEP,
                            command.Address,
                            command.Number,
                            command.District,
                            command.City,
                            command.State);

                _repository.Add(customer);

                var customerResponse = new CreateCustomerResponse(customer.Id,
                                                                  customer.Name,
                                                                  customer.Age,
                                                                  customer.CPFCNPJ,
                                                                  customer.IE,
                                                                  customer.IEIsento,
                                                                  customer.Telephone,
                                                                  customer.Email,
                                                                  customer.CEP,
                                                                  customer.Address,
                                                                  customer.Number,
                                                                  customer.District,
                                                                  customer.City,
                                                                  customer.State);

                return Task.FromResult(customerResponse);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
