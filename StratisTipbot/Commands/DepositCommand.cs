using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace StratisTipbot.Commands
{
    public class DepositCommand : ICommand
    {
        public DepositCommand()
        {

        }

        public Task ExecuteAsync(ChatMessage chatMessage, TwitchClient client)
        {
            throw new NotImplementedException();
        }
    }
}
