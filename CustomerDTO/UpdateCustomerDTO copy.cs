using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPrestamos.Domain.Core;

namespace AppPrestamos.Api.DTOs.CustomerDTO
{
    public class UpdateCustomerDTO
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? ContactEmergency { get; set; }
        public int Age { get; set; }
    }
}