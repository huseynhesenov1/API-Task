using AcademicManagment.BL.DTOs;
using AcademicManagment.BL.Services.Abstractions;
using AcademicManagment.Core.Entities;
using AcademicManagment.Data.Contexts;
using AcademicManagment.Data.Repostory.Abstraction;
using AutoMapper;

namespace AcademicManagment.BL.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepostory _prodRepo;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public ProductService(IProductRepostory prodRepo, IMapper mapper, AppDbContext context)
    {
        _prodRepo = prodRepo;
        _mapper = mapper;
        _context = context;
    }
    public async Task<Product> Update(int id, ProductCreateDto productdto)
    {
        Product product = await _prodRepo.GetByIdAsync(id);
        Product updateProduct = _mapper.Map<Product>(productdto);
        updateProduct.CreateAt = product.CreateAt;
        updateProduct.Id = id;
        updateProduct.UpdateAt = DateTime.Now;
        _prodRepo.Update(updateProduct);
        _context.SaveChanges();
        return updateProduct;
    }
    public async Task<bool> SoftDeleteAsync(int id)
    {
        Product deletedProduct = await _prodRepo.GetByIdAsync(id);
        _prodRepo.SoftDelete(deletedProduct);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _prodRepo.GetByIdAsync(id);
    }

    public async Task<Product> CreateAsync(ProductCreateDto productCreateDto)
    {
        Product product = _mapper.Map<Product>(productCreateDto);
        product.CreateAt = DateTime.UtcNow.AddHours(4);
        var createEntity = await _prodRepo.CreateAsync(product);
        await _context.SaveChangesAsync();
        return createEntity;


    }

    public async Task<ICollection<Product>> GetAllAsync()
    {
        return await _prodRepo.GetAllAsync();
    }


}
