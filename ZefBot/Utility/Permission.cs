using DSharpPlus.CommandsNext;

using ZefBot.Config;

namespace ZefBot.Utility
{
    public class Permission
    {
        private static CommandsConfig config = ZefBot.GetCommandsConfig();
        public static Boolean IsGranted(CommandContext ctx, String type)
        {

            if (config.administrator.users.Contains(ctx.Member.Id))
                return true;


            foreach (var role in ctx.Member.Roles)
            {
                if (config.administrator.roles.Contains(role.Id))
                    return true;
            }
            

            switch (type)
            {
                case "ban": 
                    {
                        if (config.commands.moderation.ban.blocked.users.Contains(ctx.Member.Id))
                            return false;
                        if (config.commands.moderation.ban.allowed.users.Contains(ctx.Member.Id))
                            return true;
                        foreach (var role in ctx.Member.Roles)
                        {
                            if (config.commands.moderation.ban.allowed.roles.Count() >= 1 
                                || config.commands.moderation.ban.blocked.roles.Count() >= 1)
                            {
                                if (config.commands.moderation.ban.allowed.roles.Contains(role.Id))
                                    return true;
                                if (config.commands.moderation.ban.blocked.roles.Contains(role.Id))
                                    break;
                            } else { break; }
                        }
                        if (config.commands.moderation.ban.isPublic)
                            return true;
                        return false;
                    }

                case "kick":
                    {
                        if (config.commands.moderation.kick.blocked.users.Contains(ctx.Member.Id))
                            return false;
                        if (config.commands.moderation.kick.allowed.users.Contains(ctx.Member.Id))
                            return true;
                        foreach (var role in ctx.Member.Roles)
                        {
                            if (config.commands.moderation.kick.allowed.roles.Count() >= 1
                                || config.commands.moderation.kick.blocked.roles.Count() >= 1)
                            {
                                if (config.commands.moderation.kick.allowed.roles.Contains(role.Id))
                                    return true;
                                if (config.commands.moderation.kick.blocked.roles.Contains(role.Id))
                                    break;
                            }
                            else { break; }
                        }
                        if (config.commands.moderation.kick.isPublic)
                            return true;
                        return false;
                    }

                case "say":
                    {
                        if (config.commands.miscellaneous.say.blocked.users.Contains(ctx.Member.Id))
                            return false;
                        if (config.commands.miscellaneous.say.allowed.users.Contains(ctx.Member.Id))
                            return true;
                        foreach (var role in ctx.Member.Roles)
                        {
                            if (config.commands.miscellaneous.say.allowed.roles.Count() >= 1
                                || config.commands.miscellaneous.say.blocked.roles.Count() >= 1)
                            {
                                if (config.commands.miscellaneous.say.allowed.roles.Contains(role.Id))
                                    return true;
                                if (config.commands.miscellaneous.say.blocked.roles.Contains(role.Id))
                                    break;
                            }
                            else { break; }
                        }
                        if (config.commands.miscellaneous.say.isPublic)
                            return true;
                        return false;
                    }

                case "embed":
                    {
                        if (config.commands.miscellaneous.embed.blocked.users.Contains(ctx.Member.Id))
                            return false;
                        if (config.commands.miscellaneous.embed.allowed.users.Contains(ctx.Member.Id))
                            return true;
                        foreach (var role in ctx.Member.Roles)
                        {
                            if (config.commands.miscellaneous.embed.allowed.roles.Count() >= 1
                                || config.commands.miscellaneous.embed.blocked.roles.Count() >= 1)
                            {
                                if (config.commands.miscellaneous.embed.allowed.roles.Contains(role.Id))
                                    return true;
                                if (config.commands.miscellaneous.embed.blocked.roles.Contains(role.Id))
                                    break;
                            }
                            else { break; }
                        }
                        if (config.commands.miscellaneous.embed.isPublic)
                            return true;
                        return false;
                    }

                case "bot":
                    {
                        if (config.commands.miscellaneous.bot.blocked.users.Contains(ctx.Member.Id))
                            return false;
                        if (config.commands.miscellaneous.bot.allowed.users.Contains(ctx.Member.Id))
                            return true;
                        foreach (var role in ctx.Member.Roles)
                        {
                            if (config.commands.miscellaneous.bot.allowed.roles.Count() >= 1
                                || config.commands.miscellaneous.bot.blocked.roles.Count() >= 1)
                            {
                                if (config.commands.miscellaneous.bot.allowed.roles.Contains(role.Id))
                                    return true;
                                if (config.commands.miscellaneous.bot.blocked.roles.Contains(role.Id))
                                    break;
                            }
                            else { break; }
                        }
                        if (config.commands.miscellaneous.bot.isPublic)
                            return true;
                        return false;
                    }

                default:
                    return false;
            }
        }
    }
}
