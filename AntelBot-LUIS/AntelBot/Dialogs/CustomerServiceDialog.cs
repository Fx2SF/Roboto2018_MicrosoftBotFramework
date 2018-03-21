using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;



namespace AntelBot.Dialogs
{
    [Serializable] //Serializamos la clase

    //Conexion con LUIS
    //Cambiamos modelID por el codigo extraido de Settings, y Subscriptionkey el codigo sacado de Publish en LUIS.ai
    [LuisModel(modelID: "55955444-f1d2-4208-bd6d-bd825d716987", subscriptionKey: "d56b26d139d845079238f506adf84544")]
    

    public class CustomerServiceDialog : LuisDialog<string> //Agregamos :LuisDialog<string> a la
    {
        [LuisIntent("None")] 
        public async Task None(IDialogContext context, LuisResult result) {
            await context.PostAsync("Lo siento, no puedo responder esa pregunta"); //Chatbot responde ante una frase que LUIS no pudo relacionar a alguna pregunta.
            await Task.Delay(2000); //Chatbot hace una pausa para entre textos
            await context.PostAsync("En que mas te puedo ayudar?");
           
        }

        [LuisIntent("Bienvenida")]
        public async Task Bienvenida(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hola, estoy para asistirte.");
            await Task.Delay(2000);
            await context.PostAsync("En que puedo ayudarte?");
            
        }

        [LuisIntent("Duplicado Factura")]
        public async Task DuplicadoFactura(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Puedes obtener un duplicado de la factura ingresando tu numero de cuenta en : http://www.antel.com.uy/antel-en-linea");
            await Task.Delay(2000);
            await context.PostAsync("Algo mas?");
        }

        [LuisIntent("Descargar MMS")]
        public async Task MMS(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Puedes visualizar tu mensaje MMS en : http://www.antel.com.uy/antel-en-linea");
            await Task.Delay(2000);
            await context.PostAsync("En que mas puedo ayudarte?");
        }
        

        [LuisIntent("Consumo internet")]
        public async Task Consumo(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Para consultar tu consumo de internet debes registrarte en : http://www.antel.com.uy/antel-en-linea");
            await Task.Delay(2000);
            await context.PostAsync("Tienes alguna otra consulta?");
        }

        [LuisIntent("Celulares ventas")]
        public async Task Ventas(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Puedes ver, consultar stock de los celulares a la venta en : https://tienda.antel.com.uy/");
            await Task.Delay(2000);
            await context.PostAsync("Que mas necesitabas saber?");
        }



        [LuisIntent("Numeros Amigos")]
        public async Task NumerosAmigos(IDialogContext context, LuisResult result)
        {
            await Task.Delay(2000);
            await context.PostAsync("Los numeros amigos son un beneficio disponible para contratos con y sin límite de crédito y Prepago con Plan Amigos, donde podrás elegir 5 celulares de Antel para realizar llamadas con un costo de $0.99 iva inc. el minuto.");
            await Task.Delay(2000);
            await context.PostAsync("Para mas informacion visita : www.antel.com.uy");

            await context.PostAsync("Que mas necesitabas saber?");
        }

        [LuisIntent("Agradecimientos")]
        public async Task Agradecimientoss(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Ha sido un placer ayudarte, que tengas un buen dia.");

        }
    }
}