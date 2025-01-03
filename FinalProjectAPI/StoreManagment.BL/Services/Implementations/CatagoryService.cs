using AutoMapper;
using StoreManagment.BL.DTOs.CatagoryDtos;
using StoreManagment.BL.DTOs.ProductDtos;
using StoreManagment.BL.Exceptions.ProductExceptions;
using StoreManagment.BL.Services.Abstractions;
using StoreManagment.Core.Entities;
using StoreManagment.DAL.Contexts;
using StoreManagment.DAL.Repostories.Abstractions;
using System.Drawing;

namespace StoreManagment.BL.Services.Implementations;

public class CatagoryService : ICatagoryService
{
    private readonly ICatagoryRepostory _catagoryRepo;
    private readonly AppDBContext _context;
    private readonly IMapper _mapper;

    public CatagoryService(ICatagoryRepostory catagoryRepo, IMapper mapper, AppDBContext context)
    {
        _catagoryRepo = catagoryRepo;
        _mapper = mapper;
        _context = context;
    }

    public async Task<Catagory> CreateAsync(CatagoryDto catagoryDto)
    {
        Catagory catagory = _mapper.Map<Catagory>(catagoryDto);
        catagory.CreateAt = DateTime.UtcNow.AddHours(4);
        var res = await _catagoryRepo.CreateAsync(catagory);
        await _context.SaveChangesAsync();
        return res;
    }

    public async Task<ICollection<Catagory>> GetAllAsync()
    {
        return await _catagoryRepo.GetAllAsync();
    }

    public async Task<Catagory> GetByIdAsync(int id)
    {
        var res =  await _catagoryRepo.GetByIdAsync(id);
        if ( res == null)
        {
            throw new NotFoundExceptions("Not Found");
        }
        return res;
    }

    public async Task<Catagory> UpdateAsync(int id, CatagoryDto catagoryDto)
    {
        Catagory catagory = await _catagoryRepo.GetByIdForUpdateAsync(id);
        if (catagory == null)
        {
            throw new NotFoundExceptions("Not Found");
        }
        Catagory updateCatagory = _mapper.Map<Catagory>(catagoryDto);
        updateCatagory.CreateAt = catagory.CreateAt;
        updateCatagory.Id = id;
        updateCatagory.IsDeleted = catagory.IsDeleted;
        updateCatagory.UpdateAt = DateTime.UtcNow.AddHours(4);
        var res = _catagoryRepo.Update(updateCatagory);
        await _context.SaveChangesAsync();
        return res;
    }
    public async Task<Catagory> SoftDeleteAsync(int id)
    {
        Catagory catagory = await _catagoryRepo.GetByIdAsync(id);
        if (catagory == null)
        {
            throw new NotFoundExceptions("Not Found");
        }
        catagory.DeleteAt = DateTime.UtcNow.AddHours(4);
        var res = _catagoryRepo.SoftDelete(catagory);
        await _context.SaveChangesAsync();
        return catagory;
    }
}
