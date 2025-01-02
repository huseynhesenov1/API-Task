using AcademicManagment.BL.DTOs;
using AcademicManagment.Core.Entities;

namespace AcademicManagment.BL.Services.Abstractions;

public interface IProductService
{
    Task<ICollection<Product>> GetAllAsync();
    Task<Product> CreateAsync(ProductCreateDto productdto);
    Task<Product> GetByIdAsync(int  id);
    Task<bool> SoftDeleteAsync (int id);
    Task<Product> Update(int id, ProductCreateDto productdto);
}
