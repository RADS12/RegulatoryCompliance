using System;

public class BankAccount
{
    private decimal balance;

    public BankAccount(decimal initialBalance = 0)
    {
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative.");
        balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive.");
        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive.");

        if (amount > balance)
            throw new InvalidOperationException("Insufficient funds. Overdraft not allowed.");

        balance -= amount;
    }

    public decimal GetBalance()
    {
        return balance;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            BankAccount account = new BankAccount(100);
            Console.WriteLine("Initial Balance: " + account.GetBalance());

            account.Deposit(50);
            Console.WriteLine("After Deposit: " + account.GetBalance());

            account.Withdraw(30);
            Console.WriteLine("After Withdrawal: " + account.GetBalance());

            account.Withdraw(200); // This triggers overdraft exception
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
