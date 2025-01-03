using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreManagment.BL.ConfigrationManagers;
using StoreManagment.Core.Entities;
using StoreManagment.DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddValidation();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));
builder.Services.AddIdentity<AppUser, IdentityRole>(
    opt =>
    {
        opt.Password.RequiredLength = 8;
        opt.User.RequireUniqueEmail = true;
        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
        opt.Lockout.MaxFailedAccessAttempts = 5;
    }
    ).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDBContext>();
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
