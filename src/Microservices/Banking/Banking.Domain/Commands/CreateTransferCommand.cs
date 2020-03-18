using Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Domain.Commands
{
    public class CreateTransferCommand : Command
    {
        public int From { get; protected set; }
        public int To { get; protected set; }
        public decimal Amount { get; protected set; }

        public CreateTransferCommand(int from, int to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}
