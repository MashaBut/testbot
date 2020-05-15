using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using testProject.Data.Entities;
using testProject.Data.Repository;
using testProject.Handlers;

namespace testProject.Controllers
{
    [ApiController]
    [Route("api")]
    public class MessageController : ControllerBase
    {
        MessageRepository messagesRepository;
        ApplicationContext _context;
        MessageHandler messageHandler = new MessageHandler();
        long idUser;
        private static ITelegramBotClient botClient = new TelegramBotClient("1160244205:AAHPaBrxCQR0YGgeOjCdtQfXRR1_b6GYXPU");

        public MessageController(ApplicationContext context)
        {
            _context = context;
            messagesRepository = new MessageRepository(context);
            List<TGUser> Users = _context.TGUsers.ToList();
            idUser = Users[Users.Count - 1].Id;
        }

        [HttpPost]
        public async Task<OkResult> Post([FromBody]Message message)
        {
            messagesRepository.Add(message);
            await messageHandler.HandleAsync(botClient, idUser, message.text);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetMessage()
        {
            return StatusCode(200, _context.TGUsers.ToList());
        }
    }   
}