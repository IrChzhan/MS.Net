using System.ComponentModel.DataAnnotations.Schema;
using MS.Net.DataAccess.Entities;

namespace BookStore.DataAccess.Entities;

[Table("orders")]
public class Order : BaseEntity
{
    public DateTime CreationDate { get; set; }
    
    public string status { get; set; }
    
    public int UserId { get; set; }
    
    [ForeignKey("UserId")]
    public User User { get; set; }
    
    public ICollection<Book> Books { get; set; }
}