using System.ComponentModel.DataAnnotations.Schema;
using MS.Net.DataAccess.Entities;

namespace BookStore.DataAccess.Entities;

[Table("authors")]
public class Author : BaseEntity
{
    public string AuthorName { get; set; }
    
    public string Biography { get; set; }
    
    public List<Book> Books { get; set; }
}