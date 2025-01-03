using StoreManagment.BL.DTOs.ProductDtos;
using StoreManagment.Core.Entities;

namespace StoreManagment.BL.Services.Abstractions;

public interface IProductService
{
    Task<ICollection<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> CreateAsync(ProductCreateDto productCreateDto);
    Task<Product> UpdateAsync(int id,ProductCreateDto productCreateDto);
    Task<Product> SoftDeleteAsync(int id);
   
}
