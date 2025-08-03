using Cipher.Models;

namespace Cipher.Services
{
    public abstract class MessageProcessorBase
    {
        public abstract string Name {  get; }
        public abstract MessageResponse Process(MessageInput input);
    }
}
