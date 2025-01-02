using AcademicManagment.Core.Entities;
using AcademicManagment.Data.Contexts;
using AcademicManagment.Data.Repostory.Abstraction;

namespace AcademicManagment.Data.Repostory.Implementations;

public class ProductRepostory : GenericRepostory<Product>, IProductRepostory
{
    public ProductRepostory(AppDbContext context) : base(context)
    {
    }
}