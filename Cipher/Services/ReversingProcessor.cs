using Cipher.Models;

namespace Cipher.Services
{
    public class ReversingProcessor : MessageProcessorBase
    {
        public override string Name => "Reverse";

        public override MessageResponse Process(MessageInput input)
        {
            var reversed = new string(input.Input.Reverse().ToArray());
            return new MessageResponse
            {
                Output = reversed
            };
        }
    }
}
