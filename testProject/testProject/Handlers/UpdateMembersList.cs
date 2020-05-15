using IBWT.Framework.Abstractions;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace testProject.Handlers
{
    class UpdateMembersList : IUpdateHandler
    {
        private readonly ILogger<UpdateMembersList> _logger;

        public UpdateMembersList(ILogger<UpdateMembersList> logger)
        {
            _logger = logger;
        }

        public Task HandleAsync(IUpdateContext context, UpdateDelegate next, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "There were updates to the members list of chat {0}.",
                context.Update.Message?.Chat.Id ?? context.Update.ChannelPost.Chat.Id
            );

            return next(context, cancellationToken);
        }
    }
}
