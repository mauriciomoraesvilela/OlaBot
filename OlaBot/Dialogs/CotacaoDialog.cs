using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
//using Microsoft.Bot.Connector;

namespace OlaBot.Dialogs
{
    [Serializable]
    // Incluir Entidade LUIS
    // Colocar o ModelID e o SubscriptionID que são obtidos no endpoint do bot criado no LUIS
    [LuisModel("1ad74dd0-c948-4079-a5fb-2e4c55ee413b", "126cd101447440f7918079fd21558cea")]
    
    // Trocar IDialog<object> para por LuisDialog<object> pois é uma classe para acessar os recursos do LUIS
    public class CotacaoDialog : LuisDialog<object>
    {
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Desculpe, não consegui entender a frase: {result.Query}");
        }

        [LuisIntent("Sobre")]
        public async Task Sobre(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Eu sou um Bot e estou sempre aprendendo.");
        }

        [LuisIntent("Cumprimento")]
        public async Task Cumprimento(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Olá! Eu sou um Bot que faz cotação de moedas.");
            await context.PostAsync("Você pode solictar cotações sobre: Dolar, Euro e Bitcoin.");
        }

        [LuisIntent("Cotacao")]
        public async Task Cotacao(IDialogContext context, LuisResult result)
        {
            // O ? significa Nulo operator, ou seja, se for nulo, retorna nulo

            var moedas = result.Entities?.Select(e => e.Entity); // O e => e.Type, pega todas as entidades passadas para o LUIS
            await context.PostAsync($"Eu farei cotações para as moedas: {string.Join(", ", moedas.ToArray())}");
        }

    }
}