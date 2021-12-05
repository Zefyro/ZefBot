using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

using ZefBot.Utility;

namespace ZefBot.Commands.Moderation
{
    public class Kick : BaseCommandModule
    {
        [Command("kick")]
        public async Task KickCommand(CommandContext ctx, DiscordMember user, [RemainingText] string reason)
        {
            if (!Permission.IsGranted(ctx, "kick"))
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
                    Title = "Kick",
                    Description = user.Mention + " has been kicked.\nReason: `" + reason + "`",
                    Color = DiscordColor.Azure
                };
                await user.RemoveAsync().ConfigureAwait(false);
                await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
            }
        }
    }
}
