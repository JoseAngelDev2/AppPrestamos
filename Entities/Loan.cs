using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPrestamos.Domain.Core;

namespace AppPrestamos.Domain.Entities
{
    public class Loan : BaseEntity
    {
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public LoanStatus Status { get; set; } = LoanStatus.Active;
        public int CreditorId { get; set; }
        public Creditor Creditor { get; set; } = default!;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }

    public enum LoanStatus
    {
        Active,
        Paid,
        Overdue,
        Cancelled
    }
}