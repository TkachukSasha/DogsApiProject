using FluentValidation;

namespace Dogs.Application.Dogs.Commands.CreateDog
{
    public class CreateDogCommandValidator : AbstractValidator<CreateDogCommand>
    {
        public CreateDogCommandValidator()
        {
            RuleFor(dog => dog.Name)
                .NotNull().MaximumLength(25);
            RuleFor(dog => dog.Color)
                .NotNull().MaximumLength(25);
            RuleFor(dog => dog.TailLenght)
                .NotEmpty().GreaterThan(0);
            RuleFor(dog => dog.Weight)
                .NotEmpty().GreaterThan(0);
        }
    }
}
