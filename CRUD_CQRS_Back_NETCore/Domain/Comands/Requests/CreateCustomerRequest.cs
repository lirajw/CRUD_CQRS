using Domain.Comands.Responses;
using MediatR;

namespace Domain.Comands.Requests
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        public string Name { get; private set; }
        public int? Age { get; private set; }
        public string CPFCNPJ { get; private set; }
        public string IE { get; private set; }
        public bool IEIsento { get; private set; }
        public string Telephone { get; private set; }
        public string Email { get; private set; }
        public string CEP { get; private set; }
        public string Address { get; private set; }
        public int Number { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public CreateCustomerRequest(string name,
                                     int? age,
                                     string cPFcNPJ,
                                     string iE,
                                     bool iEIsento,
                                     string telephone,
                                     string email,
                                     string cep,
                                     string address,
                                     int number,
                                     string district,
                                     string city,
                                     string state)
        {            
            Name = name;
            Age = age;
            CPFCNPJ = cPFcNPJ;
            IE = iE;
            IEIsento = iEIsento;
            Telephone = telephone;
            Email = email;
            CEP = cep;
            Address = address;
            Number = number;
            District = district;
            City = city;
            State = state;
        }
    }
}
