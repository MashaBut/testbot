using Microsoft.AspNetCore.Builder;
using testProject.Services;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;

namespace testProject.Extensions
{
    static class AppStartupExtensions
    {
        public static IApplicationBuilder UseTelegramBotLongPolling<TBot>(
           this IApplicationBuilder app,
           IBotBuilder botBuilder,
           TimeSpan startAfter = default,
           CancellationToken cancellationToken = default
       )
           where TBot : BotBase
        {
            if (startAfter == default)
            {
                startAfter = TimeSpan.FromSeconds(2);
            }

            var updateManager = new UpdatePollingManager<TBot>(botBuilder, new BotServiceProvider(app));

            Task.Run(async () =>
            {
                await Task.Delay(startAfter, cancellationToken);
                await updateManager.RunAsync(cancellationToken: cancellationToken);
            }, cancellationToken)
            .ContinueWith(t =>
            {// ToDo use logger
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(t.Exception);
                Console.ResetColor();
                throw t.Exception;
            }, TaskContinuationOptions.OnlyOnFaulted);

            return app;
        }
    }
}
