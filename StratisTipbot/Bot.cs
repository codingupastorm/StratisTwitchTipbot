using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using StratisTipbot.Commands;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;

namespace StratisTipbot
{
    public class Bot
    {
        private readonly TwitchClient client;
        private readonly CommandDispatcher commandDispatcher;

        public Bot()
        {
            client = new TwitchClient();
            client.OnConnected += OnConnected;
            client.OnJoinedChannel += OnJoinedChannel;
            client.OnMessageReceived += OnMessageReceived;
            client.OnWhisperReceived += OnWhisperReceived;

            commandDispatcher = new CommandDispatcher(this.client); // TODO: DI.
        }

        public async Task Connect(string channelName)
        {
            ConnectionCredentials credentials = await CredentialsRetrieval.GetCredentialsAsync();
            client.Initialize(credentials, channelName);
            client.Connect();
        }

        private void OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }
        private void OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine("Hey guys! I am a bot connected via TwitchLib!");
            client.SendMessage(e.Channel, "Hey guys! I am a bot connected via TwitchLib!");
        }

        private void OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.StartsWith("!"))
            {

            }
        }

        private void OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            client.SendWhisper(e.WhisperMessage.Username, "Hey! The tipbot only works in public channels!");
        }
    }
}
