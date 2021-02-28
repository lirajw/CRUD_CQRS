using Domain.Comands.Requests;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Validators
{
    public class CreateCustomerValidator : CustomerValidator
    {
        CreateCustomerRequest _CreateCustomer { get; set; }
        public CreateCustomerValidator(ICustomerRepository repository, CreateCustomerRequest createCustomer): base(repository)
        {
            _CreateCustomer = createCustomer;
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
            if (_Repository.GetByEmail(_CreateCustomer.Email).Result != null)
            {
                Errors.Add("Email já cadastrado.");
                return false;
            }

            if (_Repository.GetByCpfCnpj(_CreateCustomer.CPFCNPJ).Result != null)
            {
                Errors.Add($"{(_CreateCustomer.CPFCNPJ.Length > 11 ? "CNPJ" : "CPF")} já cadastrado.");
                return false;
            }

            return true;
        }
        private void NotNullValidation(ref bool isValid)
        {
            if (string.IsNullOrEmpty(_CreateCustomer.Name))
            {
                isValid = false;
                Errors.Add("Nome Obrigatório");
            }

            if (string.IsNullOrEmpty(_CreateCustomer.CPFCNPJ))
            {
                isValid = false;

                if(string.IsNullOrEmpty(_CreateCustomer.CPFCNPJ))
                {
                    Errors.Add($"CPF/CNPJ Obrigatório.");
                }
                else
                {

                    Errors.Add($"{(_CreateCustomer.CPFCNPJ.Length > 11 ? "CNPJ" : "CPF")} Obrigatório.");
                }
            }

            if (string.IsNullOrEmpty(_CreateCustomer.Email))
            {
                isValid = false;
                Errors.Add("Email Obrigatório");
            }

            if (_CreateCustomer.CPFCNPJ?.Length <= 11 && _CreateCustomer.Age == null)
            {
                isValid = false;
                Errors.Add("Idade Obrigatória");
            }
        }


        private void BusinessRuleValidation(ref bool isValid)
        {
            if (_CreateCustomer.CPFCNPJ?.Length <= 11 && _CreateCustomer.Age < 18)
            {
                isValid = false;
                Errors.Add("Idade minima para cadastro é 18 anos.");
            }

            if (_CreateCustomer.CPFCNPJ?.Length > 11 && string.IsNullOrEmpty(_CreateCustomer.IE) && _CreateCustomer.IEIsento == false)
            {
                isValid = false;
                Errors.Add("Informe o IE de sua empresa ou marque a opção Isento");
            }
        }
    }
}
