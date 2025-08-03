using Cipher.Models;
using System.Text;

namespace Cipher.Services
{
    public class DebrailleProcessor : MessageProcessorBase
    {
        public override string Name => "Debraille";

        public override MessageResponse Process(MessageInput input)
        {
            var debrailleMap = new Dictionary<string, char>
            {
                ["⠁"] = 'a',
                ["⠃"] = 'b',
                ["⠉"] = 'c',
                ["⠙"] = 'd',
                ["⠑"] = 'e',
                ["⠋"] = 'f',
                ["⠛"] = 'g',
                ["⠓"] = 'h',
                ["⠊"] = 'i',
                ["⠚"] = 'j',
                ["⠅"] = 'k',
                ["⠇"] = 'l',
                ["⠍"] = 'm',
                ["⠝"] = 'n',
                ["⠕"] = 'o',
                ["⠏"] = 'p',
                ["⠟"] = 'q',
                ["⠗"] = 'r',
                ["⠎"] = 's',
                ["⠞"] = 't',
                ["⠥"] = 'u',
                ["⠧"] = 'v',
                ["⠭"] = 'w',
                ["⠽"] = 'x',
                ["⠵"] = 'y',
                ["⠺"] = 'z'
            };


            var result = new StringBuilder();
            char[] inputInChar = input.Input.ToCharArray();

            foreach (char brailleChar in inputInChar)
            {
                result.Append(debrailleMap.TryGetValue(brailleChar.ToString(), out var regularChar)
                    ? regularChar
                    : brailleChar);
            }

            return new MessageResponse
            {
                Output = result.ToString()
            };
        }
    }
}
