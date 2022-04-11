using FluentAssertions;
using NUnit.Framework;
using SupportCli.UI.Processors.Ticket;
using System;

namespace SupportCli.Tests.Unit.UI.Processors
{
    public  class TicketProcessorTests
    {
        [Test]
        public void TicketProcessorThrowsExceptionWhenStorageIsNull()
        {
            FluentActions.Invoking(() =>
               new TicketProcessor(null)).Should().Throw<ArgumentNullException>();
        }
    }
}
