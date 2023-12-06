
using Microsoft.Extensions.Options;
using OpenAI_API.Models;
using OpenAITest.Configurations;
using OpenAI_API.Completions;

namespace OpenAITest.Services
{
    public class OpenAiService : IOpenAiService
    {
        private readonly OpenAIConfig _openAiConfig;

        public OpenAiService(
            IOptionsMonitor<OpenAIConfig> optionsMonitor
            ) 
        {
            _openAiConfig = optionsMonitor.CurrentValue;
        }

        public async Task<string> CheckProgrammingLanguage(string language)
        {
            var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);

            var chat = api.Chat.CreateConversation();

            chat.AppendSystemMessage("You are a teacher who helps new programmers understand whether something is a programming language or not. If the user tells you a programming language, respond with yes. If a user tells you something that isnt a programming language, respond with no. You will only respond with yes or no. You do not say anything else");

            chat.AppendUserInput(language);

            var response = await chat.GetResponseFromChatbotAsync();

            return response;
        }

        public async Task<string> CompleteSentence(string text)
        {
            //api instance
            var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);
            var result = await api.Completions.GetCompletion(text);
            return result;
        }

        public async Task<string> CompleteSentenceAdvanced(string text)
        {
            var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);

            var result = await api.Completions.CreateCompletionAsync(
                new CompletionRequest(text, model: Model.CurieText, temperature: 0.1));

           return result.Completions[0].Text;
        }
    }
}
