namespace BookStore.BL.UnitTest;

public class Tests
{
    [TearDown]
    public void Initialize()
    {
        
    }

    [TearDown]
    public void CleanUp()
    {
        
    }
    
    [SetUp]
    public void Setup()
    {
        //создаем "базу даннных заново"
        //очистка
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        //подключаем сервисы
        //натсраиваем маппер
        //иницивлзируем базу данных
        //создаем тестового пользователя
        
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}