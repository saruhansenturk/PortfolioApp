using FluentValidation;
using PortfolioApp.Application.Dtos;

namespace PortfolioApp.Application.Validators.ProgrammingLanguages
{
    public class CreateProgrammingLanguageTechsValidator : AbstractValidator<CreateProgrammingLanguageTechDto>
    {
        public CreateProgrammingLanguageTechsValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lutfen programlama dilini bos gecmeyiniz")
                .MaximumLength(150)
                .MinimumLength(1)
                .WithMessage("Lutfen programlama dilini 3 ile 150 karakter arasında giriniz!");

            RuleFor(t => t.Level)
                .Must(t => t > 0)
                .Must(t => t <= 100)
                .NotNull();
        }
    }
}
