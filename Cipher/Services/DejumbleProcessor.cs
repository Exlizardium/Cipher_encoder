using Cipher.Models;
using System.Text;

namespace Cipher.Services
{
    public class DejumbleProcessor : MessageProcessorBase
    {
        public override string Name => "Dejumble";

        public override MessageResponse Process(MessageInput input)
        {
            ValidateInput(input);

            var decodedMessage = new StringBuilder();
            string cleanedInput = input.Input.Trim();
            string[] binaryParts = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string binary in binaryParts)
            {
                try
                {
                    char character = (char)Convert.ToInt32(binary, 2);
                    decodedMessage.Append(character);
                }
                catch (Exception ex)
                {
                    Console.Write("Jumble wasn't converted to a string.");
                }
            }

            return new MessageResponse
            {
                Output = decodedMessage.ToString()
            };
        }
    }
}
