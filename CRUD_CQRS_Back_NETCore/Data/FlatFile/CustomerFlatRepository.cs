using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.FlatFile
{
    public class CustomerFlatRepository : ICustomerRepository
    {


        public async void Add(Domain.Models.Customer customer)
        {
            if(customer.Id == null)            
                customer.AddID(Guid.NewGuid());
                
            Flat.CadCustomer.Add(customer);
            await Task.Factory.StartNew(() => { Flat.SetCadastro<Customer>(Flat.CadCustomer, Flat.ArqCustomer); });

        }


        public async void Remove(Guid ID)
        {

            await Task.Factory.StartNew(() => {
                Flat.CadCustomer.Remove(Flat.CadCustomer.Find(X => X.Id == ID));
                Flat.SetCadastro<Customer>(Flat.CadCustomer, Flat.ArqCustomer);
            });
        }


        public async void Update(Customer customer)
        {
            await Task.Factory.StartNew(() => {

                var Cad = Flat.CadCustomer.Find(X => X.Id == customer.Id);

                if (Cad != null)
                    Flat.CadCustomer[Flat.CadCustomer.IndexOf(Cad)] = customer;
                var Prod = Flat.CadCustomer.Find(X => X.Id == customer.Id);

                Flat.SetCadastro<Customer>(Flat.CadCustomer, Flat.ArqCustomer);

            });
            
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            Task<IEnumerable<Customer>> T = new Task<IEnumerable<Customer>>(() => { return Flat.CadCustomer.AsEnumerable(); });

            T.Start();
            return T;
        }

        public Task<Customer> GetByEmail(string email)
        {
            Task<Customer> T = new Task<Customer>(() => { return Flat.CadCustomer.Where(cad => cad.Email == email).FirstOrDefault(); });

            T.Start();
            return T;
        }

        public Task<Customer> GetById(Guid id)
        {
            Task<Customer> T = new Task<Customer>(() => { return Flat.CadCustomer.Where(cad => cad.Id == id).FirstOrDefault(); });

            T.Start();
            return T;
        }

        public Task<Customer> GetByCpfCnpj(string CpfCnpj)
        {
            Task<Customer> T = new Task<Customer>(() => { return Flat.CadCustomer.Where(cad => cad.CPFCNPJ == CpfCnpj).FirstOrDefault(); });

            T.Start();
            return T;
        }
    }
}
