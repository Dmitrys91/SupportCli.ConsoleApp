using FluentAssertions;
using Moq;
using NUnit.Framework;
using SupportCli.Core.Interfaces;
using SupportCli.Core.Tickets.Commands;
using SupportCLI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportCli.Tests.Unit.Core.Tickets.Commands
{
    public class ShowTicketCommandTests
    {
        [Test]
        public async Task GetTicketByIdFillsOutput()
        {
            var ticketsStorageMock = new Mock<ITicketsStorage>();

            var command = new ShowTicketCommand(ticketsStorageMock.Object);

            var input = "show 1";

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

            command.OutPut.Should().NotBeEmpty();
        }
    }
}
