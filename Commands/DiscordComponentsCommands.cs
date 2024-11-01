using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace DiscordBotTemplate.Commands
{
    public class DiscordComponentsCommands : BaseCommandModule
    {

        

        [Command("dropdown-list")]
        public async Task DropDownList(CommandContext ctx)
        {
            List<DiscordSelectComponentOption> optionList = new List<DiscordSelectComponentOption>();
            optionList.Add(new DiscordSelectComponentOption("help", "option1"));
            optionList.Add(new DiscordSelectComponentOption("Get Admin", "option2"));
            

            var options = optionList.AsEnumerable();


            var dropDown = new DiscordSelectComponent("dropDownList","Select...",options);

            var dropDownMessage = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()
                .WithAuthor("Nightmere33 BOT Plugins Commands", null, "https://preview.redd.it/people-say-i-kinda-look-like-a-badass-skeleton-thoughts-i-v0-z2xnsll8gyma1.jpg?width=640&crop=smart&auto=webp&s=1ec7d6ac23a811169b125727912bcffd9f541433")
                .WithDescription("**__Options__ :**\n\n`!help` -> see the availabe commands \n " +
                "`get admin` -> summon the owner of the server for more help ! ")
                .WithThumbnail("https://preview.redd.it/people-say-i-kinda-look-like-a-badass-skeleton-thoughts-i-v0-z2xnsll8gyma1.jpg?width=640&crop=smart&auto=webp&s=1ec7d6ac23a811169b125727912bcffd9f541433")
                .WithColor(DiscordColor.Gold)).AddComponents(dropDown);

            await ctx.Channel.SendMessageAsync(dropDownMessage);


        }

        

        private readonly ulong modRoleId = 1212101330706104351; // Replace with your actual MOD role ID

        [Command("dm")]
        [Description("Sends a direct message to a specific user with a custom message.")]
        public async Task DMCommand(CommandContext ctx, DiscordUser targetUser, [RemainingText] string message)
        {
            // Check if the command invoker has the MOD role
            if (!ctx.Member.Roles.Any(role => role.Id == modRoleId))
            {
                await ctx.RespondAsync("You do not have permission to use this command.");
                return;
            }

            // Attempt to retrieve the user as a DiscordMember to send a DM
            try
            {
                var member = await ctx.Guild.GetMemberAsync(targetUser.Id);
                var dmChannel = await member.CreateDmChannelAsync();
                await dmChannel.SendMessageAsync(message);
                await ctx.RespondAsync($"Message successfully sent to {member.Username}.");
            }
            catch
            {
                await ctx.RespondAsync("Failed to send the message. The user may have DMs disabled or is not a member of this server.");
            }
        }

    }
}
