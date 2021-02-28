using Domain.Comands.Requests;
using Domain.Comands.Responses;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        ICustomerRepository _repository;

        public UpdateCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest command, CancellationToken cancellationToken)
        {            

                var customer = new Customer(command.Id,
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

            _repository.Update(customer);

            var customerResponse = new UpdateCustomerResponse(customer.Name,
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
    }
}
