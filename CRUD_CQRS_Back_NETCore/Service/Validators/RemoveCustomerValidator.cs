using Domain.Comands.Requests;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Validators
{
    public class RemoveCustomerValidator: CustomerValidator
    {
        RemoveCustomerRequest _RemoveCustomer { get; set; }
        public RemoveCustomerValidator(RemoveCustomerRequest removeCustomer) : base()
        {
            _RemoveCustomer = removeCustomer;
        }

        public override bool isValid()
        {
            return true;
        }
    }
}
