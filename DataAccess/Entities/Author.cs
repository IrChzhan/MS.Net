using System.ComponentModel.DataAnnotations.Schema;

namespace MS.Net.DataAccess.Entities;

[Table("authors")]
public class Author : BaseEntity
{
    public string AuthorName { get; set; }
    
    public string Biography { get; set; }
    
    public List<Book> Books { get; set; }
}