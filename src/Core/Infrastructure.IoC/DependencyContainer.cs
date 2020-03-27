using Banking.Application.Interfaces;
using Banking.Data.Context;
using Banking.Data.Repository;
using Banking.Domain.CommandHandlers;
using Banking.Domain.Interfaces;
using Domain.Core.Bus;
using Domain.Core.Http;
using Domain.Core.Models;
using MediatR;
using MicroRabbit.Infrastructure.Bus;
using Microsoft.Extensions.Configuration;
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
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Expose the config globally
            services.AddSingleton(provider => configuration);

            // Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetRequiredService<IMediator>(), scopeFactory);
            });

            // DB Context's
            services.AddTransient<BankingDBContext>();
            services.AddTransient<TransferDBContext>();

            // Repositories
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();

            // Services
            services.AddTransient<IResilientHttpClient, ResilientHttpClient>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            // Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferCreatedEventHandler>();

            // Subscriptions
            services.AddTransient<TransferCreatedEventHandler>();
        }
    }
}
