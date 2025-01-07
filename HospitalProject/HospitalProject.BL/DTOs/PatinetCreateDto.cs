using FluentValidation;
using HospitalProject.Core.Entities;
using HospitalProject.Core.Enum;
using System.Text.RegularExpressions;

namespace HospitalProject.BL.DTOs
{
    public class PatinetCreateDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? DOB { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SeriaNumber { get; set; }
        public string? RegistrationAddress { get; set; }
        public string? CurrentAddress { get; set; }
        public int InsuranceId { get; set; }
        public string? Email { get; set; }
    }
    public class PatinetCreateDtoValidation : AbstractValidator<PatinetCreateDto>
    {
        public PatinetCreateDtoValidation()
        {
            RuleFor(x => x.Email).Must(x => BeValidEmail(x)).WithMessage("Email olsun");
            

            RuleFor(x => x.PhoneNumber).Must(x => BeValidPhoneNumber(x)).WithMessage("PhoneNumber olsun");
        }
        public bool BeValidEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }
        public bool BeValidPhoneNumber(string phoneNumber)
        {
            Regex regex = new Regex(@"^\+994(50|51|55|70|77)\d{7}$");
            Match match = regex.Match(phoneNumber);
            return match.Success;
        }
    }
}
