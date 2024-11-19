using BookStore.BL.Users.Entity;

namespace BookStore.BL.Users.Provider;

public interface IUsersProvider
{
    IEnumerable<UserModel> GetUsers(FilterUser filter = null);
    UserModel GetUserInfo(int id);
}