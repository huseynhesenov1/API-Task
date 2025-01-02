using AcademicManagment.BL.DTOs;
using AcademicManagment.BL.Services.Abstractions;
using AcademicManagment.Core.Entities;
using AcademicManagment.Data.Contexts;
using AcademicManagment.Data.Repostory.Abstraction;
using AutoMapper;

namespace AcademicManagment.BL.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepostory _orderRepo;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public OrderService(IOrderRepostory orderRepo, IMapper mapper, AppDbContext context)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ICollection<Order>> GetAllAsync()
        {
           return await _orderRepo.GetAllAsync();
        }
        public async Task<Order> CreateAsync(OrderCreateDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);
            order.OrderDate = DateTime.UtcNow.AddHours(4);
            order.CreateAt = DateTime.UtcNow.AddHours(4);
            var res = await _orderRepo.CreateAsync(order);
            await _context.SaveChangesAsync();
            return res;
        }
        public async Task<bool> SoftDeleteAsync(int id)
        {
            Order OrderEntity = await _orderRepo.GetByIdAsync(id);
            _orderRepo.SoftDelete(OrderEntity);
            _orderRepo.SaveChanges();
            return true;
        }

        public async Task<Order> Update(int id, OrderCreateDto orderCreateDto)
        {
            Order order =  await _orderRepo.GetByIdAsync(id);
            Order updateOrder = _mapper.Map<Order>(orderCreateDto);
            updateOrder.Id = id;
            updateOrder.CreateAt = order.CreateAt;
            updateOrder.OrderDate = order.OrderDate;
            updateOrder.UpdateAt = DateTime.UtcNow.AddHours(4);
            _orderRepo.Update(updateOrder);
            await _context.SaveChangesAsync();
            return updateOrder;

        }

        
    }
}
