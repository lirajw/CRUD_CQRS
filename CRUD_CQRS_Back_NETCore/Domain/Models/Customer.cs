using System;

namespace Domain.Models
{
    public class Customer : BaseModel
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

        public Customer(Guid id,
                string name,
                int? age,
                string CPFCNPJ,
                string IE,
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
            Id = id;
            Name = name;
            Age = age;
            this.CPFCNPJ = CPFCNPJ;
            this.IE = IE;
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

        protected Customer() { }

        public void AddID(Guid id)
        {
            this.Id = id;
        }
    }
}
