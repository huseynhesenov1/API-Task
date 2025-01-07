using HospitalProject.BL.DTOs;
using HospitalProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.BL.Services.Abstractions
{
    public interface IInsuranceService
    {
        Task<ICollection<Insurance>> GetAllAsync();
        Task<Insurance> CreateAsync(InsuranceCreateDto insuranceCreateDto);
        Task<Insurance> GetByIdAsync(int id);
        Task<Insurance> SoftDeleteAsync(int id);
        Task<Insurance> UpdateAsync(int id, InsuranceCreateDto insuranceCreateDto);
    }
}
