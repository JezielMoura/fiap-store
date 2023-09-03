namespace FiapStore.Application.Users.AddUser;

public class AddUserValidation : AbstractValidator<AddUserCommand>
{
    public AddUserValidation()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("O nome não pode ser vazio");
        RuleFor(c => c.Name).Length(3, 50).WithMessage("O nome deve ter entre 3 e 50 caracteres");
        RuleFor(c => c.Email).NotEmpty().WithMessage("O e-mail não pode ser vazio");
        RuleFor(c => c.Email).Length(3, 50).WithMessage("O e-mail deve ter entre 3 e 50 caracteres");
        RuleFor(c => c.Password).NotEmpty().WithMessage("A senha não pode ser vazia");
        RuleFor(c => c.Password).Length(3, 50).WithMessage("A senha deve ter entre 8 e 16 caracteres");
    }
}