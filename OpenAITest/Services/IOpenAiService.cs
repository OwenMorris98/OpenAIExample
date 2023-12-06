namespace OpenAITest.Services
{
    public interface IOpenAiService
    {
        Task<string> CompleteSentence(string text);

        Task<string> CompleteSentenceAdvanced(string text);

        Task<string> CheckProgrammingLanguage(string language);

    }
}
