using StoreManagment.Core.Entities;
using StoreManagment.DAL.Contexts;
using StoreManagment.DAL.Repostories.Abstractions;

namespace StoreManagment.DAL.Repostories.Implementations;

public class SizeRepostory : GenericRepostory<Size>, ISizeRepostory
{
    public SizeRepostory(AppDBContext context) : base(context)
    {
    }
}
