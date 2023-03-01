using Entity.ViewModels.AppUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.Utilities.Validations.Account;

public class RegisterValidation:AbstractValidator<RegisterVM>
{
	public RegisterValidation()
	{
		RuleFor(c=>c.Username).NotEmpty().WithMessage("User name is null!").NotNull().MinimumLength(6);
		RuleFor(c => c.Password).NotEmpty().NotNull().WithMessage("Password is null!");
		RuleFor(c => c.ConfirmedPassword).NotEmpty().NotNull();
		RuleFor(c => c.Mail).MaximumLength(255).MinimumLength(3).NotNull().NotEmpty().Must(MailRegex).WithMessage("Mail is not correct!");
	}
	private bool MailRegex(string regex)
	{
		var mailRegex = "^([a-zA-Z0-9]+([\\._\\-]{1})?){1,}[\\w]\\@{1}([a-zA-Z]+([\\.]{1})?){1,}([a-zA-Z])\\.[a-zA-Z]+$";
		Regex regex1 = new Regex(regex);
		if (regex1.IsMatch(regex))
		{
			return true;
		}
		return false;

    }
}
