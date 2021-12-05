using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

using ZefBot.Utility;

namespace ZefBot.Commands.Miscellaneous
{
    public class Say : BaseCommandModule
    {
        [Command("say")]
        public async Task SayCommand(CommandContext ctx, String message)
        {
            if (!Permission.IsGranted(ctx, "say"))
            {
                await ctx.RespondAsync("You are lacking permission to perform this command! "
                    + "Please contact your administrators if you believe this is an error.");
                return;
            }
            else
            {
                await ctx.Channel.SendMessageAsync(message);
                await ctx.Message.DeleteAsync();
            }
        }
    }
}
