using FluentValidation;
using StoreManagment.Core.Entities;

namespace StoreManagment.BL.DTOs.ProductDtos;

public class ProductCreateDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CatagoryId { get; set; }
    public int SizeId { get; set; }
    public int? ColorId { get; set; }
}
public class ProductCreateDtoValidation: AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidation()
    {
        RuleFor(x => x.Price).NotEmpty().WithMessage("Bosh olmamalidir").NotNull().WithMessage("Null Olmamalidir").
            GreaterThan(0).WithMessage("O-dan boyuk olmalidir deyer");
        RuleFor(x => x.Name).MaximumLength(20).WithMessage("20 simvoldan cox ola bilmez").MinimumLength(3).WithMessage("3 simvoldan az ola bilmez");
    }
}