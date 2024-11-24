using BookStore.BL.Users.Entity;

namespace BookStore.BL.Users.Provider;

public interface IUsersProvider
{
    IEnumerable<UserModel> GetUsers();
    UserModel GetUserInfo(int id);
}