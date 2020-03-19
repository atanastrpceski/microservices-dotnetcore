using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transfer.Data.Context;
using Transfer.Domain.Models;

namespace Transfer.Api
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var serviceScope = serviceProvider.CreateScope();
            using (TransferDBContext context = serviceScope.ServiceProvider.GetRequiredService<TransferDBContext>())
            {
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                }

                if (!context.TransferLogs.Any())
                {
                    context.TransferLogs.Add(new TransferLog
                    {
                        FromAccount = 1,
                        ToAccount = 2,
                        TrasnferAmount = 100
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
