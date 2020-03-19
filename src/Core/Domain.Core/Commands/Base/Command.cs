using System;
using Domain.Core.Events.Base;

namespace Domain.Core.Commands.Base
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
