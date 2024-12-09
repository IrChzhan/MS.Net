using BookStore.BL.Auth.Entities;
using BookStore.BL.Users.Entity;

namespace BookStore.BL.Auth;

public interface IAuthProvider
{
    Task<TokensResponce> AuthorizeUser(string login, string password);
    Task<UserModel> RegisterUser(string login, string password);
}