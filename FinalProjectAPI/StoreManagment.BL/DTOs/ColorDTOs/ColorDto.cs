using FluentValidation;
using StoreManagment.BL.DTOs.SizeDTOs;

namespace StoreManagment.BL.DTOs.ColorDTOs;

public class ColorDto
{
    public string Name { get; set; }
}
public class ColorDtoValidation : AbstractValidator<ColorDto>
{
    public ColorDtoValidation()
    {

        RuleFor(x => x.Name).MaximumLength(20).WithMessage("20 simvoldan cox ola bilmez").MinimumLength(3).WithMessage("3 simvoldan az ola bilmez");
    }
}