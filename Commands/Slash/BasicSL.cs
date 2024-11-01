using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DiscordBotTemplate.Commands.Slash
{
    public class BasicSL : ApplicationCommandModule
    {
        [SlashCommand("test", "this is my first slash command")]
        public async Task MyFirstSCommand(InteractionContext ctx)
        {

            /*  await ctx.DeferAsync();
              await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"hello {ctx.User.Username}"));*/
            // await ctx.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("hello"));

            //we create a empty temp response then modify it and put the embed in it s place using deferasync
            try
            {
                await ctx.DeferAsync();

                var embedMessage = new DiscordEmbedBuilder
                {

                    Color = DiscordColor.Red,
                    Title = $"Hello {ctx.User.Username}",
                    Description = "Pay me 5$ for seeing this "



                };

                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }





        }
        [SlashCommand("nuke", "massil nuke command")]
        public async Task secondcmd(InteractionContext ctx)
        {
            await ctx.DeferAsync();
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("https://tenor.com/view/boom-gif-20562682"));

        }

        [SlashCommand("parameters", "This slash command allow paramaters")]
        public async Task SlashCommandParamaters(InteractionContext ctx, [Option("testoption", "Type in anything")] string testParamater)
        {
            await ctx.DeferAsync();

            var embedMessage = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Brown,
                Title = "Test Embed",
                Description = testParamater


            };

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));

        }
        [SlashCommand("FreeCash", "Pay me now! POGIES")]
        public async Task Payme(InteractionContext ctx, [Option("amount", "Give me money")] double amount, [Option("user", "Enter username")] DiscordUser user)
        {
            await ctx.DeferAsync();

            var embedMessage = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Red,
                Title = "Sending Money...",
                Description = $@"Target: {user.Username}#{user.Discriminator}
                         Amount: {amount}$"
            };

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));
        }

        [SlashCommand("discordParameters", "This slash command allows passing of DiscordParameters")]
        public async Task DiscordParameters(InteractionContext ctx,
        [Option("user", "pass in a discord user")] DiscordUser user,
        [Option("Title", "write a description")] string title,
        [Option("file", "Upload a file here")] DiscordAttachment file)
        {
            await ctx.DeferAsync();

            // Convert file size from bytes to MB
            double fileSizeInMb = file.FileSize / (1024.0 * 1024.0);

            var member = (DiscordMember)user;
            var embedMessage = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Purple,
                Title = title,
                Description = $"**{member.Nickname}** uploaded a file:\n**{file.FileName}** ({fileSizeInMb:0.00} MB)"
            };

            

            // Define supported file extensions for videos and images
            string[] videoExtensions = { ".mp4", ".mov", ".avi", ".mkv" };
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

            string fileExtension = Path.GetExtension(file.FileName).ToLower();

            if (videoExtensions.Contains(fileExtension))
            {
                // For videos, we can't use file.Stream. Instead, we will notify the user to check the file URL.
                embedMessage.Description += $"\n[Click here to view the video]({file.Url})"; // Adding a link to view the video
            }
            else if (imageExtensions.Contains(fileExtension))
            {
                // If it's an image, set the ImageUrl for the embed
                embedMessage.ImageUrl = file.Url; // Display the image in the embed
            }
            var builder = new DiscordWebhookBuilder().AddEmbed(embedMessage);
            // Finally, send the response
            await ctx.EditResponseAsync(builder);
        }

    }
}
