using StoreManagment.Core.Entities;
using StoreManagment.DAL.Contexts;
using StoreManagment.DAL.Repostories.Abstractions;

namespace StoreManagment.DAL.Repostories.Implementations;

public class ProductRepostory : GenericRepostory<Product>, IProductRepostory
{
    public ProductRepostory(AppDBContext context) : base(context)
    {
    }
}
