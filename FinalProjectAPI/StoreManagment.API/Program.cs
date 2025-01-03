using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StoreManagment.BL.ConfigrationManagers;
using StoreManagment.BL.Profiles.CatagoryProfiles;
using StoreManagment.BL.Profiles.ColorProfiles;
using StoreManagment.BL.Profiles.ProductProfiles;
using StoreManagment.BL.Profiles.SizeProfiles;
using StoreManagment.BL.Services.Abstractions;
using StoreManagment.BL.Services.Implementations;
using StoreManagment.DAL.Contexts;
using StoreManagment.DAL.Repostories.Abstractions;
using StoreManagment.DAL.Repostories.Implementations;
using StoreManagment.BL.DTOs.ProductDtos;
using StoreManagment.BL.DTOs.SizeDTOs;
using StoreManagment.BL.DTOs.ColorDTOs;
using StoreManagment.BL.DTOs.CatagoryDtos;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddValidation();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));
builder.Services.AddAutoMapper();
builder.Services.AddService();
builder.Services.AddRepostory();
var app = builder.Build();

 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
