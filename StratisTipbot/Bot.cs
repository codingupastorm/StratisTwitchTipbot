using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;

namespace StratisTipbot
{
    public class Bot
    {
        TwitchClient client;

        public Bot()
        {
            client = new TwitchClient();
            client.OnConnected += OnConnected;
            client.OnJoinedChannel += OnJoinedChannel;
            client.OnMessageReceived += OnMessageReceived;
            client.OnWhisperReceived += OnWhisperReceived;
            client.OnNewSubscriber += OnNewSubscriber;
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
            if (e.ChatMessage.Message.Contains("badword"))
                client.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30), "Bad word! 30 minute timeout!");
        }

        private void OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            if (e.WhisperMessage.Username == "my_friend")
                client.SendWhisper(e.WhisperMessage.Username, "Hey! Whispers are so cool!!");
        }

        private void OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            if (e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime)
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points! So kind of you to use your Twitch Prime on this channel!");
            else
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points!");
        }
    }
}
