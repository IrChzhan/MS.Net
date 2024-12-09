using BookStore.DataAccess;

namespace BookStore.Service.Settings;

public class BookStoreSettingsReader
{
    public static BookStoreSettings Read(IConfiguration configuration)
    {
        return new BookStoreSettings
        {
            BookStoreContextConnectionString = configuration.GetValue<string>("BeautyShopContext"),
            ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
            ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri")
        };
    }
}