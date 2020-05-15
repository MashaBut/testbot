using IBWT.Framework.Abstractions;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using testProject.Data.Entities;
using testProject.Data.Repository;

namespace testProject.Handlers.Commands
{
    public class StartCommand : CommandBase
    {
        private readonly IDataRepository<TGUser> userRepository;
        private readonly ILogger<StartCommand> logger;

        public StartCommand(IDataRepository<TGUser> userRepository, ILogger<StartCommand> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }
        public override async Task HandleAsync(IUpdateContext context, UpdateDelegate next,string[] args,CancellationToken cancellationToken)
        {
            var msg = context.Update.Message;
            if (userRepository.Get(msg.Chat.Id) == null)
            {
                logger.LogInformation($"User created {msg.Chat.Id}, {msg.Chat.Username}");
                userRepository.Add(new TGUser()
                {
                    Id = msg.Chat.Id,
                    FirstName = msg.Chat.FirstName,
                    LastName = msg.Chat.LastName,
                    Nickname = msg.Chat.Username
                });
            }
            logger.LogInformation($"User created {msg.Chat.Id}, {msg.Chat.Username}");
            await context.Bot.Client.SendTextMessageAsync(
                msg.Chat,
                "Приветствую!",
                ParseMode.Markdown,
                cancellationToken: cancellationToken
            );
            await next(context, cancellationToken);
        }
    }
}
