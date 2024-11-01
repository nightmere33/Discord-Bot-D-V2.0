using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTemplate.Commands
{
    public class InteractionComponents : BaseCommandModule
    {
        [Command("button")]
        public async Task Buttons(CommandContext ctx)
        {

            var button = new DiscordButtonComponent(ButtonStyle.Primary,"button1","DUMB" );
            var button2 = new DiscordButtonComponent(ButtonStyle.Primary, "button2", "3HEAD");
            var button3 = new DiscordButtonComponent(ButtonStyle.Success, "button3", "💰PAY-ME");

            var message = new DiscordMessageBuilder().AddEmbed(new DiscordEmbedBuilder().WithColor(DiscordColor.Aquamarine).
                WithTitle(" ARE YOU "))
                .AddComponents(button,button2,button3);
            await ctx.Channel.SendMessageAsync(message);
            
        }


        [Command("help")]
        public async Task HelpCommand(CommandContext ctx)
        {
            var basicsButton = new DiscordButtonComponent(ButtonStyle.Primary, "basicsButton", "Basics");
            var calculatorButton = new DiscordButtonComponent(ButtonStyle.Success, "calculatorButton", "Calculator");

            var message = new DiscordMessageBuilder().AddEmbed(new DiscordEmbedBuilder()
                .WithTitle("Help Section").WithDescription("Please press a button to view its commands")).AddComponents(basicsButton,calculatorButton);

            await ctx.Channel.SendMessageAsync(message);


        }

       

    }
}
