using BookStore.BL.Users.Entity;

namespace BookStore.BL.Users.Manager;

public interface IUsersManager
{
    UserModel CreateUser(CreateUserModel createModel);
    void DeleteUser(int id);
}