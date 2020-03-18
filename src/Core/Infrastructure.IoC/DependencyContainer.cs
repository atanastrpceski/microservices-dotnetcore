using Banking.Application.Interfaces;
using Banking.Data.Context;
using Banking.Data.Repository;
using Banking.Domain.CommandHandlers;
using Banking.Domain.Commands;
using Banking.Domain.Interfaces;
using Domain.Core.Bus;
using MediatR;
using MicroRabbit.Infrastructure.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Events

            // Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            // Repositories
            services.AddTransient<IAccountRepository, AccountRepository>();

            // Services
            services.AddTransient<IAccountService, AccountService>();

            // Data
            services.AddTransient<BankingDBContext>();
        }
    }
}
