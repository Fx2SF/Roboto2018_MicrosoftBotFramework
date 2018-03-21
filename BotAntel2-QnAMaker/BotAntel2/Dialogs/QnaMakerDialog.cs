using System;
using QnAMakerDialog;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;

namespace BotAntel2.Dialogs
{
    [Serializable]
    //Conexion con QnAMaker
    //Cambiamos el primer codigo por el ID, y el segundo por la subscription key
    [QnAMakerService("32ba1b0c-dd10-4f6f-a850-e7bec91a4bd7", "10e9e3998fca42178d00dffd4072bac2")] //ID y Subscription key

        public class QnaMakerDialog:QnAMakerDialog<Object> 
        {
        public override async Task NoMatchHandler(IDialogContext context, string text) {
            await context.PostAsync($"Lo siento, no logre encontrar una respuesta para '{text}'."); //Respuesta de ChatBot
            
            await context.PostAsync("Podrias reformular tu pregunta?");
            context.Wait(MessageReceived); 
        }

        }
}