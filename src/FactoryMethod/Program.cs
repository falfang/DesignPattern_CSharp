using FactoryMethod;

public class Program()
{
    /// <summary>
    /// EntryPoint
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        AbstractFactory factory = new AccountFactory();

        AbstractProduct account1 = factory.Create("Ralph Johnson");
        AbstractProduct account2 = factory.Create("Richard Helm");
        AbstractProduct account3 = factory.Create("John Vlissides");
        AbstractProduct account4 = factory.Create("Erich Gamma");

        account1.Use();
        account2.Use();
        account3.Use();
        account4.Use();
    }
}