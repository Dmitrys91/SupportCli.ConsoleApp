using SupportCLI.Domain;
using SupportCli.Core.Interfaces;
using Supportli.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportCli.Core.Tickets.Commands
{
    /// <summary>
    /// Create ticket
    /// </summary>
    public class CreateTicketCommand : BaseCommand
    {
        public CreateTicketCommand(ITicketsStorage ticketsStorage) : base(ticketsStorage) { }

        public override string Prefix => "create";

        public override string Description => "create %title% - create a new ticket";

        public override async Task ExecuteAsync(string input)
        {
            // Emit id autoincrement

            var id = new Random().Next(1, 1000);

            var ticket = new Ticket
            {
                Id = id,
                Title = input[7..],
                CurrentState = TicketState.Opened,
                Comments = new List<string>()
            };

            var result = await _ticketsStorage.AddTicketAsync(ticket);

            OutPut.Add($"New ticket with id {result.Id} has been created ");
        }
    }
}
