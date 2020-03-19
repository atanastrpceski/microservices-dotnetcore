using Domain.Core.Commands;

namespace Domain.Core.Models
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
