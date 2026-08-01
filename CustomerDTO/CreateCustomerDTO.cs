using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPrestamos.Api.DTOs.CustomerDTO
{
    public class CreateCustomerDTO
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? ContactEmergency { get; set; }
        public int Age { get; set; }
        public int creditorId { get; set; }
    }
}