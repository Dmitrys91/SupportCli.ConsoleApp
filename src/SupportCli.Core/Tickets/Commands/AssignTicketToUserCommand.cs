using SupportCli.Core.Interfaces;
using Supportli.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace SupportCli.Core.Tickets.Commands
{
    /// <summary>
    /// Assign ticket to user
    /// </summary>
    public class AssignTicketToUserCommand : BaseCommand
    {
        public AssignTicketToUserCommand(ITicketsStorage ticketsStorage) : base(ticketsStorage) { }

        public override string Prefix => "assign";

        public override string Description => "assign %ticket id% %user name% - assign the ticket";

        public override async Task ExecuteAsync(string input)
        {
            var id = int.Parse(input.Split(' ')[1]);

            var usernamePrefix = 7 + input.Split(' ')[1].Length + 1;

            var username = input[usernamePrefix..];

            var ticket = await _ticketsStorage.GetTicketByIdAsync(id);

            ticket.Comments.Add($"assigned {username} + {DateTime.UtcNow}");

            ticket.AssignedToUser = username;

            ticket.CurrentState = TicketState.InProgress;

            OutPut.Add($"{id} has been assigned to {username}");
        }
    }
}
