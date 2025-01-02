using AcademicManagment.BL.Profiles.ProductProfiles;
using AcademicManagment.BL.Services.Abstractions;
using AcademicManagment.BL.Services.Implementations;
using AcademicManagment.Data.Contexts;
using AcademicManagment.Data.Repostory.Abstraction;
using AcademicManagment.Data.Repostory.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepostory, OrderRepostory>();
builder.Services.AddScoped<IOrderItemRepostory, OrderItemRepostory>();
builder.Services.AddScoped<IProductRepostory, ProductRepostory>();
builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
});
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
