using StoreManagment.BL.DTOs.ProductDtos;
using StoreManagment.BL.DTOs.SizeDTOs;
using StoreManagment.Core.Entities;

namespace StoreManagment.BL.Services.Abstractions;

public interface ISizeService
{
    Task<ICollection<Size>> GetAllAsync();
    Task<Size> GetByIdAsync(int id);
    Task<Size> CreateAsync(SizeDto sizeDto);
    Task<Size> UpdateAsync(int id, SizeDto sizeDto);
    Task<Size> SoftDeleteAsync(int id);
}
