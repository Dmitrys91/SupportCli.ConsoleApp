using SupportCli.Core.Helpers;
using SupportCli.Core.Interfaces;
using SupportCli.Core.Tickets.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportCli.UI.Processors.Ticket
{
    public class TicketProcessor : IProcessor
    {   
        private const string _titleString = "\n\nSUPPORT CLI";
        private const string _availableCommandsString = "\n\nAvailable commands:";

        private readonly IEnumerable<BaseCommand> _ticketCommands;

        public TicketProcessor(ITicketsStorage ticketsStorage)
        {
            if (ticketsStorage is null)
                throw new ArgumentNullException(nameof(ticketsStorage));

            _ticketCommands = ReflectiveEnumerator
                    .GetEnumerableOfType<BaseCommand>(ticketsStorage);
        }

        public async Task StartAsync()
        {
            Console.WriteLine(_titleString);

            var commandsPool = _ticketCommands.ToDictionary(x => x.Prefix);

            while (true)
            {
                Console.WriteLine(_availableCommandsString);

                WriteCommandsDescription();

                Console.WriteLine("q - exit");
                Console.WriteLine();

                var input = Console.ReadLine();
                if (input.Equals("q"))
                    break;

                var commandName = input.Split(" ").FirstOrDefault();

                if (commandsPool.TryGetValue(commandName, out var command))
                {
                    await ProcessCommandAsync(command, input);
                }
                else
                {
                    Console.WriteLine($"unknown command {input}");
                }
            }
        }

        /// <summary>
        /// Show descriptions
        /// </summary>
        private void WriteCommandsDescription()
        {
            foreach (var ticketCommand in _ticketCommands)
            {
                Console.WriteLine(ticketCommand.Description);
            }
        }

        /// <summary>
        /// Raise command execution
        /// </summary>
        /// <param name="command">command</param>
        /// <param name="input">input</param>
        /// <returns></returns>
        private async Task ProcessCommandAsync(BaseCommand command, string input)
        {
            try
            {
                await command.ExecuteAsync(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(@$"An error occured while processing command {command.Prefix}. {ex.Message}");
            }

            if (command.HasOutPut)
            {
                foreach (var str in command.OutPut)
                {
                    Console.WriteLine(str);
                }
            }
        }
    }
}
