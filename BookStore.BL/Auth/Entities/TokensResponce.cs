namespace BookStore.BL.Auth.Entities;

public class TokensResponce
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}