using System.ComponentModel.DataAnnotations.Schema;

namespace MS.Net.DataAccess.Entities;

[Table("users")]
public class User : BaseEntity
{
    public string Name { get; set; }
    
    public string PasswordHash { get; set; }
    
    public int RoleId { get; set; }
    
    [ForeignKey("RoleId")]
    public Role Role { get; set; }
    
    public List<DeliveryAddress> DeliveryAddresses { get; set; }
    
    public List<Order> Orders { get; set; }
}