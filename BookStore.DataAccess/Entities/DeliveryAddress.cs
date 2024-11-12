using System.ComponentModel.DataAnnotations.Schema;
using BookStore.DataAccess.Entities;

namespace MS.Net.DataAccess.Entities;

[Table("delivery_addresses")]
public class DeliveryAddress : BaseEntity
{
    public string Country { get; set; }
    
    public string City { get; set; }
    
    public int MailIndex { get; set; }
    
    public int UserId { get; set; }
    
    [ForeignKey("UserId")]
    public User User { get; set; }
}