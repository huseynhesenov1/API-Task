using EmployeeManagment.BL;
using EmployeeManagment.BL.DTOs.DepartmentDTOs;
using EmployeeManagment.BL.Profiles.DepartmentProfiles;
using EmployeeManagment.BL.Services.Abstractions;
using EmployeeManagment.BL.Services.Implementations;
using EmployeeManagment.Core.Entities;
using EmployeeManagment.Data.DAL;
using EmployeeManagment.Data.Repostories.Abstactions;
using EmployeeManagment.Data.Repostories.Implementations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(opt =>

    opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));


builder.Services.AddRepostory();
builder.Services.AddBussinesServices();
builder.Services.AddIdentity<AppUser,IdentityRole>(
    opt =>
    {
        opt.Password.RequiredLength = 8;
        opt.User.RequireUniqueEmail = true;
        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
        opt.Lockout.MaxFailedAccessAttempts = 4;
    }
    ).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAutoMapper(typeof(DepartmentProfile).Assembly);
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
