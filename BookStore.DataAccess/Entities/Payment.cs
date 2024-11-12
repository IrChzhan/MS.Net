using System.ComponentModel.DataAnnotations.Schema;
using MS.Net.DataAccess.Entities;

namespace BookStore.DataAccess.Entities;

[Table("payments")]
public class Payment : BaseEntity
{
    public DateTime PaymentDate { get; set; }
    
    public double Sum { get; set; }
    
    public int OrderId{ get; set; }
    
    [ForeignKey("OrderId")]
    public Order Order { get; set; }
    
    public int PaymentId{ get; set; }
    
    [ForeignKey("PaymentId")]
    public PaymentMethod PaymentMethod { get; set; }
}