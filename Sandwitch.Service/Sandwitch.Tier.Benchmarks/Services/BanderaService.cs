using BenchmarkDotNet.Attributes;

using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Views;

using System.Net.Http.Json;
using System.Text.Json;

namespace Sandwitch.Tier.Benchmarks.Services
{
    public class BanderaService
    {
        static readonly HttpClient Client = new() { BaseAddress = new Uri("https://localhost:7214/api/bandera/") };

        [Benchmark]
        public async Task<IList<ViewBandera>> FindAllBandera()
        {
            HttpResponseMessage @response = await Client.GetAsync("findallbandera");
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @stars = JsonSerializer.Deserialize<List<ViewBandera>>(@responseBody);

            return @stars;

        }

        [Benchmark]
        public async Task<ViewPage<ViewBandera>> FindPaginatedTrackingNo()
        {
            var @content = JsonContent.Create(new FilterPage { Index = 0, Size = 20 });

            HttpResponseMessage @response = await Client.PostAsync("findpaginatedbandera", @content);
            @response.EnsureSuccessStatusCode();
            string @responseBody = await @response.Content.ReadAsStringAsync();
            var @star = JsonSerializer.Deserialize<ViewPage<ViewBandera>>(@responseBody);

            return @star;
        }

    }
}
