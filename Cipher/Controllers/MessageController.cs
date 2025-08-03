using Cipher.Models;
using Cipher.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cipher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public MessageController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost("encode/{type}")]
        public IActionResult Encode(string type, [FromBody] MessageInput input)
        {
            var processor = GetProcessor(type.ToLower(), isEncoding: true);
            if (processor == null)
                return BadRequest($"Unknown encoding type: {type}");

            var output = processor.Process(input);
            return Ok(output);
        }

        [HttpPost("decode/{type}")]
        public IActionResult Decode(string type, [FromBody] MessageInput input)
        {
            var processor = GetProcessor(type.ToLower(), isEncoding: false);
            if (processor == null)
                return BadRequest($"Unknown decoding type: {type}");

            var output = processor.Process(input);
            return Ok(output);
        }

        private MessageProcessorBase? GetProcessor(string type, bool isEncoding)
        {
            return type switch
            {
                "reverse" when isEncoding => _serviceProvider.GetService<ReversingProcessor>(),
                "reverse" when !isEncoding => _serviceProvider.GetService<ReversingProcessor>(),

                "braille" when isEncoding => _serviceProvider.GetService<BrailleProcessor>(),
                "jumble" when isEncoding => _serviceProvider.GetService<JumbleProcessor>(),

                "debraille" when !isEncoding => _serviceProvider.GetService<DebrailleProcessor>(),
                "dejumble" when !isEncoding => _serviceProvider.GetService<DejumbleProcessor>(),

                _ => null
            };
        }
    }
}
