using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTask
{
    public interface IRandomWordApiService
    {
        Task<string> GetRandomWordAsync(int numOfRetries = 0);
        Task<string[]> GetRandomWordsAsync(int numberOfWords);
    }
}
