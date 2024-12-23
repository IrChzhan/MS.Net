using System.ComponentModel.DataAnnotations;

namespace BookStore.DataAccess.Entities;

public abstract class BaseEntity
{
    [Key] public int Id { get; set; }

    public DateTime CreationTime { get; set; }
    
    public DateTime ModificationTime { get; set; }

    public void init()
    {
        CreationTime = DateTime.UtcNow;
        ModificationTime = DateTime.UtcNow;
    }
}