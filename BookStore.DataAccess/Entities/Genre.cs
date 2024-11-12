using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DataAccess.Entities;

[Table("genres")]
public class Genre
{
    public int Id { get; set; }
    
    public string GenreName { get; set; }
    
    public string GenreDescription { get; set; }
    
    public List<Book> Books { get; set; }
}