using BookStore.BL.Users.Entity;

namespace BookStore.Service.Controllers.Users.Entities;

public class ListResponse
{
    public List<UserModel> Users { get; set; }
}