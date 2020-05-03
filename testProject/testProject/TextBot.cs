using Microsoft.Extensions.Options;

namespace testProject
{
    public class TextBot : BotBase
    {
        public TextBot(IOptions<BotOptions<TextBot>> options)
            : base(options.Value)
        {
        }
    }
}
