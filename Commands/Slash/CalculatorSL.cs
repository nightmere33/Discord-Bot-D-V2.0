using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System.Threading.Tasks;

namespace DiscordBotTemplate.Commands.Slash
{
    [SlashCommandGroup("calculator","perform calculator operations")]
    public class CalculatorSL : ApplicationCommandModule
    {
        [SlashCommand("add","add two numbers togather")]
        public async Task Add(InteractionContext ctx , [Option("number1","Number 1")] double number1 , [Option("number2", "Number 2")] double number2)
        {
            await ctx.DeferAsync();
            var result = number1 + number2;
            var outputEmbed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Green,

                Title = $"{number1} + {number2} ",
                Description = $"{result}"


            };
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }

        [SlashCommand("subtract", "subtrat two numbers ")]
        public async Task Subtract(InteractionContext ctx, [Option("number1", "Number 1")] double number1, [Option("number2", "Number 2")] double number2)
        {
            await ctx.DeferAsync();
            var result = number1 - number2;
            var outputEmbed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Green,

                Title = $"{number1} - {number2} ",
                Description = $"{result}"


            };
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
        [SlashCommand("Multiply", "multiply two numbers ")]
        public async Task Mult(InteractionContext ctx, [Option("number1", "Number 1")] double number1, [Option("number2", "Number 2")] double number2)
        {
            await ctx.DeferAsync();
            var result = number1 * number2;
            var outputEmbed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Green,

                Title = $"{number1} X {number2} ",
                Description = $"{result}"


            };
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
        [SlashCommand("division", "Divide two numbers")]
        public async Task Divide(InteractionContext ctx, [Option("number1", "Number 1")] double number1, [Option("number2", "Number 2")] double number2)
        {
            await ctx.DeferAsync();
            try
            {
                // Check for division by zero
                if (number2 == 0)
                {
                    await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Error: Cannot divide by zero."));
                    return;
                }

                var result = number1 / number2;
                var outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"{number1} ÷ {number2}",
                    Description = $"{result}"
                };
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
            }
            catch (System.Exception e)
            {
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"Error: {e.Message}"));
            }
        }

    }
}
