using Domain.Core.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Models.DTO;

namespace Web.Services
{
    public class TransferServiceProxy : ITransferServiceProxy
    {
        private readonly HttpClient _apiClient;
        private readonly IResilientHttpClient _resilientHttpClient;

        public TransferServiceProxy(HttpClient apiClient, 
            IResilientHttpClient resilientHttpClient)
        {
            _resilientHttpClient = resilientHttpClient;
            _apiClient = apiClient;
        }

        public async Task Transfer(TransferDTO transferDto)
        {
            var uri = "https://localhost:55163/api/Banking";
            var response = _resilientHttpClient.Post(uri, transferDto);
            response.EnsureSuccessStatusCode();
        }
    }
}
