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
    public class Ban : BaseCommandModule
    {
        [RequireUserPermissions(Permissions.BanMembers)]
        [Command("ban")]
        public async Task BanCommand(CommandContext ctx, DiscordMember user, [RemainingText] string reason)
        {
            if (reason == null)
                reason = "No reason provided.";

            var embed = new DiscordEmbedBuilder
            {
                Title = "Ban",
                Description = user.Mention + " has been banned.\nReason: `" + reason + "`",
                Color = DiscordColor.Blue
            };

            //await user.BanAsync().ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }
    }
}
