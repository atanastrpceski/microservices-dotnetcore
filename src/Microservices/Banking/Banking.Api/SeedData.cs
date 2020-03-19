using Banking.Data.Context;
using Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Transfer.Data.Context;

namespace Transfer.Api
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var serviceScope = serviceProvider.CreateScope();
            using (BankingDBContext context = serviceScope.ServiceProvider.GetRequiredService<BankingDBContext>())
            {
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                }

                if (!context.Accounts.Any())
                {
                    context.Accounts.Add(new Account
                    {
                        AccountType = "Calculation",
                        AccountBalance = 1000
                    });

                    context.Accounts.Add(new Account
                    {
                        AccountType = "Translation",
                        AccountBalance = 1000
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
