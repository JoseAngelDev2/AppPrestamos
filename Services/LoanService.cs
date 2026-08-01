using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPrestamos.Api.Data;
using AppPrestamos.Api.interfaces;
using AppPrestamos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppPrestamos.Api.Services
{
    public class LoanService(AppPrestamosDbContext app) : ILoanService
    {
        public async Task AddLoan(Loan loan)
        {
            await app.Loans.AddAsync(loan);
            await app.SaveChangesAsync();
        }

        public async Task<IEnumerable<Loan>> GetAllLoan()
        {
            var loans = await app.Loans.AsNoTracking().ToListAsync();
            return loans;
        }

        public async Task<Loan> GetLoanById(int id)
        {
            var loan = await app.Loans.FindAsync(id);
            if (loan is null) { throw new Exception("the loan was not found"); }

            return loan;
        }

        public async Task RemoveLoan(int id)
        {
            var loan = await GetLoanById(id);
            app.Loans.Remove(loan);
            await app.SaveChangesAsync();
        }

        public async Task UpdateLoan(int id, Loan Nloan)
        {
            var loan = await GetLoanById(id);

            loan.Amount = Nloan.Amount;
            loan.InterestRate = Nloan.InterestRate;
            loan.DueDate = Nloan.DueDate;
            loan.DueDate = Nloan.StartDate;
            loan.CreditorId = Nloan.CreditorId;
            loan.Status = Nloan.Status;

            app.Loans.Update(loan);
            await app.SaveChangesAsync();
        }
    }
}