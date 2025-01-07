using AutoMapper;
using HospitalProject.BL.DTOs;
using HospitalProject.BL.Exceptions;
using HospitalProject.BL.Services.Abstractions;
using HospitalProject.Core.Entities;
using HospitalProject.DAL.Contexts;
using HospitalProject.DAL.Repositories.Abstractions;

namespace HospitalProject.BL.Services.Implementations
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository _insRepo;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InsuranceService(IInsuranceRepository insRepo, AppDbContext context, IMapper mapper)
        {
            _insRepo = insRepo;
            _context = context;
            _mapper = mapper;
        }
        public async Task<Insurance> CreateAsync(InsuranceCreateDto  insuranceCreateDto)
        {
            Insurance  insurance = _mapper.Map<Insurance>(insuranceCreateDto);
            await _insRepo.CreateAsync(insurance);
            insurance.CreateAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return insurance;
        }

        public async Task<ICollection<Insurance>> GetAllAsync()
        {
            return await _insRepo.GetAllAsync();
        }

        public async Task<Insurance> GetByIdAsync(int id)
        {
            return await _insRepo.GetByIdAsync(id);
        }

        

        
        public async Task<Insurance> SoftDeleteAsync(int id)
        {
            var res = _insRepo.SoftDelete(await _insRepo.GetByIdAsync(id));
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<Insurance> UpdateAsync(int id, InsuranceCreateDto insuranceCreateDto)
        {
            Insurance insurance = await _insRepo.GetByIdForUpdateAsync(id);
            if (insurance == null)
            {
                throw new CustomNotFoundException("insurance Tapilmadi");
            }
            Insurance updateInsurance = _mapper.Map<Insurance>(insuranceCreateDto);
            updateInsurance.CreateAt = insurance.CreateAt;
            updateInsurance.Id = id;
            updateInsurance.IsDeleted = insurance.IsDeleted;
            updateInsurance.UpdateAt = DateTime.Now;
            var res = _insRepo.Update(updateInsurance);
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
