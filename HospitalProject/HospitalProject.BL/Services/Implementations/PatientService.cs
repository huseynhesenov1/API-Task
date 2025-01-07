using AutoMapper;
using HospitalProject.BL.DTOs;
using HospitalProject.BL.Exceptions;
using HospitalProject.BL.Services.Abstractions;
using HospitalProject.Core.Entities;
using HospitalProject.DAL.Contexts;
using HospitalProject.DAL.Repositories.Abstractions;

namespace HospitalProject.BL.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patinetRepo;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patinetRepo, AppDbContext context, IMapper mapper)
        {
            _patinetRepo = patinetRepo;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Patient> CreateAsync(PatinetCreateDto patinetCreateDto)
        {
            Patient patient =  _mapper.Map<Patient>(patinetCreateDto);
            await _patinetRepo.CreateAsync(patient);
            patient.CreateAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<ICollection<Patient>> GetAllAsync()
        {
          return  await _patinetRepo.GetAllAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _patinetRepo.GetByIdAsync(id);
        }

        public async Task<Patient> SoftDeleteAsync(int id)
        {
            var res = _patinetRepo.SoftDelete(await _patinetRepo.GetByIdAsync(id));
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<Patient> UpdateAsync(int id, PatinetCreateDto patinetCreateDto)
        {
            Patient patient = await _patinetRepo.GetByIdForUpdateAsync(id);
            if (patient == null)
            {
               throw new CustomNotFoundException("Patient Tapilmadi");
            }
            Patient updatePatinet =  _mapper.Map<Patient>(patinetCreateDto);  
            updatePatinet.CreateAt = patient.CreateAt;
            updatePatinet.Id = id;
            updatePatinet.IsDeleted = patient.IsDeleted;
            updatePatinet.UpdateAt = DateTime.Now;
            var res =  _patinetRepo.Update(updatePatinet);
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
