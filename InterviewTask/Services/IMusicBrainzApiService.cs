using System.Threading.Tasks;

namespace InterviewTask
{
    public interface IMusicBrainzApiService
    {
        Task<Song> GetSongByWordAsync(string word, int numOfRetries = 0);
        Task<Song[]> GetSongsByWordsAsync(string[] wordArray);
    }
}
