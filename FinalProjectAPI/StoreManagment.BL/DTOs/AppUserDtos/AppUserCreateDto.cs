using FluentValidation;
using System.Text.RegularExpressions;

namespace StoreManagment.BL.DTOs.AppUserDtos;

public class AppUserCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    
}
public class AppUserCreateDtoValidation : AbstractValidator<AppUserCreateDto>
{
    public AppUserCreateDtoValidation()
    {
        RuleFor(x => x.Email).Must(x => BeValidEmail(x)).WithMessage("Email olsun");
        RuleFor(x => x.ConfirmPassword)
          .Equal(x => x.Password)
          .WithMessage("Şifrə təsdiqi ilə şifrə eyni olmalıdır.");
    }
    public bool BeValidEmail(string email)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        return match.Success;
    }
   
}