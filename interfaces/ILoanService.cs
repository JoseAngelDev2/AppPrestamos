using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPrestamos.Domain.Entities;

namespace AppPrestamos.Api.interfaces
{
    public interface ILoanService
    {
        public Task<Loan> GetLoanById(int id);
        public Task<IEnumerable<Loan>> GetAllLoan();
        public Task RemoveLoan(int id);
        public Task AddLoan(Loan loan);
        public Task UpdateLoan(int id, Loan Nloan);

    }
}