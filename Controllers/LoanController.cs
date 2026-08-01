using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPrestamos.Api.DTOs.LoanDTO;
using AppPrestamos.Api.interfaces;
using AppPrestamos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppPrestamos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController(ILoanService service) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadLoanDTO>> GetLoanById(int id)
        {
            var loan = await service.GetLoanById(id);
            var loanDto = new ReadLoanDTO
            {
                Id = loan.Id,
                Amount = loan.Amount,
                StartDate = loan.StartDate,
                DueDate = loan.DueDate,
                InterestRate = loan.InterestRate,
                Status = loan.Status
            };

            return Ok(loanDto);
        }

        [HttpGet]
         public async Task<ActionResult<IEnumerable<ReadLoanDTO>>> GetAllLoan()
        {
            var loans = await service.GetAllLoan();

            return Ok(loans.Select(loan => new ReadLoanDTO
            {
                Id = loan.Id,
                Amount = loan.Amount,
                StartDate = loan.StartDate,
                DueDate = loan.DueDate,
                InterestRate = loan.InterestRate,
                Status = loan.Status
            }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLoan(int id, CreateLoanDTO Nloan)
        {
            var loan = await service.GetLoanById(id);

            loan.Amount = Nloan.Amount;
            loan.StartDate = Nloan.StartDate;
            loan.InterestRate = Nloan.InterestRate;
            loan.Status = LoanStatus.Active;
            loan.CreditorId = Nloan.CreditorId;

            await service.UpdateLoan(id, loan);

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult> AddLoan(CreateLoanDTO loan)
        {
            var Nloan = new Loan
            {
                Amount = loan.Amount,
                StartDate = loan.StartDate,
                InterestRate = loan.InterestRate,
                Status = LoanStatus.Active,
                CreditorId = loan.CreditorId
            };

            await service.AddLoan(Nloan);

            return Created();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> RemoveLoan(int id)
        {
            await service.RemoveLoan(id);
            return NoContent();
        }

    }
}