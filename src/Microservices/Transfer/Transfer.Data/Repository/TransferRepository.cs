using Transfer.Data.Context;
using System.Collections.Generic;
using Transfer.Domain.Models;
using Transfer.Domain.Interfaces;

namespace Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDBContext _context;

        public TransferRepository(TransferDBContext context)
        {
            _context = context;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _context.TransferLogs;
        }
    }
}
