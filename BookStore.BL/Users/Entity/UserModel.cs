namespace BookStore.BL.Users.Entity;

public class UserModel
{
    public int Id { get; set; }
    public int  RoleID { get; set; }
    public string Name { get; set; }
    public string PasswordHash { get; set; }
    
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
}