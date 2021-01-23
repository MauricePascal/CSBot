using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace CSBot
{
    class Program
    {

        private DiscordSocketClient _client;

        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;

            var token = "Nzk3OTg4NjMyMzUwODE4MzQ0.X_ue0w.-xbKuSavaR18uuPdCG-zH5OQuH4";

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            _client.MessageReceived += MessageReceived;

            await Task.Delay(-1);
        }

        private async Task MessageReceived(SocketMessage msg)
        {
            String prefix = "!";
            String[] args = msg.Content.Split(" ");
            if(args[0].StartsWith(prefix))
            {
                String command = args[0].Substring(prefix.Length);
                if(command.Equals("help"))
                {
                    await msg.Channel.SendMessageAsync("I dont know how to help you :c");
                }
            }
        }

    }
}
