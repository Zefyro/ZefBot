using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;

using ZefBot.Config;

namespace ZefBot
{
    public partial class ZefBot
    {
        public readonly EventId BotEventId = new EventId(42, "ZefBot");
        public static String Version => "1.0.0-dev.0002";
        public static MainConfig Configuration { get; private set; }
        public static CommandsConfig CommandConfig { get; private set; }
        public static DiscordClient Client { get; set; }
        public static CommandsNextExtension CommandsExtension { get; private set; }
        public static DiscordGuild HomeGuild { get; set; }
    }
}
