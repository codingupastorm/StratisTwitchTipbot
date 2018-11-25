using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace StratisTipbot.Commands
{
    public class CommandDispatcher
    {
        private static readonly IDictionary<string, ICommand> Commands = new Dictionary<string, ICommand>
        {
            { "!deposit", new DepositCommand() }
        };

        private readonly TwitchClient client;

        public CommandDispatcher(TwitchClient client)
        {
            this.client = client;
        }

        public async Task DispatchCommandAsync(ChatMessage chatMessage)
        {
            foreach (var command in Commands)
            {
                if (chatMessage.Message.StartsWith(command.Key))
                    await command.Value.ExecuteAsync(chatMessage, this.client);
            }

            throw new NotSupportedException("Command not found. TODO More robust failure here.");
        }
    }
}
