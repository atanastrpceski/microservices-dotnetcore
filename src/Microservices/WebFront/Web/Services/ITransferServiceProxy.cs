using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.DTO;

namespace Web.Services
{
    public interface ITransferServiceProxy
    {
        Task Transfer(TransferDTO transferDto);
    }
}
