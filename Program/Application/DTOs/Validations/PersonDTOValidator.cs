using FluentValidation;

namespace Application.DTOs.Validations;
public class PersonDTOValidator : AbstractValidator<PersonDTO> {
    public PersonDTOValidator() {

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Campo obrigatório.");

        RuleFor(x => x.Document)
            .NotEmpty()
            .NotNull()
            .WithMessage("Campo obrigatório.");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .NotNull()
            .WithMessage("Campo obrigatório.");
    }
}
