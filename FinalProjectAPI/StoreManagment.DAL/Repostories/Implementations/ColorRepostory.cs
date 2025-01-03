using StoreManagment.Core.Entities;
using StoreManagment.DAL.Contexts;
using StoreManagment.DAL.Repostories.Abstractions;

namespace StoreManagment.DAL.Repostories.Implementations;

public class ColorRepostory : GenericRepostory<Color>, IColorRepostory
{
    public ColorRepostory(AppDBContext context) : base(context)
    {
    }
}
