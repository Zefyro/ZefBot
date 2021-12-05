using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

using ZefBot.Utility;

namespace ZefBot.Commands.Miscellaneous
{
    public class Bot : BaseCommandModule
    {
        [Command("bot")]
        [Aliases("botinfo", "bot-info")]
        [Description("Display information about the bot")]
        public async Task BotCommand(CommandContext ctx)
        {
            if (!Permission.IsGranted(ctx, "bot"))
            {
                await ctx.RespondAsync("You are lacking permission to perform this command! "
                    + "Please contact your administrators if you believe this is an error.");
                return;
            }
            else
            {
                DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
                {
                    Title = "ZefBot",
                    Description = $"**Bot version:** {ZefBot.Version}\n**Source code:** [Github](https://github.com/Zefyro/ZefBot)",
                    Color = DiscordColor.Azure,
                    Footer = new()
                    {
                        Text = $"ZefBot v{ZefBot.Version}"
                    }
                };
                await ctx.Channel.SendMessageAsync(embed: embed);
                await ctx.Message.DeleteAsync();
            }
        }
    }
}
