using BookStore.BL.Users.Entity;

namespace BookStore.BL.Users.Manager;

public interface IUsersManager
{
    UserModel CreateUser(CreateUserModel createUserModel);

    UserModel UpdateUser(UpdateUserModel updateUserModel);

    void DeleteUser(int id);
}