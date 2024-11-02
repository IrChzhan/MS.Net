using System.ComponentModel.DataAnnotations.Schema;

namespace MS.Net.DataAccess.Entities;

[Table("books")]
public class Book : BaseEntity
{
    public string Description { get; set; }

    public double Price { get; set; }
    
    public int Count { get; set; }
    
    public int GenreId{ get; set; }
    
    [ForeignKey("GenreId")]
    public Genre Genre { get; set; }
    
    public int AuthorId{ get; set; }
    
    [ForeignKey("AuthorId")]
    public Author Author { get; set; }
    
    public ICollection<Bucket> Buckets { get; set; }
    
    public ICollection<Order> Orders { get; set; }
}