using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPrestamos.Domain.Core;
using AppPrestamos.Domain.Entities;

namespace AppPrestamos.Api.DTOs.LoanDTO
{
    public class ReadLoanDTO : BaseEntity
    {
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public LoanStatus Status { get; set; } = LoanStatus.Active;
    }
}