using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Newtonsoft.Json;
using System.Net.Http;
using Telegram.Bot.Types.ReplyMarkups;

namespace Awesome
{
    static class Cont
    {
        // global int
        public static int porCovid=0;
    }
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static ITelegramBotClient botClient;
        static void Main()
        {

            //Token del bot de la clase: 1405453733:AAHu9DKWnQCIymcrRKwiObzwrdbFfNDl0do
            botClient = new TelegramBotClient("1405453733:AAHu9DKWnQCIymcrRKwiObzwrdbFfNDl0do");

            var me = botClient.GetMeAsync().Result;
            Console.Title = me.Username;
            Console.WriteLine(
              $"botClient>> Hola! Me llamo {me.FirstName}."
            );

            botClient.OnMessage += Bot_OnMessage;
            botClient.OnCallbackQuery += BotOnCallbackQueryRecieved;
            botClient.OnReceiveError += BotOnReceiveError;
            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();
        }
        static void BotOnReceiveError(object sender, ReceiveErrorEventArgs e)
        {
            Console.WriteLine($"botClient>> Error recibido: " + e.ApiRequestException.Message);
        }

        public static async void BotOnCallbackQueryRecieved(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {

            var callbackQuery = callbackQueryEventArgs.CallbackQuery;

            Console.WriteLine($"botCliente>> El usuario selecciono {callbackQuery.Data}");
		
	 if (callbackQuery.Data == "bien1" || callbackQuery.Data == "mal1")
            {
                Cont.porCovid = 0;
                if (callbackQuery.Data == "mal1")
                {
                    Cont.porCovid += 1;
                }
                SegundaPregunta(callbackQuery);
            }
            else if (callbackQuery.Data == "si2" || callbackQuery.Data == "no2")
            {
                if (callbackQuery.Data == "si2")
                {
                    Cont.porCovid += 1;
                }
                TerceraPregunta(callbackQuery);
            }
            else if (callbackQuery.Data == "si3" || callbackQuery.Data == "no3")
            {
                if (callbackQuery.Data == "si3")
                {
                    Cont.porCovid += 1;
                }
                CuartaPregunta(callbackQuery);
            }
            else if (callbackQuery.Data == "si4" || callbackQuery.Data == "no4")
            {
                if (callbackQuery.Data == "si4")
                {
                    Cont.porCovid += 1;
                }
                QuintaPregunta(callbackQuery);
            }
            else if (callbackQuery.Data == "si5" || callbackQuery.Data == "no5")
            {
                if (callbackQuery.Data == "si5")
                {
                    Cont.porCovid += 1;
                }
                SextaPregunta(callbackQuery);
            }
            else if (callbackQuery.Data == "si6" || callbackQuery.Data == "no6")
            {
                if (callbackQuery.Data == "si6")
                {
                    Cont.porCovid += 1;
                }
                SeptimaPregunta(callbackQuery);
            }
            else if (callbackQuery.Data == "si7" || callbackQuery.Data == "no7")
            {
                if (callbackQuery.Data == "si7")
                {
                    Cont.porCovid += 1;
                }
                OctavaPregunta(callbackQuery);
            }
            else if (callbackQuery.Data == "si8" || callbackQuery.Data == "no8")
            {
                if (callbackQuery.Data == "si8")
                {
                    Cont.porCovid += 1;
                }
                NovenaPregunta(callbackQuery);
            }
            else if (callbackQuery.Data == "si9" || callbackQuery.Data == "no9")
            {
                if (callbackQuery.Data == "si9")
                {
                    Cont.porCovid += 1;
                }
                DecimaPregunta(callbackQuery);
            }
            else if (callbackQuery.Data == "si10" || callbackQuery.Data == "no10")
            {
                if (callbackQuery.Data == "si10")
                {
                    Cont.porCovid += 1;
                }
                OnceavaPregunta(callbackQuery);
            }
            else if (callbackQuery.Data == "si11" || callbackQuery.Data == "no11")
            {
                if (callbackQuery.Data == "si11")
                {
                    Cont.porCovid += 1;
                }
                DoceavaPregunta(callbackQuery);
            }
            else if (callbackQuery.Data == "si12" || callbackQuery.Data == "no12")
            {
                if (callbackQuery.Data == "si12")
                {
                    Cont.porCovid += 1;
                }
                Console.WriteLine(Cont.porCovid);
                float porcentaje = (Cont.porCovid * 100) / 12f;
                Console.WriteLine(porcentaje);
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "La Probabilidad de COVID-19 es : " + porcentaje + "%");
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "Gracias por responder este cuestionario \nEscriba /start para volver al menu");
            }


