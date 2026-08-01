using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPrestamos.Domain.Core;
namespace AppPrestamos.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? ContactEmergency { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public int creditorId { get; set; }
        public Creditor creditor { get; set; }
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();



        public void VerifyAge()
        {
            if (Age <= 0 || Age >= 120)
            {
                throw new Exception("The field Age is invalid");
            }
        }

        public void VerifyName()
        {
            if (Name == string.Empty)
            {
                throw new Exception("The field name is empty");
            }

            if (Name!.Length >= 25)
            {
                throw new Exception("The field name have a limit of 25 caracters");
            }
        }
        public void VerifyLastName()
        {
            if (LastName == string.Empty)
            {
                throw new Exception("The field lastname is empty");
            }

            if (LastName!.Length >= 25)
            {
                throw new Exception("The field lastname have a limit of 40 caracters");
            }
        }


        public void VerifyEmail()
        {
            if (Email == string.Empty)
            {
                throw new Exception("The field Email is empty");
            }

            if (Email!.Length >= 50)
            {
                throw new Exception("The field Email have a limit of 25 caracters");
            }
        }


    }
}