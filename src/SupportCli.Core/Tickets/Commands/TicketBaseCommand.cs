using SupportCli.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SupportCli.Core.Tickets.Commands
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseCommand
    {
        protected readonly ITicketsStorage _ticketsStorage;

        protected BaseCommand(ITicketsStorage ticketsStorage)
        {
            _ticketsStorage = ticketsStorage ??
                throw new ArgumentNullException(nameof(ticketsStorage));
        }

        public abstract string Prefix { get; }

        public abstract string Description { get; }

        public abstract Task ExecuteAsync(string input);

        public List<string> OutPut { get; set; } = new List<string>();

        public bool HasOutPut => OutPut.Any();
    }
}
