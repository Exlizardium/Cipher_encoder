using Cipher.Models;
using System.Text;

namespace Cipher.Services
{
    public class JumbleProcessor : MessageProcessorBase
    {
        public override string Name => "Jumble";

        public override MessageResponse Process(MessageInput input)
        {
            ValidateInput(input);

            StringBuilder binaryOutput = new StringBuilder();

            foreach (char c in input.Input.ToCharArray())
            {
                string binary = Convert.ToString(c, 2).PadLeft(8, '0');
                binaryOutput.Append(binary + " ");
            }

            return new MessageResponse
            {
                Output = binaryOutput.ToString()
            };
        }
    }
}
