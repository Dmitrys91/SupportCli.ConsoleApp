using Microsoft.Extensions.DependencyInjection;
using SupportCli.Core.Interfaces;
using SupportCli.UI.Processors;
using SupportCli.UI.Processors.Ticket;
using SupportCLI.Infrastructure;
using System.Threading.Tasks;

namespace SupportCli
{
    class Program
    {
        static async Task Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<ITicketsStorage, TicketsStorage>()
                .BuildServiceProvider();

            var ticketStorage = serviceProvider.GetService<ITicketsStorage>();

            IProcessor process = new TicketProcessor(ticketStorage);

            await process.StartAsync();
        }
    }
}
