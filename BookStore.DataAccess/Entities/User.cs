using System.ComponentModel.DataAnnotations.Schema;
using MS.Net.DataAccess.Entities;

namespace BookStore.DataAccess.Entities;

[Table("users")]
public class User : BaseEntity
{
    public string Name { get; set; }
    
    public string PasswordHash { get; set; }
    public string Login { get; set; }
    
    public int RoleId { get; set; }
    
    [ForeignKey("RoleId")]
    public Role Role { get; set; }
    
    public List<DeliveryAddress> DeliveryAddresses { get; set; }
    
    public List<Order> Orders { get; set; }
}