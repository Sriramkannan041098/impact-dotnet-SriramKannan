using System;
using System.Collections.Generic;
using System.Text;

namespace A3_ExceptionsDisposalAsync.ExceptionalHandling
{  

    public class BankAccount
    {
        private decimal balance;

        // Constructor
        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
            Console.WriteLine($"Amount Deposited : {balance:C}");
        }

        // additioanl method
        public string CurrentBalanceStatus()
        {
            return ($"\nYour Current Balance {balance:C}");
        }

        // additioanl method
        public string CreditedAmount(int credited)
        {
            try
            {
                return ($"\nCredited Amount : {credited:C} \nYour Current Balance : {balance += credited:C} \nCredit attempt logged");
            }
            catch (Exception ex)
            {
                return ($"Unexpected error: {ex.Message}");
            }
        }

        public void Withdraw(decimal amount)
        {
            try
            {
                Console.WriteLine($"Withdrawal request: {amount:C}");

                if (amount <= 0)
                {
                    throw new ArgumentException(
                        "Withdrawal amount must be greater than zero."
                    );
                }

                if (amount > balance)
                {
                    decimal deficit = amount - balance;

                    throw new InsufficientFundsException(deficit);
                }

                balance -= amount;

                Console.WriteLine($"Withdrawal successful: {amount:C}");

                Console.WriteLine($"Remaining balance: {balance:C}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                Console.WriteLine($"Deficit Amount: {ex.DeficitAmount:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                // This always executes
                Console.WriteLine("Withdrawal attempt logged." );
            }
        }


        public void ParseAmount(string input)
        {
            try
            {
                decimal amount =  decimal.Parse(input);
                Console.WriteLine($"Parsed amount: {amount:C}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Format error: {ex.Message}");  // this is thrown when char is passed rather than numbers as input
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Overflow error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
            }
        }
    }
}
