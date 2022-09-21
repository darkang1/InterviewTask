using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace InterviewTask
{
    public class MusicBrainzApiService : IMusicBrainzApiService
    {
        private readonly HttpClient _httpClient;
        public MusicBrainzApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Song> GetSongByWordAsync(string word, int numOfRetries=0)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<SongResult>($"recording?query=name:{word}&limit=1");
                return JSONDataConverter.SongResultToSong(response, word);
            }
            catch{
                if (numOfRetries >= GlobalConstants.MaxRequestRetries)
                    throw;
                await Task.Delay(1000);
                return await GetSongByWordAsync(word, numOfRetries+1);
            }
        }

        public async Task<Song[]> GetSongsByWordsAsync(string[] wordArray)
        {
            List<Task<Song>> tasks = new List<Task<Song>>();
            for (int i = 0; i < wordArray.Length; i++)
            {
                var task = GetSongByWordAsync(wordArray[i]);
                tasks.Add(task);
            }
            var finalSongs = await Task.WhenAll(tasks);
            return finalSongs;
        }
    }
}
