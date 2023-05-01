class Program
{
    static void Main()
    {

        ConsoleLogger logger = new ConsoleLogger();
        BankAccount account1 = new BankAccount("pato", 10, logger);
        BankAccount account2 = new BankAccount("pato", 10000, logger);

        account1.Deposit(-50);

        Console.WriteLine(account1.Balance);
    }
}

class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");

    }
}

interface ILogger
{

    public void Log(string message);
}

class BankAccount
{
    private string name;
    private decimal balance;

    public readonly ILogger logger;

    public decimal Balance
    {
        get; private set;
    }

    public BankAccount(string name, decimal balance, ILogger logger1)
    {

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException("Nome invalido", nameof(name));
        }
        if (balance < 0)
        {
            throw new Exception("Saldo não pode ser negativo");
        }


        this.name = name;
        Balance = balance;
        this.logger = logger1;
    }

    public void Deposit(decimal amount)
    {

        if (amount >= 0)
        {

            Balance += amount;
        }
        else
        {
            logger.Log($"O Deposito não pode ser negativo. Na conta {name}");
        }
    }

    public decimal GetBalance()
    {

        return balance;
    }
}