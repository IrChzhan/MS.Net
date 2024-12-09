namespace BookStore.Service.Settings;

public class BookStoreSettings
{
    public string? BookStoreContextConnectionString { get; set; }
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? IdentityServerUri { get; set; }
}