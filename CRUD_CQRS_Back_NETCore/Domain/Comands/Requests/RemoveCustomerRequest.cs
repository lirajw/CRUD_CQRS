using Domain.Comands.Responses;
using MediatR;
using System;

namespace Domain.Comands.Requests
{
    public class RemoveCustomerRequest: IRequest<RemoveCustomerResponse>
    {
        public Guid Id { get; private set; }

        public RemoveCustomerRequest(Guid id)
        {
            Id = id;
        }
    }
}
