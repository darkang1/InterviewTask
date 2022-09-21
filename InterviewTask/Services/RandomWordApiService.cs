using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace InterviewTask
{
    public class RandomWordApiService : IRandomWordApiService
    {
        private readonly HttpClient _httpClient;
        public RandomWordApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetRandomWordAsync(int numOfRetries = 0)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<WordResult[]>($"word");
                return response[0].Word;
            }
            catch
            {
                if (numOfRetries >= GlobalConstants.MaxRequestRetries)
                    throw;
                await Task.Delay(1000);
                return await GetRandomWordAsync(numOfRetries+1);
            }
        }

        public async Task<string[]> GetRandomWordsAsync(int numberOfWords)
        {
            List<Task<string>> tasks = new List<Task<string>>();
            for (int i = 0; i < numberOfWords; i++)
            {
                var task = GetRandomWordAsync();
                tasks.Add(task);
            }
            var parsedWords = await Task.WhenAll(tasks);
            var finalWords = parsedWords.Distinct().ToArray();

            while(finalWords.Length < numberOfWords)
            {
                finalWords = finalWords.Union(await GetRandomWordsAsync(numberOfWords - finalWords.Length)).ToArray();
            }
            return finalWords;
        }
    }
}
