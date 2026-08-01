using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPrestamos.Domain.Entities;

namespace AppPrestamos.Api.interfaces
{
    public interface ICreditorService
    {
        public Task<Creditor> GetCreditorById(int id);
        public Task<IEnumerable<Creditor>> GetAllCreditor();
        public Task AddCreditor(Creditor creditor);
        public Task RemoveCreditor(int id);
        public Task UpdateCreditor(int id, Creditor Ncreditor);


    }
}