using AutoMapper;
using EmployeeManagment.BL.DTOs.DepartmentDTOs;
using EmployeeManagment.BL.Exceptions.DepartmentExceptions;
using EmployeeManagment.BL.Services.Abstractions;
using EmployeeManagment.Core.Entities;
using EmployeeManagment.Data.Repostories.Abstactions;

namespace EmployeeManagment.BL.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepostory _departmentRepo;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepostory departmentRepo, IMapper mapper)
        {
            _departmentRepo = departmentRepo;
            _mapper = mapper;
        }

        public async Task<Department> CreateAsync(DepartmentCreateDto departmentCreateDto)
        {
            Department department = _mapper.Map<Department>(departmentCreateDto);
            department.CreateAt = DateTime.UtcNow.AddHours(4);
            var createEntity = await _departmentRepo.CreateAsync(department);
            await _departmentRepo.SavaChangesAsync();
            return createEntity;
        }

        public async Task<ICollection<Department>> GetAllAsync()
        {
            return await _departmentRepo.GetAllAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            if (!await _departmentRepo.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _departmentRepo.GetByIdAsync(id);
        }

        public async Task<Department> SoftDeleteAsync(int id)
        {
            var departmentEntity = await GetByIdAsync(id);
            await _departmentRepo.SoftDeleteAsync(departmentEntity);
            await _departmentRepo.SavaChangesAsync();
            return departmentEntity;
        }

        public async Task<Department> UpdateAsync(int id, DepartmentCreateDto departmentCreateDto)
        {
            var departmentEntity = await GetByIdAsync(id);
            Department updateDepartment = _mapper.Map<Department>(departmentCreateDto);
            updateDepartment.Id = id;
            updateDepartment.UpdateAt = DateTime.UtcNow.AddHours(4);
            _departmentRepo.Update(updateDepartment);
            await _departmentRepo.SavaChangesAsync();
            return updateDepartment;
        }
    }
}
