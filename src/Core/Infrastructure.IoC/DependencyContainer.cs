using Banking.Application.Interfaces;
using Banking.Data.Context;
using Banking.Data.Repository;
using Banking.Domain.CommandHandlers;
using Banking.Domain.Interfaces;
using Domain.Core.Bus;
using Domain.Core.Commands.Banking;
using Domain.Core.Events.Banking.Base;
using MediatR;
using MicroRabbit.Infrastructure.Bus;
using Microsoft.Extensions.DependencyInjection;
using Transfer.Application.Interfaces;
using Transfer.Data.Context;
using Transfer.Data.Repository;
using Transfer.Domain.EventHandlers;
using Transfer.Domain.Interfaces;

namespace Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferCreatedEventHandler>();

            // Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            // Repositories
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();

            // Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            // DB Context's
            services.AddTransient<BankingDBContext>();
            services.AddTransient<TransferDBContext>();
        }
    }
}
