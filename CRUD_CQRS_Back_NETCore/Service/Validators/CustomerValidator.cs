using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Validators
{
    public abstract class CustomerValidator
    {
        protected ICustomerRepository _Repository { get; set; }

        public List<string> Errors { get; set; }

        public virtual bool isValid() { return false; }

        public CustomerValidator()
        {            
            Errors = new List<string>();
        }
        public CustomerValidator(ICustomerRepository repository): this()
        {
            _Repository = repository;            
        }

    }
}
