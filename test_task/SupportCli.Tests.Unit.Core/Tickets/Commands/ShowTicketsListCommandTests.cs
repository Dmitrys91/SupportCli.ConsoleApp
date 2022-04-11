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
    public class ShowTicketsListCommandTests
    {
        [Test]
        public async Task ShowTicketsListFillsOutput()
        {
            var ticketsStorageMock = new Mock<ITicketsStorage>();

            var command = new ShowTicketsListCommand(ticketsStorageMock.Object);

            var input = "list";

            var ticketResponse = new List<Ticket>
            {
                new Ticket
                {
                    AssignedToUser = "",
                    Id = 1,
                    Comments = new List<string>(),
                    Title = "test"
                }
            };

            ticketsStorageMock
                .Setup(x => x.GetTicketsAsync())
                .ReturnsAsync(ticketResponse);

            await command.ExecuteAsync(input);

            command.OutPut.Should().NotBeEmpty();
        }
    }
}
