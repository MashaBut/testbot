using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace testProject.Handlers
{
    public class MessageHandler
    {
        public async Task HandleAsync(ITelegramBotClient client, ChatId id, string text)
        {
            await client.SendTextMessageAsync(id, text);
        }
    }
}