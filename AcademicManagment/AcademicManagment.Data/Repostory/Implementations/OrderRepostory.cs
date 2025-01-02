using AcademicManagment.Core.Entities;
using AcademicManagment.Data.Contexts;
using AcademicManagment.Data.Repostory.Abstraction;

namespace AcademicManagment.Data.Repostory.Implementations;

public class OrderRepostory : GenericRepostory<Order>, IOrderRepostory
{
    public OrderRepostory(AppDbContext context) : base(context)
    {
    }
}
