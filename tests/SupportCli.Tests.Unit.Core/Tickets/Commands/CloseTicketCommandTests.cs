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
    public class CloseTicketCommandTests
    {
        [Test]
        public async Task CloseTicketChangedCurrentState()
        {
            var ticketsStorageMock = new Mock<ITicketsStorage>();

            var command = new CloseTicketCommand(ticketsStorageMock.Object);

            var input = "close 1";

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

            ticketResponse.CurrentState.Should().Be(TicketState.Closed);
        }
    }
}
