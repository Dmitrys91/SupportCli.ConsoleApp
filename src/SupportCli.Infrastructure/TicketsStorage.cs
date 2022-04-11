using SupportCli.Core.Interfaces;
using SupportCLI.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SupportCLI.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public class TicketsStorage : ITicketsStorage
    {
        private static readonly Dictionary<int, Ticket> _tickets = new ();

        public async Task<bool> RemoveTicketByIdAsync(int ticketId)
        {
            await Task.Yield();

            if (!_tickets.TryGetValue(ticketId, out var _))
                return false;

            _tickets.Remove(ticketId);

            return true;
        }

        public async Task<Ticket> AddTicketAsync(Ticket ticket)
        {
            await Task.Yield();

            if (_tickets.TryGetValue(ticket.Id, out var _))
                throw new ArgumentException($"Ticket with id {ticket.Id} already exists");

            _tickets[ticket.Id] = ticket;

            return ticket;
        }

        public async Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            await Task.Yield();

            if (!_tickets.TryGetValue(ticketId, out var result))
                throw new ArgumentNullException($"Ticket {ticketId} has not found");

            return result;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync()
        {
            await Task.Yield();

            return _tickets
                .Select(x => x.Value)
                .ToList();
        }
    }
}
