using System.ComponentModel.DataAnnotations.Schema;

namespace MS.Net.DataAccess.Entities;

[Table("buckets")]
public class Bucket : BaseEntity
{
    public int UserId { get; set; }
    
    public ICollection<Book> Books { get; set; }
}

