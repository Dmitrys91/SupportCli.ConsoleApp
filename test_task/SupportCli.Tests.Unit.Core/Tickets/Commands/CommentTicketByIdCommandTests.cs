using FluentAssertions;
using Moq;
using NUnit.Framework;
using SupportCli.Core.Interfaces;
using SupportCli.Core.Tickets.Commands;
using SupportCLI.Domain;
using Supportli.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportCli.Tests.Unit.Core.Tickets.Commands
{
    public class CommentTicketByIdCommandTests
    {
        [Test]
        public async Task CommentTicketFillsOutput()
        {
            var ticketsStorageMock = new Mock<ITicketsStorage>();

            var command = new CommentTicketByIdCommand(ticketsStorageMock.Object);

            var input = "comment 1 test";

            var ticketResponse = new Ticket
            {
                AssignedToUser = "",
                Id = 1,
                Comments = new List<string>(),
                Title = "test"
            };

            ticketsStorageMock
                .Setup(x => x.GetTicketByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(ticketResponse);

            await command.ExecuteAsync(input);

            ticketResponse.Comments.Should().Contain("test");
        }
    }
}
