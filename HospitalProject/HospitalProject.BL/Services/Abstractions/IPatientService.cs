using HospitalProject.BL.DTOs;
using HospitalProject.Core.Entities;

namespace HospitalProject.BL.Services.Abstractions
{
    public interface IPatientService
    {
        Task<ICollection<Patient>> GetAllAsync();
        Task<Patient> CreateAsync(PatinetCreateDto patinetCreateDto);
        Task<Patient> GetByIdAsync(int id);
        Task<Patient> SoftDeleteAsync(int id);
        Task<Patient> UpdateAsync(int id, PatinetCreateDto patinetCreateDto);

    }
}
