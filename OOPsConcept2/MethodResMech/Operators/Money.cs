using System;
using System.Collections.Generic;
using System.Text;

namespace OOPsConcept2.MethodResMech.Operators
{
    public class Money
    {
        public decimal Amount { get; private set; }

        public string Currency { get; private set; }

        // Constructor
        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        // + operator
        public static Money operator +(Money first, Money second)
        {
            if (first.Currency != second.Currency)
            {
                throw new InvalidOperationException(
                    "Cannot add money with different currencies."
                );
            }

            return new Money(
                first.Amount + second.Amount,
                first.Currency
            );
        }

        // == operator
        public static bool operator ==(Money first, Money second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (first is null || second is null)
            {
                return false;
            }

            return first.Amount == second.Amount &&
                   first.Currency == second.Currency;
        }

        // != operator
        public static bool operator !=(Money first, Money second)
        {
            return !(first == second);
        }

        // > operator
        public static bool operator >(Money first, Money second)
        {
            ValidateCurrency(first, second);

            return first.Amount > second.Amount;
        }

        // < operator
        public static bool operator <(Money first, Money second)
        {
            ValidateCurrency(first, second);

            return first.Amount < second.Amount;
        }

        // Validate currencies
        private static void ValidateCurrency(
            Money first,
            Money second)
        {
            if (first.Currency != second.Currency)
            {
                throw new InvalidOperationException(
                    "Cannot compare money with different currencies."
                );
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Money other)
            {
                return false;
            }

            return this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }
    }
}
