using FluentValidation;
using Forum.UI.Models.User;

namespace Forum.UI.ValidationRules.User
{
    public class RegisterValidator : AbstractValidator<RegisterModel>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.UserName)
                   .NotEmpty().WithMessage("Kullanıcı adı boş olamaz")
                   .Length(3, 50).WithMessage("Kullanıcı adı 3 ile 50 karakter arasında olmalıdır");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz");


            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Onay şifreniz eşleşmiyor");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş olamaz")
                .EmailAddress().WithMessage("Geçerli bir email adresi girin");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş olamaz")
                .EmailAddress().WithMessage("Geçerli bir email adresi girin")
                .Matches(@"@").WithMessage("Email '@' içermelidir");


        }
    }
}
