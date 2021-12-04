using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ZefBot
{
    public partial class ZefBot
    {
        public readonly EventId BotEventId = new EventId(42, "ZefBot");
        public static String Version => "1.0.0-dev.0001";
        public static Config Configuration { get; private set; }
        public static DiscordClient Client { get; set; }
        public static CommandsNextExtension CommandsExtension { get; private set; }
    }
    public class Config
    {
        [JsonProperty("token")]
        public String Token { get; private set; }

        [JsonProperty("guilds")]
        public UInt64[] Guilds { get; private set; }

        [JsonProperty("prefixes")]
        public String[] Prefixes { get; private set; }

        [JsonProperty("windowTitle")]
        public String WindowTitle { get; private set; }
    }
}
