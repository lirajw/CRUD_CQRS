using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Domain.Interfaces;
using Domain.Comands.Requests;

namespace Service.Validators
{
    public class UpdateCustomerValidator : CustomerValidator
    {
        UpdateCustomerRequest _UpdateCustomer { get; set; }
        public UpdateCustomerValidator(ICustomerRepository repository, UpdateCustomerRequest updateCustomer) : base(repository)
        {
            _UpdateCustomer = updateCustomer;
        }
        public override bool isValid()
        {
            bool isValid = true;

            if (!RepositoryValidation())
                return false;
                        
            NotNullValidation(ref isValid);

            BusinessRuleValidation(ref isValid);
            
            return isValid;
        }

        private bool RepositoryValidation()
        {
            if (_Repository.GetById(_UpdateCustomer.Id).Result == null)
            {
                Errors.Add("Cliente não encontrado na base de dados.");
                return false;
            }

             var customerByEmail = _Repository.GetAll().Result.Where(X => X.Email == _UpdateCustomer.Email);

            if (customerByEmail.Count() > 0 && customerByEmail.Where(X => X.Id != _UpdateCustomer.Id).Count() > 0)
            {
                Errors.Add("Email já cadastrado.");
                return false;
            }

            var customerByCpfCnpj = _Repository.GetAll().Result.Where(X => X.CPFCNPJ == _UpdateCustomer.CPFCNPJ);

            if (customerByCpfCnpj.Count() > 0 && customerByCpfCnpj.Where(X => X.Id != _UpdateCustomer.Id).Count() > 0)
            {
                Errors.Add($"{(_UpdateCustomer.CPFCNPJ.Length > 11 ? "CNPJ" : "CPF")} já cadastrado.");
                return false;
            }

            return true;
        }
        private void NotNullValidation(ref bool isValid)
        {
            if (string.IsNullOrEmpty(_UpdateCustomer.Name))
            {
                isValid = false;
                Errors.Add("Nome Obrigatório");
            }

            if (string.IsNullOrEmpty(_UpdateCustomer.CPFCNPJ))
            {
                isValid = false;
                Errors.Add($"{(_UpdateCustomer.CPFCNPJ.Length > 11 ? "CNPJ" : "CPF")} Obrigatório.");
            }

            if (string.IsNullOrEmpty(_UpdateCustomer.Email))
            {
                isValid = false;
                Errors.Add("Email Obrigatório");
            }

            if (_UpdateCustomer.CPFCNPJ.Length <= 11 && _UpdateCustomer.Age == null)
            {
                isValid = false;
                Errors.Add("Idade Obrigatória");
            }
        }

        private void BusinessRuleValidation(ref bool isValid)
        {
            if (_UpdateCustomer.CPFCNPJ.Length <= 11 && _UpdateCustomer.Age < 18)
            {
                isValid = false;
                Errors.Add("Idade minima para cadastro é 18 anos.");
            }

            if (_UpdateCustomer.CPFCNPJ.Length > 11 && string.IsNullOrEmpty(_UpdateCustomer.IE) && _UpdateCustomer.IEIsento == false)
            {
                isValid = false;
                Errors.Add("Informe o IE de sua empresa ou marque a opção Isento");
            }
        }
    }
}
