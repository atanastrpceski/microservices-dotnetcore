using Transfer.Domain.Interfaces;
using Domain.Core.Bus;
using System.Collections.Generic;
using Transfer.Domain.Models;

namespace Transfer.Application.Interfaces
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _repository;
        private readonly IEventBus _bus;

        public TransferService(ITransferRepository repository, IEventBus bus)
        {
            _repository = repository;
            _bus = bus;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _repository.GetTransferLogs();
        }
    }
}
