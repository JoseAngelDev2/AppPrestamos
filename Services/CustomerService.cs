using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPrestamos.Api.Services;
using AppPrestamos.Api.Data;
using AppPrestamos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AppPrestamos.Api.interfaces;
namespace AppPrestamos.Api.Services
{
    public class CustomerService(AppPrestamosDbContext app) : ICustomerService
    {
        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await app.Customers.FindAsync(id);

            if (customer is null)
            {
                throw new Exception("The customer was not found");
            }
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            var customers = await app.Customers.AsNoTracking().ToListAsync();
            return customers;
        }

        public async Task AddCustomer(Customer customer)
        {
            await app.Customers.AddAsync(customer);
            await app.SaveChangesAsync();
        }

        public async Task RemoveCustomer(int id)
        {
            var customer = await GetCustomerById(id);

            if (customer is null)
            {
                throw new Exception("The customer was not found");
            }

            app.Customers.Remove(customer);
            await app.SaveChangesAsync();
        }

        public async Task UpdateCustomer(int id, Customer Ncustomer)
        {
            var customer = await GetCustomerById(id);

            customer.Name = Ncustomer.Name;
            customer.LastName = Ncustomer.LastName;
            customer.Age = Ncustomer.Age;
            customer.ContactEmergency = Ncustomer.ContactEmergency;
            customer.Email = Ncustomer.Email;
            customer.Phone = Ncustomer.Phone;
            customer.Address = Ncustomer.Address;
  

            app.Customers.Update(customer);
            await app.SaveChangesAsync();

        }

    }
}