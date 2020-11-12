using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Awesome
{
    class Program
    {
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

            if (callbackQuery.Data == "Circulacion")
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
                InlineKeyboardButton.WithUrl(
                  text:"Estadísticas",
                  url: "https://www.google.com/search?q=coronavirus+statistics&oq=coronavirus+st&aqs=chrome.0.0i67j69i57j0l6.6211j0j4&sourceid=chrome&ie=UTF-8"),
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