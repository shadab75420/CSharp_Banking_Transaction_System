using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem
{
    class Transaction
    {
        public string TransactionId { get; set; }
        public double Amount { get; set; }
        public string AccountId { get; set; }
    }

    class BankingSystem
    {
        private List<Transaction> transactionHistory = new List<Transaction>();
        private Dictionary<string, double> accountBalances = new Dictionary<string, double>();
        private Queue<Transaction> pendingTransactions = new Queue<Transaction>();
        private Stack<Transaction> rollbackStack = new Stack<Transaction>();
        private HashSet<string> transactionIds = new HashSet<string>();

        public void CreateAccount(string accountId, double initialBalance)
        {
            if (!accountBalances.ContainsKey(accountId))
            {
                accountBalances[accountId] = initialBalance;
                Console.WriteLine($"Account {accountId} created with balance {initialBalance}");
            }
            else
            {
                Console.WriteLine($"Account {accountId} already exists.");
            }
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transactionIds.Add(transaction.TransactionId))
            {
                pendingTransactions.Enqueue(transaction);
                Console.WriteLine($"Transaction {transaction.TransactionId} added to pending queue");
            }
            else
            {
                Console.WriteLine($"Duplicate transaction ID {transaction.TransactionId} detected. Ignored.");
            }
        }

        public void ProcessNextTransaction()
        {
            if (pendingTransactions.Count > 0)
            {
                var transaction = pendingTransactions.Dequeue();
                if (accountBalances.ContainsKey(transaction.AccountId))
                {
                    accountBalances[transaction.AccountId] += transaction.Amount;
                    transactionHistory.Add(transaction);
                    rollbackStack.Push(transaction);
                    Console.WriteLine($"Transaction {transaction.TransactionId} processed for account {transaction.AccountId}, amount {transaction.Amount}");
                }
                else
                {
                    Console.WriteLine($"Account {transaction.AccountId} not found. Transaction {transaction.TransactionId} failed.");
                }
            }
        }

        public void RollbackLastTransaction()
        {
            if (rollbackStack.Count > 0)
            {
                var transaction = rollbackStack.Pop();
                if (accountBalances.ContainsKey(transaction.AccountId))
                {
                    accountBalances[transaction.AccountId] -= transaction.Amount;
                    transactionHistory.Remove(transaction);
                    Console.WriteLine($"Transaction {transaction.TransactionId} rolled back for account {transaction.AccountId}");
                }
            }
        }

        public void ShowBalances()
        {
            Console.WriteLine("Account Balances:");
            foreach (var account in accountBalances)
            {
                Console.WriteLine($"Account {account.Key}: Balance {account.Value}");
            }
        }

        public void ShowTransactions()
        {
            Console.WriteLine("Transaction History:");
            foreach (var transaction in transactionHistory)
            {
                Console.WriteLine($"ID: {transaction.TransactionId}, Account: {transaction.AccountId}, Amount: {transaction.Amount}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankingSystem system = new BankingSystem();

            system.CreateAccount("AliceSavings", 5000);
            system.CreateAccount("BobChecking", 3000);

            system.AddTransaction(new Transaction { TransactionId = "SalaryCreditApril", AccountId = "AliceSavings", Amount = 2000 });
            system.AddTransaction(new Transaction { TransactionId = "RentPaymentApril", AccountId = "AliceSavings", Amount = -1500 });
            system.AddTransaction(new Transaction { TransactionId = "GroceryShopping", AccountId = "BobChecking", Amount = -300 });
            system.AddTransaction(new Transaction { TransactionId = "SalaryCreditApril", AccountId = "AliceSavings", Amount = 2500 }); // Duplicate

            system.ProcessNextTransaction();
            system.ProcessNextTransaction();
            system.ProcessNextTransaction();

            system.ShowBalances();
            system.ShowTransactions();

            system.RollbackLastTransaction();

            system.ShowBalances();
            system.ShowTransactions();
        }
    }
}
