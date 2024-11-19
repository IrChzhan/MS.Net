namespace BookStore.Service.Settings;

public class BookStoreSettingsReader
{
    public static BookStoreSettings Read(IConfiguration configuration)
    {
        return new BookStoreSettings()
        {
            ServiceUri = configuration.GetValue<Uri>("Uri"),
            BookStoreDBContextConnectionString = configuration.GetValue<string>("BookStoreDBContext")
        };
    }
}