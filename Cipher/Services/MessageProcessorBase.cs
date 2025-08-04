using Cipher.Models;

namespace Cipher.Services
{
    public abstract class MessageProcessorBase
    {
        public abstract string Name {  get; }
        public abstract MessageResponse Process(MessageInput input);

        protected void ValidateInput(MessageInput input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (string.IsNullOrWhiteSpace(input.Input))
                throw new ArgumentException("Input cannot be empty.", nameof(input.Input));
        }
    }
}
