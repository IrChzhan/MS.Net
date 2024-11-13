namespace BookStore.BL.Users.Exception;

public class UserNotFound : ApplicationException
{
    public UserNotFound() {}
    public UserNotFound(string message) : base(message) {}
}