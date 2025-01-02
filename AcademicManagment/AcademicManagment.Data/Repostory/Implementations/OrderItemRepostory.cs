using AcademicManagment.Core.Entities;
using AcademicManagment.Data.Contexts;
using AcademicManagment.Data.Repostory.Abstraction;

namespace AcademicManagment.Data.Repostory.Implementations
{
    public class OrderItemRepostory : GenericRepostory<OrderItem>, IOrderItemRepostory
    {
        public OrderItemRepostory(AppDbContext context) : base(context)
        {
        }
    }
}
