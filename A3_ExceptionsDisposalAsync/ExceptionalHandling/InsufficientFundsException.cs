using System;
using System.Collections.Generic;
using System.Text;

namespace A3_ExceptionsDisposalAsync.ExceptionalHandling
{
    public class InsufficientFundsException : Exception
    {
        public decimal DeficitAmount { get; }

        // Constructor
        public InsufficientFundsException(
            decimal deficitAmount)
            : base(
                $"Insufficient funds. " +
                $"Deficit: {deficitAmount:C}")
        {
            DeficitAmount = deficitAmount;
        }

    }

}