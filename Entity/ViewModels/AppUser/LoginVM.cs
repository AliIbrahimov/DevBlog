using System.ComponentModel.DataAnnotations;

namespace Entity.ViewModels.AppUser;

public class LoginVM
{
    public string Mail { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
