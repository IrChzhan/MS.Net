using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace BookStore.Service.Controllers.Users.Entities;

public class RegisterUserRequest
{
    [Required(ErrorMessage = "Username must be not empty!")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Password must be not empty!")]
    public string PasswordHash { get; set; }

}