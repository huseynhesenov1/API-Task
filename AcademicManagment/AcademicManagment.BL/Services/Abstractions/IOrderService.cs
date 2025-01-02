using AcademicManagment.BL.DTOs;
using AcademicManagment.Core.Entities;

namespace AcademicManagment.BL.Services.Abstractions;

public interface IOrderService
{
    Task<Order> CreateAsync(OrderCreateDto orderDto);
    Task<ICollection<Order>> GetAllAsync();
    Task<bool> SoftDeleteAsync(int id);
    Task<Order> Update(int id, OrderCreateDto orderCreateDto);
}