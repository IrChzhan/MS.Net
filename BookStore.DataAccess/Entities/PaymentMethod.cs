using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DataAccess.Entities;

[Table("payment_methods")]
public class PaymentMethod
{
    public int Id { get; set; }
    
    public string PaymentName { get; set; }
    
    public string Description { get; set; }
    
    public List<Payment> Payments { get; set; }
}