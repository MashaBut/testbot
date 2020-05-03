using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using testProject.Commands;
using testProject.DataAccess;
using Message = testProject.Models.Message;

namespace testProject.Controllers
{
    [ApiController]
    [Route("api")]
    public class MessageFormController : ControllerBase
    {
        ApplicationContext _context;
        SendMessage _sendMessage;
        private static ITelegramBotClient botClient = new TelegramBotClient("1160244205:AAHPaBrxCQR0YGgeOjCdtQfXRR1_b6GYXPU");

        public MessageFormController(ApplicationContext context, SendMessage sendMessage)
        {
            _context = context;
            _sendMessage = sendMessage;
        }

        [HttpPost]
        public async Task<OkResult> Post([FromBody]Message message)
        {
            MessageDataAccess.SaveMessage(message, _context);
            await _sendMessage.HandleAsync(botClient, 350155991, message.text);
            return Ok();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var id = e.Message.Chat.Id;
            Console.WriteLine("ID:  " + id);
            if (e.Message.Text != null)
            {
                using (StreamWriter writer = System.IO.File.CreateText("newfile.txt"))
                {
                   await writer.WriteAsync(id.ToString());
                }
            }
        }

        [HttpGet]
        public IActionResult GetMessage()
        {
            return StatusCode(200, MessageDataAccess.GetAllMessage(_context));
        }
    }   
}