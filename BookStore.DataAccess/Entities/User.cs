using System.ComponentModel.DataAnnotations.Schema;
using MS.Net.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookStore.DataAccess.Entities;

[Table("users")]
public class User : IdentityUser<int>, IBaseEntity
{
    public string Name { get; set; }
    
    public string PasswordHash { get; set; }
    public string Login { get; set; }
    
    public int RoleId { get; set; }
    
    
    public List<DeliveryAddress> DeliveryAddresses { get; set; }
    
    public List<Order> Orders { get; set; }
    public string PhoneNumber { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
    
    public class UserRole : IdentityRole<int>
    {
    }
}