            if (callbackQuery.Data == "EInter")
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://api.covid19api.com/summary");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    dynamic obj = JsonConvert.DeserializeObject(responseBody);
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id,
                        "Estadisticas Internacionales" +
                        "\nNuevos Casos Confirmados: " + obj.Global.NewConfirmed +
                        "\nTotal Casos Confirmados: " + obj.Global.TotalConfirmed +
                        "\nNuevos Muertos: " + obj.Global.NewDeaths +
                        "\nTotal Muertos: " + obj.Global.TotalDeaths +
                        "\nNuevos Recuperados: " + obj.Global.NewRecovered +
                        "\nTotal Recuperados: " + obj.Global.TotalRecovered);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "https://news.google.com/covid19/map?hl=es-419&gl=US&ceid=US%3Aes-419");
            }
            else if (callbackQuery.Data == "ENac")
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://api.covid19api.com/summary");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    dynamic obj = JsonConvert.DeserializeObject(responseBody);
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id,
                        "Estadisticas Nacionales" +
                        "\nNuevos Casos Confirmados: " + obj.Countries[73].NewConfirmed +
                        "\nTotal Casos Confirmados: " + obj.Countries[73].TotalConfirmed +
                        "\nNuevos Muertos: " + obj.Countries[73].NewDeaths +
                        "\nTotal Muertos: " + obj.Countries[73].TotalDeaths +
                        "\nNuevos Recuperados: " + obj.Countries[73].NewRecovered +
                        "\nTotal Recuperados: " + obj.Countries[73].TotalRecovered);

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "https://covid19honduras.org/");
            }

            else if (callbackQuery.Data == "Estadisticas")
            {
                EstadisticaAsync(callbackQuery);
            }
            else if (callbackQuery.Data == "Circulacion")
            {

                DiaCirculacionAsync(callbackQuery);

            }
            else if (callbackQuery.Data == "AutoEvaluate")
            {

                CuestionarioSintomas(callbackQuery);

            }
            else if (callbackQuery.Data == "/help")
            {

                await botClient.SendTextMessageAsync(
                  chatId: callbackQuery.Message.Chat.Id,
                  text: "Comandos:\n" +
                      "/start - ejecuta los comandos COVID 19\n" +
                      "/circulacion - muestra los dias de circulación\n" +
                      "/stats - muestra las estadisticas de COVID 19\n" +
                      "/evaluate - muestra una serie de preguntas sobre los sintomas que padeces\n" +
                      "/recomendaciones - muestra una serie de recomendaciones para prevenir el COVID 19\n"
                );

            }
            else if (callbackQuery.Data == "prevenir")
            {

                await botClient.SendTextMessageAsync(
                  chatId: callbackQuery.Message.Chat.Id,
                  text: "Consejos para prevenir COVID-19\n" +
                        "1. Utiliza constantemente alcohol en gel\n" +
                        "2. Toma abundante agua y cuida tu alimentación para que mantengas tu sistema inmunologico fortalecido\n" +
                        "3. Si tienes algún sintoma busca un medio y comunicate con tu supervisor\n" +
                        "4. No saludes de mano o beso a las personas\n" +
                        "5. Lávate las manos frecuentemente con agua y jabón\n" +
                        "6. Limpia y desinfecta las superficies y objetos de uso común\n" +
                        "7. Evita tocar tus ojos, nariz y boca sin haberte lavado las manos\n" +
                        "8. Cubre tu nariz y boca con el antebrazo o con un pañuelo desechable al estornudar o toser"
                );

            }
            else
            {

                await botClient.AnswerCallbackQueryAsync(
                  callbackQueryId: callbackQuery.Id,
                  text: $"..."
                );

            }

        }
        static async void EstadisticaAsync(CallbackQuery callbackQuery)
        {


            var Estadisticas = new InlineKeyboardMarkup(new[]{
              new []{
                InlineKeyboardButton.WithCallbackData(
                  text:"Internacionales",
                  callbackData: "EInter"),
                  InlineKeyboardButton.WithCallbackData(
                    text:"Nacionales",
                    callbackData: "ENac")
              }
              });
            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "¿Que desea ver?", replyMarkup: Estadisticas);
        }

        static async void DiaCirculacionAsync(CallbackQuery callbackQuery)
        {

            await botClient.SendTextMessageAsync(
              chatId: callbackQuery.Message.Chat.Id,
              text: "¡¡¡Aqui va la informacion de los dias de circulación!!!"
            );

        }

        static async void CuestionarioSintomas(CallbackQuery callbackQuery)
        {

            var respuestas = new InlineKeyboardMarkup(new[]{

        new[]{

          InlineKeyboardButton.WithCallbackData(
            text:"Bien",
            callbackData: "bien"
          ),
          InlineKeyboardButton.WithCallbackData(
            text:"Mal",
            callbackData:"mal"
          )
        }

      });

            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "¿Como te sientes hoy?", replyMarkup: respuestas);
            SegundaPregunta(callbackQuery);

        }

        static async void SegundaPregunta(CallbackQuery callbackQuery)
        {

            var respuestas = new InlineKeyboardMarkup(new[]{

       new[]{
         InlineKeyboardButton.WithCallbackData(
           text: "Sí",
           callbackData: "si"
         ),
         InlineKeyboardButton.WithCallbackData(
            text: "No",
            callbackData: "no"
         )

       }

     });

            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "¿Has viajado en los ultimos 14 dias fuera del país/estado?", replyMarkup: respuestas);
            TerceraPregunta(callbackQuery);
        }

        static async void TerceraPregunta(CallbackQuery callbackQuery)
        {

            var respuestas = new InlineKeyboardMarkup(new[]{

       new[]{
         InlineKeyboardButton.WithCallbackData(
           text: "Sí",
           callbackData: "si"
         ),
         InlineKeyboardButton.WithCallbackData(
            text: "No",
            callbackData: "no"
         )
       }

      });

            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "¿Has tenido contacto directo con una persona diagnosticada con COVID-19?", replyMarkup: respuestas);
            CuartaPregunta(callbackQuery);
        }

        static async void CuartaPregunta(CallbackQuery callbackQuery)
        {

            var respuestas = new InlineKeyboardMarkup(new[]{

       new[]{
         InlineKeyboardButton.WithCallbackData(
           text: "Sí",
           callbackData: "si"
         ),
         InlineKeyboardButton.WithCallbackData(
            text: "No",
            callbackData: "no"
         )
       }

      });

            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "¿Tienes fiebre mayor a 37.5 grados?", replyMarkup: respuestas);
            QuintaPregunta(callbackQuery);
        }

        static async void QuintaPregunta(CallbackQuery callbackQuery)
        {

            var respuestas = new InlineKeyboardMarkup(new[]{

       new[]{
         InlineKeyboardButton.WithCallbackData(
           text: "Sí",
           callbackData: "si"
         ),
         InlineKeyboardButton.WithCallbackData(
            text: "No",
            callbackData: "no"
         )
       }

      });

            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "¿Te duele la garganta?", replyMarkup: respuestas);
            SextaPregunta(callbackQuery);
        }

        static async void SextaPregunta(CallbackQuery callbackQuery)
        {

            var respuestas = new InlineKeyboardMarkup(new[]{

       new[]{
         InlineKeyboardButton.WithCallbackData(
           text: "Sí",
           callbackData: "si"
         ),
         InlineKeyboardButton.WithCallbackData(
            text: "No",
            callbackData: "no"
         )
       }

      });

            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "¿Tienes tos seca y persistente?", replyMarkup: respuestas);
            SeptimaPregunta(callbackQuery);
        }

        static async void SeptimaPregunta(CallbackQuery callbackQuery)
        {

            var respuestas = new InlineKeyboardMarkup(new[]{

       new[]{
         InlineKeyboardButton.WithCallbackData(
           text: "Sí",
           callbackData: "si"
         ),
         InlineKeyboardButton.WithCallbackData(
            text: "No",
            callbackData: "no"
         )
       }

      });

            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "¿Te cuest trabajo respirar?", replyMarkup: respuestas);
            OctavaPregunta(callbackQuery);
        }

        static async void OctavaPregunta(CallbackQuery callbackQuery)
        {

            var respuestas = new InlineKeyboardMarkup(new[]{

       new[]{
         InlineKeyboardButton.WithCallbackData(
           text: "Sí",
           callbackData: "si"
         ),
         InlineKeyboardButton.WithCallbackData(
            text: "No",
            callbackData: "no"
         )
       }

      });

            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "¿Tienes dolor muscular, de cabeza, y/o de articulaciones?", replyMarkup: respuestas);
            NovenaPregunta(callbackQuery);
        }

        static async void NovenaPregunta(CallbackQuery callbackQuery)
        {

            var respuestas = new InlineKeyboardMarkup(new[]{

       new[]{
         InlineKeyboardButton.WithCallbackData(
           text: "Sí",
           callbackData: "si"
         ),
         InlineKeyboardButton.WithCallbackData(
            text: "No",
            callbackData: "no"
         )
       }

      });

            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "¿Tienes perdida de sentido del gusto u olfato?", replyMarkup: respuestas);
            DecimaPregunta(callbackQuery);
        }

        static async void DecimaPregunta(CallbackQuery callbackQuery)
        {

            var respuestas = new InlineKeyboardMarkup(new[]{

       new[]{
         InlineKeyboardButton.WithCallbackData(
           text: "Sí",
           callbackData: "si"
         ),
         InlineKeyboardButton.WithCallbackData(
            text: "No",
            callbackData: "no"
         )
       }

      });

            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "¿Tienes diarrea, nausea o vomito?", replyMarkup: respuestas);
            OnceavaPregunta(callbackQuery);
        }

        static async void OnceavaPregunta(CallbackQuery callbackQuery)
        {

            var respuestas = new InlineKeyboardMarkup(new[]{

       new[]{
         InlineKeyboardButton.WithCallbackData(
           text: "Sí",
           callbackData: "si"
         ),
         InlineKeyboardButton.WithCallbackData(
            text: "No",
            callbackData: "no"
         )
       }

      });

            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "¿Te has hecho la prueba de COVID-19 \n (PCR, IgG, IgM)?", replyMarkup: respuestas);
            DoceavaPregunta(callbackQuery);
        }

        static async void DoceavaPregunta(CallbackQuery callbackQuery)
        {

            var respuestas = new InlineKeyboardMarkup(new[]{

       new[]{
         InlineKeyboardButton.WithCallbackData(
           text: "Sí",
           callbackData: "si"
         ),
         InlineKeyboardButton.WithCallbackData(
            text: "No",
            callbackData: "no"
         )
       }

      });

            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "¿Usted se encuentra en alguna de las siguientes condiciones?\n" +
                    "* Mayor a 60 años\n" +
                    "* Enfermedades cardiovasculares\n" +
                    "* Hipertensión arterial\n" +
                    "* Diabetes\n" +
                    "* Enfermedades respiratorias (pulmonar, cronica, asma)\n" +
                    "* Insuficiencia renal cronica\n" +
                    "* Cancer\n" +
                    "* Obesidad\n" +
                    "* Enfermedad o tratamiento immunosupresor", replyMarkup: respuestas);

        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {

                Console.WriteLine($"botClient>> Received a text message from @{e.Message.Chat.Username}:" + e.Message.Text);

                if (e.Message.Text == "/start")
                {

                    var BotonesHYD = new InlineKeyboardMarkup(new[]{
              new []{
                InlineKeyboardButton.WithCallbackData(
                  text:"Días de Circulación",
                  callbackData: "Circulacion"),
                  InlineKeyboardButton.WithCallbackData(
                    text:"Auto Evaluate",
                    callbackData: "AutoEvaluate")
              },
               new []{
                InlineKeyboardButton.WithCallbackData(
                  text:"Estadísticas",
                  callbackData: "Estadisticas"),
                  InlineKeyboardButton.WithCallbackData(
                  text:"Prevenir COVID-19",
                  callbackData: "prevenir")
              },
              new[]{
                InlineKeyboardButton.WithCallbackData(
                  text:"Que puedo hacer?",
                  callbackData:"/help")
              }
          });

                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Bienvenid@ al BOT COVID19HN \n Selecciona el comando a ejecutar", replyMarkup: BotonesHYD);
                }

            }
        }

    }
}
