using SupportCli.Core.Interfaces;
using System.Threading.Tasks;

namespace SupportCli.Core.Tickets.Commands
{
    /// <summary>
    /// Comment ticket
    /// </summary>
    public class CommentTicketByIdCommand : BaseCommand
    {
        public CommentTicketByIdCommand(ITicketsStorage ticketsStorage) : base(ticketsStorage) { }

        public override string Prefix => "comment";

        public override string Description => "comment %ticket id% %comment% - add a comment to the ticket";

        public override async Task ExecuteAsync(string input)
        {
            var id = int.Parse(input.Split(' ')[1]);

            var commentPrefix = 8 + input.Split(' ')[1].Length + 1;

            var comment = input[commentPrefix..];

            var ticket = await _ticketsStorage.GetTicketByIdAsync(id);

            ticket.Comments.Add(comment);

            OutPut.Add($"new comment has been added into {id}");
        }
    }
}
