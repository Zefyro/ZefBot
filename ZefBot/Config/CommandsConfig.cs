namespace ZefBot.Config
{
    public class CommandsConfig
    {
        public Administrator administrator { get; set; }
        public Commands commands { get; set; }
    }

    public class Administrator
    {
        public UInt64[] users { get; set; }
        public UInt64[] roles { get; set; }
    }

    public class Commands
    {
        public Miscellaneous miscellaneous { get; set; }
        public Moderation moderation { get; set; }
    }

    public class Miscellaneous
    {
        public Say say { get; set; }
        public Embed embed { get; set; }
        public Bot bot { get; set; }
    }

    public class Say
    {
        public Boolean enabled { get; set; }
        public Allowed allowed { get; set; }
        public Blocked blocked { get; set; }
        public Boolean isPublic { get; set; }
    }
    public class Embed
    {
        public Boolean enabled { get; set; }
        public Allowed allowed { get; set; }
        public Blocked blocked { get; set; }
        public Boolean isPublic { get; set; }
    }
    public class Bot
    {
        public Boolean enabled { get; set; }
        public Allowed allowed { get; set; }
        public Blocked blocked { get; set; }
        public Boolean isPublic { get; set; }
    }
    public class Moderation
    {
        public Ban ban { get; set; }
        public Kick kick { get; set; }
    }
    public class Ban
    {
        public Boolean enabled { get; set; }
        public Allowed allowed { get; set; }
        public Blocked blocked { get; set; }
        public Boolean isPublic { get; set; }
    }
    public class Kick
    {
        public Boolean enabled { get; set; }
        public Allowed allowed { get; set; }
        public Blocked blocked { get; set; }
        public Boolean isPublic { get; set; }
    }
    public class Allowed
    {
        public UInt64[] roles { get; set; }
        public UInt64[] users { get; set; }
    }
    public class Blocked
    {
        public UInt64[] roles { get; set; }
        public UInt64[] users { get; set; }
    }
}
