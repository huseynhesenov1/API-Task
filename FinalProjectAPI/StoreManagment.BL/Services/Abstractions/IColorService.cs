using StoreManagment.BL.DTOs.CatagoryDtos;
using StoreManagment.BL.DTOs.ColorDTOs;
using StoreManagment.Core.Entities;

namespace StoreManagment.BL.Services.Abstractions;

public interface IColorService
{
    Task<ICollection<Color>> GetAllAsync();
    Task<Color> GetByIdAsync(int id);
    Task<Color> CreateAsync(ColorDto colorDto);
    Task<Color> UpdateAsync(int id, ColorDto colorDto);
    Task<Color> SoftDeleteAsync(int id);
}
