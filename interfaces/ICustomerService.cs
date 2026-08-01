using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPrestamos.Domain.Entities;

namespace AppPrestamos.Api.interfaces
{
    public interface ICustomerService
    {
        public Task<Customer> GetCustomerById(int id);
        public Task<IEnumerable<Customer>> GetAllCustomer();
        public Task RemoveCustomer(int id);
        public Task AddCustomer(Customer customer);

        public Task UpdateCustomer(int id, Customer Ncustomer);

    }
}