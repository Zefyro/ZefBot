using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

using ZefBot.Utility;

namespace ZefBot.Commands.Miscellaneous
{
    public class Embed : BaseCommandModule
    {
        [Command("embed")]
        public async Task EmbedCommand(CommandContext ctx, String message)
        {
            if (!Permission.IsGranted(ctx, "embed"))
            {
                await ctx.RespondAsync("You are lacking permission to perform this command! "
                    + "Please contact your administrators if you believe this is an error.");
                return;
            }
            else
            {
                DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
                {
                    Description = message,
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
