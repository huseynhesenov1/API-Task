using StoreManagment.BL.DTOs.CatagoryDtos;
using StoreManagment.BL.DTOs.ProductDtos;
using StoreManagment.Core.Entities;

namespace StoreManagment.BL.Services.Abstractions;

public interface ICatagoryService
{
    Task<ICollection<Catagory>> GetAllAsync();
    Task<Catagory> GetByIdAsync(int id);
    Task<Catagory> CreateAsync(CatagoryDto catagoryDto);
    Task<Catagory> UpdateAsync(int id, CatagoryDto catagoryDto);
    Task<Catagory> SoftDeleteAsync(int id);
}
