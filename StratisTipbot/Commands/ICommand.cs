using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace StratisTipbot.Commands
{
    public interface ICommand
    {
        Task ExecuteAsync(ChatMessage chatMessage, TwitchClient client);
    }
}
