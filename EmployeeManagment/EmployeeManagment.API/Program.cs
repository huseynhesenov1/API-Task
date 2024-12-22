using EmployeeManagment.BL.DTOs.DepartmentDTOs;
using EmployeeManagment.BL.Services.Abstractions;
using EmployeeManagment.BL.Services.Implementations;
using EmployeeManagment.Data.DAL;
using EmployeeManagment.Data.Repostories.Abstactions;
using EmployeeManagment.Data.Repostories.Implementations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(opt =>

    opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));

builder.Services.AddScoped<IEmployeeRepostory, EmployeeRepostory>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IDepartmentRepostory, DepartmentRepostory>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();



builder.Services.AddValidatorsFromAssembly(typeof(DepartmentCreateDtoValidation).Assembly);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
