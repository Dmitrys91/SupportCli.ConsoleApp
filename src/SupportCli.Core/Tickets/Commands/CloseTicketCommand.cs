using SupportCli.Core.Interfaces;
using Supportli.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace SupportCli.Core.Tickets.Commands
{
    /// <summary>
    /// Close ticket
    /// </summary>
    public class CloseTicketCommand : BaseCommand
    {
        public override string Prefix => "close";

        public override string Description => "close %ticket id% - close the ticket";

        public CloseTicketCommand(ITicketsStorage ticketsStorage) : base(ticketsStorage) { }

        public override async Task ExecuteAsync(string input)
        {
            var id = int.Parse(input.Split(' ')[1]);

            var ticket = await _ticketsStorage.GetTicketByIdAsync(id);

            ticket.CurrentState = TicketState.Closed;

            ticket.Comments.Add("closed " + DateTime.UtcNow);

            OutPut.Add($"{id} has been closed ");
        }
    }
}
