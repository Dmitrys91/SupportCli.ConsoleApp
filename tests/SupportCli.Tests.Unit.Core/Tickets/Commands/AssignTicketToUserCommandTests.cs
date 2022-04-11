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

    public class AssignTicketToUserCommandTests
    {
        [Test]
        public async Task AssignTicketToUserCommandReturnOutput()
        {
            var ticketsStorageMock = new Mock<ITicketsStorage>();

            var command = new AssignTicketToUserCommand(ticketsStorageMock.Object);

            var input = "assign 3 test";

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

            ticketResponse.AssignedToUser.Should().Be("test");
            command.OutPut.Should().NotBeEmpty();
        }
    }
}
