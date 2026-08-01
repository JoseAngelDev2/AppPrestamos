using AppPrestamos.Api.Controllers;
using AppPrestamos.Api.Data;
using AppPrestamos.Api.interfaces;
using AppPrestamos.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var MyConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppPrestamosDbContext>(op =>
{
    op.UseNpgsql(MyConnectionString);
});

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<ICreditorService, CreditorService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFront", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();
app.UseCors("AllowFront");
app.MapControllers();
app.MapSwagger();
app.UseSwaggerUI();
app.UseSwagger();

app.Run();
