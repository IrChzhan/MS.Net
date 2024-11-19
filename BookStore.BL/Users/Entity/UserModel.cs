namespace BookStore.BL.Users.Entity;

public class UserModel
{
    public int Id { get; set; }
    public string Role { get; set; }
    public string Name { get; set; }
    public string PasswordHash { get; set; }
    
    public string Login { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
}