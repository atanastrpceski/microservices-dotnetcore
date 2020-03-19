using System;
using System.Collections.Generic;
using System.Text;
using Transfer.Domain.Models;

namespace Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();
        void Add(TransferLog transferLog);
    }
}
