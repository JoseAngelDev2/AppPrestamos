using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPrestamos.Api.DTOs.CustomerDTO;
using AppPrestamos.Api.interfaces;
using AppPrestamos.Api.Services;
using AppPrestamos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppPrestamos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController(ICustomerService service) : ControllerBase
    {
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadCustomerDTO>>> GetAllCustomer()
        {
            var customers = await service.GetAllCustomer();



            return Ok(customers.Select(c => new ReadCustomerDTO
            {
                Id = c.Id,
                Name = c.Name,
                LastName = c.LastName,
                Phone = c.Phone,
                Address = c.Address,
                Email = c.Email,
                ContactEmergency = c.ContactEmergency,
                Age = c.Age
            }));
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(CreateCustomerDTO customerDTO)
        {
            var Ncustomer = new Customer
            {
                Name = customerDTO.Name,
                LastName = customerDTO.LastName,
                Phone = customerDTO.Phone,
                Address = customerDTO.Address,
                Email = customerDTO.Email,
                ContactEmergency = customerDTO.ContactEmergency,
                Age = customerDTO.Age,
                creditorId = customerDTO.creditorId
            };

            await service.AddCustomer(Ncustomer);

            return Created();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ReadCustomerDTO>> GetCustomer(int id)
        {
            var customers = await service.GetCustomerById(id);

            var customerDTO = new ReadCustomerDTO
            {
                Id = customers.Id,
                Name = customers.Name,
                LastName = customers.LastName,
                Phone = customers.Phone,
                Address = customers.Address,
                Email = customers.Email,
                ContactEmergency = customers.ContactEmergency,
                Age = customers.Age
            };

            return Ok(customerDTO);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(int id, UpdateCustomerDTO customer)
        {
            var Ncustomer = new Customer
            {
                Name = customer.Name,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Address = customer.Address,
                Email = customer.Email,
                ContactEmergency = customer.ContactEmergency,
                Age = customer.Age
            };
            await service.UpdateCustomer(id, Ncustomer);

            return NoContent();
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> RemoveCustomer(int id)
        {
            await service.RemoveCustomer(id);
            return NoContent();
        }


    }
}