using HospitalProject.BL.DTOs;
using HospitalProject.BL.Profiles;
using HospitalProject.BL.Services.Abstractions;
using HospitalProject.BL.Services.Implementations;
using HospitalProject.DAL.Contexts;
using HospitalProject.DAL.Repositories.Abstractions;
using HospitalProject.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));
        builder.Services.AddScoped<IPatientService, PatientService>();
        builder.Services.AddScoped<IInsuranceService, InsuranceService>();
        builder.Services.AddScoped<IInsuranceRepository, InsuranceRepository>();
        builder.Services.AddScoped<IPatientRepository, PatientRepository>();
        builder.Services.AddAutoMapper(typeof(PatinetProfile).Assembly);
        builder.Services.AddAutoMapper(typeof(InsuranceProfile).Assembly);
        builder.Services.AddAutoMapper(typeof(PatinetCreateDtoValidation).Assembly);
        builder.Services.AddValidatorsFromAssembly(typeof(PatinetCreateDtoValidation).Assembly);
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddFluentValidationClientsideAdapters();
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
    }
}