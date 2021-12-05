using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

using ZefBot.Utility;

namespace ZefBot.Commands.Moderation
{
    public class Ban : BaseCommandModule
    {
        [Command("ban")]
        public async Task BanCommand(CommandContext ctx, DiscordMember user, [RemainingText] string reason)
        {
            if (!Permission.IsGranted(ctx, "ban"))
            {
                await ctx.RespondAsync("You are lacking permission to perform this command! "
                    + "Please contact your administrators if you believe this is an error.");
                return;
            }
            else
            {
                if (reason == null)
                    reason = "No reason provided.";
                var embed = new DiscordEmbedBuilder
                {
                    Title = "Ban",
                    Description = user.Mention + " has been banned.\nReason: `" + reason + "`",
                    Color = DiscordColor.Azure
                };
                await user.BanAsync().ConfigureAwait(false);
                await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
            }
        }
    }
}
