using Microsoft.AspNetCore.Mvc;
using OpenAITest.Services;

namespace OpenAITest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenAiConroller : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IOpenAiService _openAiService;

        public OpenAiConroller(ILogger<WeatherForecastController> logger, IOpenAiService openAiService)
        {
            _logger = logger;
            _openAiService = openAiService;
        }


        [HttpPost]
        [Route("CompleteSentence")]
        public async Task<IActionResult> CompleteSentence(string text)
        {
            var result = await _openAiService.CompleteSentenceAdvanced(text);
            return Ok(result);
        }

        [HttpPost]
        [Route("AskQuestion")]
        public async Task<IActionResult> AskQuestion(string text)
        {
            var result = await _openAiService.CheckProgrammingLanguage(text);
            return Ok(result);
        }
    }
}
