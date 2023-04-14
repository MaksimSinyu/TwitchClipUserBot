using System;
using System.Net.Http;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using Newtonsoft.Json.Linq;

namespace Twitch_Clip_Bot
{
    class Program
    {
        // Create a static instance of TwitchClient and define constants for authentication
        private static TwitchClient client;
        private const string oauthToken = "YOUR OAUTH TOKEN";
        private const string clientId = "YOUR CLIENT ID";
        private const string broadcasterId = "YOUR BROADCASTER ID";

        static void Main(string[] args)
        {
            // Create connection credentials using your Twitch username and OAuth token
            ConnectionCredentials credentials = new ConnectionCredentials("YOUR TWITCH USERNAME", oauthToken);

            // Initialize the Twitch client with your credentials and channel name
            client = new TwitchClient();
            client.Initialize(credentials, "YOUR TWITCH CHANNEL NAME");

            // Attach an event handler to respond to incoming chat messages
            client.OnMessageReceived += Client_OnMessageReceived;

            // Connect to Twitch chat
            client.Connect();

            // Wait for the user to press Enter before disconnecting and exiting the program
            Console.ReadLine();
            client.Disconnect();
        }

        private static async void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            // Check if the incoming message starts with "!clip"
            if (e.ChatMessage.Message.StartsWith("!clip"))
            {
                // If it does, call the CreateClip method and pass in the channel name
                await CreateClip(e.ChatMessage.Channel);
            }
        }

        private static async Task<string> CreateClip(string channel)
        {
            // Create an instance of HttpClient and set the required headers for Twitch API authentication
            using (HttpClient _client = new HttpClient())
            {
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer YOUR TOKEN");
                _client.DefaultRequestHeaders.Add("Client-ID", clientId);

                // Send a POST request to the Twitch API to create a clip
                var response = await _client.PostAsync($"https://api.twitch.tv/helix/clips?broadcaster_id={broadcasterId}&has_delay=false&duration=60", null);

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    // If the request was successful, parse the response content as JSON and extract the clip ID
                    JObject data = JObject.Parse(responseContent);
                    string clipId = data["data"][0]["id"].Value<string>();

                    // Construct the clip URL using the clip ID
                    string clipUrl = $"https://clips.twitch.tv/{clipId}";

                    // Send a chat message to the specified channel with a link to the newly created clip
                    client.SendMessage(channel, $"Clip created successfully. Clip URL: {clipUrl}");
                    return clipId;
                }
                else
                {
                    // If the request was unsuccessful, log the error message and return null
                    Console.WriteLine($"An error occurred while creating the clip: {responseContent}");
                    return null;
                }
            }
        }
    }
}
