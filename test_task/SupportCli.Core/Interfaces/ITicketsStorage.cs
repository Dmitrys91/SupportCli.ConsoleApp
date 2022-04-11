using SupportCLI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportCli.Core.Interfaces
{
    public interface ITicketsStorage
    {
        /// <summary>
        /// Get ticket by id
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        Task<Ticket> GetTicketByIdAsync(int ticketId);

        /// <summary>
        /// Add ticket
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>result</returns>
        Task<Ticket> AddTicketAsync(Ticket ticket);

        /// <summary>
        /// Remove ticket by id
        /// </summary>
        /// <param name="ticketId">ticket id</param>
        /// <returns>result</returns>
        Task<bool> RemoveTicketByIdAsync(int ticketId);

        /// <summary>
        /// Get all tickets
        /// </summary>
        /// <returns>result</returns>
        Task<IEnumerable<Ticket>> GetTicketsAsync();
    }
}
