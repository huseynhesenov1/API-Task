using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Storage.Json;
using StoreManagment.BL.DTOs.ProductDtos;
using StoreManagment.BL.Exceptions.ProductExceptions;
using StoreManagment.BL.Services.Abstractions;
using StoreManagment.BL.Utilities;
using StoreManagment.Core.Entities;
using StoreManagment.DAL.Contexts;
using StoreManagment.DAL.Repostories.Abstractions;
using System.Data;
using System.Drawing;

namespace StoreManagment.BL.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepostory _prodRepo;
    private readonly AppDBContext _context;
    private readonly IMapper _mapper;

    public ProductService(IProductRepostory prodRepo, IMapper mapper, AppDBContext context)
    {
        _prodRepo = prodRepo;
        _mapper = mapper;
        _context = context;
    }
    public async Task<Product> CreateAsync(ProductCreateDto productCreateDto)
    {
        if (productCreateDto.Image == null)
        {
            throw new NotFoundExceptions("Img tapilmadi");
        }
        //if (productCreateDto.Image.CheckSize(3))
        //{
        //    throw new NotFoundExceptions("3 den cox pla bilmez");
        //}
        //if (productCreateDto.Image.CheckType())
        //{
        //    throw new NotFoundExceptions("bu type ola bilmez");
        //}


        var folderName = Path.Combine("Resource", "ImageUpload");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        if (!Directory.Exists(pathToSave))
        {
            Directory.CreateDirectory(pathToSave);
        }
        var fileName = productCreateDto.Image.FileName;
        var fullPath = Path.Combine(pathToSave, fileName);
        var dbPath = Path.Combine(folderName, fileName);

        if (System.IO.File.Exists(fullPath))
        {
            fileName = fileName + Guid.NewGuid().ToString();
        }
        using(var stream = new FileStream(fullPath, FileMode.Create))
        {
            productCreateDto.Image.CopyTo(stream);
        }

        Product product = _mapper.Map<Product>(productCreateDto);
        product.ImgPath = fileName;
        product.CreateAt = DateTime.UtcNow.AddHours(4);
        var res = await _prodRepo.CreateAsync(product);
        await _context.SaveChangesAsync();
        return res;
    }
    public async Task<Product> UpdateAsync(int id, ProductCreateDto productCreateDto)
    {
        Product product = await _prodRepo.GetByIdForUpdateAsync(id);
        if (product == null)
        {
            throw new NotFoundExceptions("Not Found");
        }
        Product updateProduct = _mapper.Map<Product>(productCreateDto);
        updateProduct.CreateAt = product.CreateAt;
        updateProduct.Id = id;
        updateProduct.IsDeleted = product.IsDeleted;
        updateProduct.UpdateAt = DateTime.UtcNow.AddHours(4);
        var res = _prodRepo.Update(updateProduct);
        await _context.SaveChangesAsync();
        return res;
    }
    public async Task<Product> SoftDeleteAsync(int id)
    {
        Product product = await _prodRepo.GetByIdAsync(id);
        if (product ==  null)
        {
            throw  new NotFoundExceptions("Not Found");
        }
        product.DeleteAt = DateTime.UtcNow.AddHours(4);
        var res = _prodRepo.SoftDelete(product);
        await _context.SaveChangesAsync();
        return product;
    }
  

    public async Task<ICollection<Product>> GetAllAsync()
    {
        return await _prodRepo.GetAllAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var res = await _prodRepo.GetByIdAsync(id);
        if (res == null)
        {
            throw new NotFoundExceptions("Not Found");
        }
        return res;
    }

     
}
