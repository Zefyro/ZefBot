using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using ZefBot.Commands;
using ZefBot.Commands.Moderation;

namespace ZefBot
{
    public partial class ZefBot
    {
        internal static async Task Main(String[] args)
        {
            StreamReader reader = new("./config/main.json");
            Configuration = JsonConvert.DeserializeObject<Config>(reader.ReadToEnd());
            reader.Close();

            // Set Window Title
            if (String.IsNullOrWhiteSpace(Configuration.WindowTitle))
            {
                Console.Title = $"ZefBot v{Version}";
            }
            else
            {
                Console.Title = Configuration.WindowTitle;
            }

            Client = new(new()
            {
                AutoReconnect = true,
                Token = Configuration.Token,
                TokenType = TokenType.Bot,
                MinimumLogLevel = LogLevel.Information
            });

            await Client.ConnectAsync();

            Client.Logger.LogInformation(new EventId(1000, "Main"), $"ZefBot Version {Version}");

            // Check if the guilds listed are valid
            foreach (UInt64 guild in Configuration.Guilds)
            {
                try
                {
                    var Guild = await Client.GetGuildAsync(guild);

                    if (!Directory.Exists($"./config/{Guild}/data"))
                    {
                        Directory.CreateDirectory($"./config/{Guild}/data");
                        Client.Logger.LogInformation(new EventId(1000, "Main"), $"Guild registered: {Guild}");
                    }
                    Client.Logger.LogInformation(new EventId(1000, "Main"), $"Guild loaded: {Guild}");
                }
                catch (UnauthorizedException)
                {
                    Client.Logger.LogCritical(new EventId(0000, "Main"),
                        $"Your Guild ID: {guild} is either invalid or ZefBot has not been invited to the server yet.");
                    Console.Write($"Please remove Guild ID: {guild} from the config.\n" + "Press any key to exit ZefBot...");
                    Console.ReadKey();
                    return;
                }
                catch { throw; }
            }


            //load command configuration
            var CommandConfiguration = new CommandsNextConfiguration
            {
                CaseSensitive = false,
                StringPrefixes = Configuration.Prefixes,
                IgnoreExtraArguments = true,
                EnableDefaultHelp = true
            };

            //create and register command client
            CommandsExtension = Client.UseCommandsNext(CommandConfiguration);

            RegisterAllCommands();

            await Task.Delay(-1);
        }
        private static void RegisterAllCommands()
        {
            CommandsExtension.RegisterCommands<Ban>();
            CommandsExtension.RegisterCommands<Kick>();
        }
    }
}