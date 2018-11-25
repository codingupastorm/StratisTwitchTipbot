using System;
using System.Threading.Tasks;
using StratisTipbot;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;

namespace TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Bot bot = new Bot();
            await bot.Connect("ravintoast"); // my channel
            Console.ReadLine();
        }
    }
}