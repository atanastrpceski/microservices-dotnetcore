using Domain.Core.Bus;
using Domain.Core.Models;
using System.Threading.Tasks;
using Transfer.Domain.Interfaces;
using Transfer.Domain.Models;

namespace Transfer.Domain.EventHandlers
{
    public class TransferCreatedEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;

        public TransferCreatedEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new TransferLog()
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                TrasnferAmount = @event.Amount
            });
            return Task.CompletedTask;
        }
    }
}
