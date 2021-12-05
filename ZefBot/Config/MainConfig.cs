using Newtonsoft.Json;

namespace ZefBot.Config
{
    public class MainConfig
    {
        [JsonProperty("token")]
        public String Token { get; private set; }

        [JsonProperty("guild")]
        public UInt64 Guild { get; private set; }

        [JsonProperty("prefixes")]
        public String[] Prefixes { get; private set; }

        [JsonProperty("windowTitle")]
        public String? WindowTitle { get; private set; }
    }
}
