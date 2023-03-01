using System.ComponentModel.DataAnnotations;

namespace Entity.ViewModels.AppUser;

public class RegisterVM
{
    public string Username { get; set; }
    public string Mail { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool isDeveloper { get; set; }
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public string ConfirmedPassword { get; set; }
}
