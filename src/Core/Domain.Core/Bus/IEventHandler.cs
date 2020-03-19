using System.Threading.Tasks;
using Domain.Core.Events.Base;

namespace Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler 
    {

    }
}
