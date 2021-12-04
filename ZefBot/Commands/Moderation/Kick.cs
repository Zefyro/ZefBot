using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZefBot.Commands.Moderation
{
    public class Kick : BaseCommandModule
    {
        [RequireUserPermissions(Permissions.KickMembers)]
        [Command("kick")]
        public async Task KickCommand(CommandContext ctx, DiscordMember user, [RemainingText] string reason)
        {
            if (reason == null)
                reason = "No reason provided.";

            var embed = new DiscordEmbedBuilder
            {
                Title = "Kick",
                Description = user.Mention + " has been kicked.\nReason: `" + reason + "`",
                Color = DiscordColor.Blue
            };

            await user.RemoveAsync().ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }
    }
}
