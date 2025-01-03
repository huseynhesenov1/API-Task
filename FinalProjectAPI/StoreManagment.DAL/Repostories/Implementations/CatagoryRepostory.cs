using StoreManagment.Core.Entities;
using StoreManagment.DAL.Contexts;
using StoreManagment.DAL.Repostories.Abstractions;

namespace StoreManagment.DAL.Repostories.Implementations;

public class CatagoryRepostory : GenericRepostory<Catagory>, ICatagoryRepostory
{
    public CatagoryRepostory(AppDBContext context) : base(context)
    {

    }
}
