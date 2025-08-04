using Cipher.Models;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Cipher.Services
{
    public class BrailleProcessor : MessageProcessorBase
    {
        public override string Name => "Braille";

        public override MessageResponse Process(MessageInput input)
        {
            ValidateInput(input);

            var brailleMap = new Dictionary<char, string>
            {
                ['a'] = "⠁",
                ['b'] = "⠃",
                ['c'] = "⠉",
                ['d'] = "⠙",
                ['e'] = "⠑",
                ['f'] = "⠋",
                ['g'] = "⠛",
                ['h'] = "⠓",
                ['i'] = "⠊",
                ['j'] = "⠚",
                ['k'] = "⠅",
                ['l'] = "⠇",
                ['m'] = "⠍",
                ['n'] = "⠝",
                ['o'] = "⠕",
                ['p'] = "⠏",
                ['q'] = "⠟",
                ['r'] = "⠗",
                ['s'] = "⠎",
                ['t'] = "⠞",
                ['u'] = "⠥",
                ['v'] = "⠧",
                ['w'] = "⠭",
                ['x'] = "⠽",
                ['y'] = "⠵",
                ['z'] = "⠺"
            };

            var result = new StringBuilder();

            foreach (char c in input.Input.ToLowerInvariant())
            {
                if (!Regex.IsMatch(c.ToString(), @"^[a-zA-Z\s\d\p{P}]*$"))
                {
                    throw new ArgumentException("Input contains invalid characters. Only latin characters are allowed.", nameof(input.Input));
                }

                result.Append(brailleMap.TryGetValue(c, out var brailleChar)
                    ? brailleChar
                    : c.ToString());
            }

            return new MessageResponse
            {
                Output = result.ToString()
            };
        }
    }
}
