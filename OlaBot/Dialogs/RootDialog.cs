using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace OlaBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            await context.PostAsync("** Olá, tudo bem?");

            var message = activity.CreateReply();

            var heroCard = new HeroCard();
            heroCard.Title = "Planeta";
            heroCard.Subtitle = "Universo";
            heroCard.Images = new List<CardImage>
                {
                    new CardImage(@"d:\ProjetoBots\OlaBots02\imagens\o-sistema-solar.jpg", "Planeta")
                };
            message.Attachments.Add(heroCard.ToAttachment());

            await context.PostAsync(message);

            context.Wait(MessageReceivedAsync);
        }
    }
}