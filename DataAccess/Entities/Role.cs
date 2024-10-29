using System.ComponentModel.DataAnnotations.Schema;

namespace MS.Net.DataAccess.Entities;

[Table("roles")]
public class Role
{
    public int Id { get; set; }
    
    public string RoleValue { get; set; }
    
    public List<User> Users { get; set; }
}