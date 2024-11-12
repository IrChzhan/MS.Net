using System.ComponentModel.DataAnnotations.Schema;
using MS.Net.DataAccess.Entities;

namespace BookStore.DataAccess.Entities;

[Table("buckets")]
public class Bucket : BaseEntity
{
    public int UserId { get; set; }
    
    public ICollection<Book> Books { get; set; }
}

