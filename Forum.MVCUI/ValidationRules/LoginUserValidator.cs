using FluentValidation;
using Forum.MVCUI.Models.Login;

namespace Forum.MVCUI.ValidationRules
{
    public class LoginUserValidator : AbstractValidator<LoginModel>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı boş olamaz");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz");
        }
    }
}
