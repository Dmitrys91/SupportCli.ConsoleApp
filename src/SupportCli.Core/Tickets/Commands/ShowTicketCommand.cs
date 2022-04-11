using SupportCli.Core.Interfaces;
using System.Threading.Tasks;

namespace SupportCli.Core.Tickets.Commands
{
    /// <summary>
    /// Show ticket
    /// </summary>
    public class ShowTicketCommand : BaseCommand
    {
        public ShowTicketCommand(ITicketsStorage ticketsStorage) : base(ticketsStorage) { }

        public override string Prefix => "show";

        public override string Description => "show %ticket id% - show the ticket";

        public override async Task ExecuteAsync(string input)
        {
            var id = int.Parse(input.Split(' ')[1]);

            var ticket = await _ticketsStorage.GetTicketByIdAsync(id);

            OutPut.Add($"{nameof(ticket.Id)}={ticket.Id}");
            OutPut.Add($"{nameof(ticket.Title)}={ticket.Title}");
            OutPut.Add($"{nameof(ticket.CurrentState)}={ticket.CurrentState}");
            OutPut.Add($"{nameof(ticket.AssignedToUser)}={ticket.AssignedToUser}");
            OutPut.Add($"{nameof(ticket.CommentsCount)}={ticket.CommentsCount}");
            OutPut.Add($"{nameof(ticket.Comments)}:");

            foreach (var comment in ticket.Comments)
            {
                OutPut.Add($"> {comment}");
            }
        }
    }
}
