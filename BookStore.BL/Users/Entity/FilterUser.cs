
namespace BookStore.BL.Users.Entity;


public class FilterUser
{
    public string? Role { get; set; }
    public string? LoginPart { get; set; }
    public string? NamePart { get; set; }
    public string? PhoneNumberPart { get; set; }
    
    public DateTime? CreationTime { get; set; }
    public DateTime? ModificationTime { get; set; }
}