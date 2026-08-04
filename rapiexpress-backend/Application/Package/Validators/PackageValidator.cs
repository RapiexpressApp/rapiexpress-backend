using Application.Package.DTOs;
using FluentValidation;

namespace Application.Package.Validators;

public class PackageValidator : AbstractValidator<PackageDto>
{
    public PackageValidator()
    {
        RuleFor(x => x.WarehouseNumber)
            .NotEmpty();

        RuleFor(x => x.Pieces)
            .GreaterThan(0);

        RuleFor(x => x.DeclaredValue)
            .GreaterThanOrEqualTo(0);
    }
}