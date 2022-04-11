using Supportli.Domain.Enums;
using System.Collections.Generic;

namespace SupportCLI.Domain
{
    public class Ticket
    {

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Current state
        /// </summary>
        public TicketState CurrentState { get; set; }

        /// <summary>
        /// Assigned user name
        /// </summary>
        public string AssignedToUser { get; set; }

        /// <summary>
        /// Comments count
        /// </summary>
        public int CommentsCount => Comments.Count;

        /// <summary>
        /// Comments
        /// </summary>
        public List<string> Comments { get; set; }
    }
}
