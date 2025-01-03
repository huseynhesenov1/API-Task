using AutoMapper;
using StoreManagment.BL.DTOs.ProductDtos;
using StoreManagment.BL.DTOs.SizeDTOs;
using StoreManagment.BL.Exceptions.ProductExceptions;
using StoreManagment.BL.Services.Abstractions;
using StoreManagment.Core.Entities;
using StoreManagment.DAL.Contexts;
using StoreManagment.DAL.Repostories.Abstractions;

namespace StoreManagment.BL.Services.Implementations;

public class SizeService : ISizeService
{
    private readonly ISizeRepostory _sizeRepo;
    private readonly AppDBContext _context;
    private readonly IMapper _mapper;
    public SizeService(ISizeRepostory sizeRepo, AppDBContext context, IMapper mapper)
    {
        _sizeRepo = sizeRepo;
        _context = context;
        _mapper = mapper;
    }

    public async Task<Size> CreateAsync(SizeDto sizeDto)
    {
        Size size = _mapper.Map<Size>(sizeDto);
        size.CreateAt = DateTime.UtcNow.AddHours(4);
        var res = await _sizeRepo.CreateAsync(size);
        await _context.SaveChangesAsync();
        return res;
    }

    public async Task<ICollection<Size>> GetAllAsync()
    {
        return await _sizeRepo.GetAllAsync();
    }

    public async Task<Size> GetByIdAsync(int id)
    {
        var res = await _sizeRepo.GetByIdAsync(id);
        if (res == null)
        {
            throw new NotFoundExceptions("Not Found");
        }
        return res;
    }

    public async Task<Size> UpdateAsync(int id, SizeDto sizeDto)
    {
        Size size = await _sizeRepo.GetByIdForUpdateAsync(id);
        if (size ==  null)
        {
            throw new NotFoundExceptions("Not Found");
        }
        Size updateSize = _mapper.Map<Size>(sizeDto);
        updateSize.CreateAt = size.CreateAt;
        updateSize.Id = id;
        updateSize.IsDeleted = size.IsDeleted;
        updateSize.UpdateAt = DateTime.UtcNow.AddHours(4);
        var res = _sizeRepo.Update(updateSize);
        await _context.SaveChangesAsync();
        return res;
    }
    public async Task<Size> SoftDeleteAsync(int id)
    {
        Size size = await _sizeRepo.GetByIdAsync(id);
        if (size == null)
        {
            throw new NotFoundExceptions("Not Found");
        }
        size.DeleteAt = DateTime.UtcNow.AddHours(4);
        var res = _sizeRepo.SoftDelete(size);
        await _context.SaveChangesAsync();
        return size;
    }
}
