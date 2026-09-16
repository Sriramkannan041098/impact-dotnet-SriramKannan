using System;
using System.Collections.Generic;
using System.Text;

namespace OOPs.AccountManagement
{
    public class BankAccount
    {
        // Private fields
        private decimal balance;
        private List<string> history;

        // Constructor
        public BankAccount()
        {
            balance = 0;
            history = new List<string>();
        }

        // Deposit money
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                history.Add($"Deposit failed: Invalid amount {amount}");
                Console.WriteLine("Deposit amount must be greater than zero.");
                return;
            }

            //balance += amount;
            balance = balance + amount;

            history.Add($"Deposited: {amount:C}");
            Console.WriteLine($"Successfully deposited {amount:C}");   // "C" - this is currency format which converts number to currency 
        }

        // Withdraw money
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                history.Add($"Withdraw failed: Invalid amount {amount}");
                Console.WriteLine("Withdraw amount must be greater than zero.");
                return;
            }

            if (amount > balance)
            {
                history.Add($"Withdraw failed: Insufficient balance for {amount:C}");
                Console.WriteLine("Withdrawal rejected: Insufficient balance.");
                return;
            }

            balance -= amount;
            //balance = balance - amount;

            history.Add($"Withdrawn: {amount:C}");
            history.Add($"Current Balance : {balance:C}");
            Console.WriteLine($"Successfully withdrawn {amount:C}");
        }

        // Get current balance
        public void GetBalance()
        {            
            Console.WriteLine($"Current Balance : {balance:C}"); 
        }

        // Print transaction history
        public void TransactionHistory()
        {
            Console.WriteLine("\n--- Transaction History ---");

            if (balance == 0) {
                history.Add($"Current Balance : {balance:C}");
                Console.WriteLine($"Current Balance : {balance:C}");
                return;
            }

            foreach (string item in history)
            {
                Console.WriteLine(item);
            }
        }
    }
}
