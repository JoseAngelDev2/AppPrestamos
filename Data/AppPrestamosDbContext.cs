using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPrestamos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppPrestamos.Api.Data
{
    public class AppPrestamosDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Creditor> Creditors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}