using BookStore.BL.Users.Entity;

namespace BookStore.BL.Users.Provider;

public interface IUsersProvider
{
    IEnumerable<UserModel> GetUsers(UserFilter filter = null);
    UserModel GetUserInfo(int id);
}