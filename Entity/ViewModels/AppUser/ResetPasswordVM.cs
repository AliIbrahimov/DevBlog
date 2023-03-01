using System.ComponentModel.DataAnnotations;

namespace Entity.ViewModels.AppUser;

public class ResetPasswordVM
{
    public string Mail { get; set; }
    public string Token { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.Password), Compare(nameof(Password))]

    public string ComfirmPassword { get; set; }
}
