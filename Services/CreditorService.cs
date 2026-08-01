using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPrestamos.Api.Data;
using AppPrestamos.Api.DTOs.CreditorDTO;
using AppPrestamos.Api.interfaces;
using AppPrestamos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppPrestamos.Api.Services
{
    public class CreditorService(AppPrestamosDbContext app) : ICreditorService
    {
        public async Task<Creditor> GetCreditorById(int id)
        {
            var creditor = await app.Creditors.FindAsync(id);

            if (creditor is null)
            {
                throw new Exception("The Creditor was not found");
            }

            return creditor;
        }

        public async Task<IEnumerable<Creditor>> GetAllCreditor()
        {
            var creditors = await app.Creditors.AsNoTracking().ToListAsync();
            return creditors;
        }

        public async Task AddCreditor(Creditor creditor)
        {
            await app.Creditors.AddAsync(creditor);
            await app.SaveChangesAsync();
        }

        public async Task RemoveCreditor(int id)
        {
            var creditor = await GetCreditorById(id);

            app.Creditors.Remove(creditor);
            await app.SaveChangesAsync();
        }

        public async Task UpdateCreditor(int id, Creditor Ncreditor)
        {
            var creditor = await GetCreditorById(id);

            creditor.Name = Ncreditor.Name;
            creditor.LastName = Ncreditor.LastName;
            creditor.Email = Ncreditor.Email;
            creditor.Phone = Ncreditor.Phone;
            creditor.Age = Ncreditor.Age;
            creditor.Type = Ncreditor.Type;
            creditor.Address =  Ncreditor.Address;

            app.Creditors.Update(creditor);

        }

    }
}