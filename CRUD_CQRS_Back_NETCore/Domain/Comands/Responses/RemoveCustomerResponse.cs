using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Comands.Responses
{
    public class RemoveCustomerResponse
    {
        public string Message { get; private set; }

        public RemoveCustomerResponse(string message)
        {
            Message = message;
        }
    }
}
