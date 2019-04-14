using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    public class ApiServiceClient
    {
        private readonly HttpClient _httpClient;
        public ApiServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string[]> GetValues()
        {
            var task1 = _httpClient.GetAsync("https://localhost:5001/api/tasks/1");
            var task2 = _httpClient.GetAsync("https://localhost:5001/api/tasks/2");
            var task3 = _httpClient.GetAsync("https://localhost:5001/api/tasks/3");
            var task4 = _httpClient.GetAsync("https://localhost:5001/api/tasks/4");

            var result = await Task.WhenAll(task1, task2, task3, task4);
            return await result[0].Content.ReadAsAsync<string[]>();
        }
    }
}
