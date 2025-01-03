using AutoMapper;
using StoreManagment.BL.DTOs.ColorDTOs;
using StoreManagment.BL.DTOs.ProductDtos;
using StoreManagment.BL.Exceptions.ProductExceptions;
using StoreManagment.BL.Services.Abstractions;
using StoreManagment.Core.Entities;
using StoreManagment.DAL.Contexts;
using StoreManagment.DAL.Repostories.Abstractions;

namespace StoreManagment.BL.Services.Implementations;

public class ColorService : IColorService
{
    private readonly IColorRepostory _colorRepo;
    private readonly AppDBContext _context;
    private readonly IMapper _mapper;
    public ColorService(IColorRepostory colorRepo, AppDBContext context, IMapper mapper)
    {
        _colorRepo = colorRepo;
        _context = context;
        _mapper = mapper;
    }
    public async Task<Color> CreateAsync(ColorDto colorDto)
    {
        Color color = _mapper.Map<Color>(colorDto);
        color.CreateAt = DateTime.UtcNow.AddHours(4);
        var res = await _colorRepo.CreateAsync(color);
        await _context.SaveChangesAsync();
        return res;
    }

    public async Task<ICollection<Color>> GetAllAsync()
    {
        return await _colorRepo.GetAllAsync();
    }

    public async Task<Color> GetByIdAsync(int id)
    {
        var res = await _colorRepo.GetByIdAsync(id);
        if (res == null)
        {
            throw new NotFoundExceptions("Not Found");
        }
        return res;
    }

    public async Task<Color> UpdateAsync(int id, ColorDto colorDto)
    {
        Color color = await _colorRepo.GetByIdForUpdateAsync(id);
        if (color == null)
        {
            throw new NotFoundExceptions("Not Found");
        }
        Color updateColor = _mapper.Map<Color>(colorDto);
        updateColor.CreateAt = color.CreateAt;
        updateColor.Id = id;
        updateColor.IsDeleted = color.IsDeleted;
        updateColor.UpdateAt = DateTime.UtcNow.AddHours(4);
        var res = _colorRepo.Update(updateColor);
        await _context.SaveChangesAsync();
        return res;
    }
    public async Task<Color> SoftDeleteAsync(int id)
    {
        Color color = await _colorRepo.GetByIdAsync(id);
        if (color == null)
        {
            throw new NotFoundExceptions("Not Found");
        }
        color.DeleteAt = DateTime.UtcNow.AddHours(4);
        var res = _colorRepo.SoftDelete(color);
        await _context.SaveChangesAsync();
        return color;
    }
}
