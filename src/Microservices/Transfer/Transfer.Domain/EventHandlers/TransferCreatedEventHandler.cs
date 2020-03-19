using Domain.Core.Bus;
using Domain.Core.Events.Banking.Base;
using System.Threading.Tasks;

namespace Transfer.Domain.EventHandlers
{
    public class TransferCreatedEventHandler : IEventHandler<TransferCreatedEvent>
    {
        public TransferCreatedEventHandler()
        { 
            
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
