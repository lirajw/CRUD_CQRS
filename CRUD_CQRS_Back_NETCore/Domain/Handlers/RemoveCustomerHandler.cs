using Domain.Comands.Requests;
using Domain.Comands.Responses;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class RemoveCustomerHandler : IRequestHandler<RemoveCustomerRequest, RemoveCustomerResponse>
    {
        ICustomerRepository _repository;

        public RemoveCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Task<RemoveCustomerResponse> Handle(RemoveCustomerRequest request, CancellationToken cancellationToken)
        {
            _repository.Remove(request.Id);

            return Task.FromResult(new RemoveCustomerResponse("Registro removido."));
        }
    }
}
