using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using ZefBot.Commands;
using ZefBot.Commands.Moderation;
using ZefBot.Config;

namespace ZefBot
{
    public partial class ZefBot
    {
        internal static async Task Main(String[] args)
        {
            StreamReader configReader = new("./config/main.json");
            Configuration = JsonConvert.DeserializeObject<MainConfig>(configReader.ReadToEnd());
            configReader.Close();

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

            try
            {
                HomeGuild = await Client.GetGuildAsync(Configuration.Guild);

                if (!Directory.Exists($"./config/{HomeGuild}/data"))
                {
                    Directory.CreateDirectory($"./config/{HomeGuild}/data");
                    Client.Logger.LogInformation(new EventId(1000, "Main"), $"Guild registered: {HomeGuild}");
                }
                if (!File.Exists($"./config/{HomeGuild}/config.json"))
                {
                    File.Create($"./config/{HomeGuild}/config.json");
                }
                Client.Logger.LogInformation(new EventId(1000, "Main"), $"Guild loaded: {HomeGuild}");
            }
            catch (UnauthorizedException)
            {
                Client.Logger.LogCritical(new EventId(0000, "Main"),
                    $"Your Guild ID: {HomeGuild} is either invalid or ZefBot has not been invited to the server yet.");
                Console.Write($"Please remove Guild ID: {HomeGuild} from the config.\n" + "Press any key to exit ZefBot...");
                Console.ReadKey();
                return;
            }
            catch { throw; }

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

            GetCommandsConfig();

            RegisterAllCommands();

            await Task.Delay(-1);
        }
        private static void RegisterAllCommands()
        {
            if (CommandConfig.commands.moderation.ban.enabled)
            { CommandsExtension.RegisterCommands<Commands.Moderation.Ban>(); }
            if (CommandConfig.commands.moderation.kick.enabled)
            { CommandsExtension.RegisterCommands<Commands.Moderation.Kick>(); }
            if (CommandConfig.commands.miscellaneous.say.enabled)
            { CommandsExtension.RegisterCommands<Commands.Miscellaneous.Say>(); }
            if (CommandConfig.commands.miscellaneous.embed.enabled)
            { CommandsExtension.RegisterCommands<Commands.Miscellaneous.Embed>(); }
            if (CommandConfig.commands.miscellaneous.bot.enabled)
            { CommandsExtension.RegisterCommands<Commands.Miscellaneous.Bot>(); }
        }
        public static CommandsConfig GetCommandsConfig()
        {
            StreamReader commandReader = new("./config/commands.json");
            CommandConfig = JsonConvert.DeserializeObject<CommandsConfig>(commandReader.ReadToEnd());
            commandReader.Close();
            return CommandConfig;
        }
    }
}