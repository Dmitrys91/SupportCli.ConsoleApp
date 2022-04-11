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
    public class CreateTicketCommandTests
    {
        [Test]
        public async Task CreateTicketSetsCorrectState()
        {
            var ticketsStorageMock = new Mock<ITicketsStorage>();

            var command = new CreateTicketCommand(ticketsStorageMock.Object);

            var input = "create test";

            var ticketResponse = new Ticket
            {
                AssignedToUser = "",
                Id = 1,
                Comments = new List<string>(),
                Title = "test"
            };

            ticketsStorageMock
                .Setup(x => x.AddTicketAsync(It.IsAny<Ticket>()))
                .ReturnsAsync(ticketResponse);

            await command.ExecuteAsync(input);

            ticketResponse.CurrentState.Should().Be(TicketState.Opened);
        }
    }
}
