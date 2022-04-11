using SupportCli.Core.Interfaces;
using System.Threading.Tasks;

namespace SupportCli.Core.Tickets.Commands
{
    /// <summary>
    /// Show tickets
    /// </summary>
    public class ShowTicketsListCommand : BaseCommand
    {
        public ShowTicketsListCommand(ITicketsStorage ticketsStorage) : base(ticketsStorage) { }

        public override string Prefix => "list";

        public override string Description => "list - show all tickets";

        public override async Task ExecuteAsync(string input)
        {
            foreach (var ticket in await _ticketsStorage.GetTicketsAsync())
            {
                OutPut.Add($"{ticket.Id} | {ticket.Title}");
            }
        }
    }
}
