using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncVgUppgift
{
    public class AsyncExecution
    {
        public static async Task Start()
        {
            var watch = Stopwatch.StartNew();
            await RunDownloadAsync();
            watch.Stop();
            
            var elapsedMs = (double)watch.ElapsedMilliseconds / 1000;
            $"Total execution time: {elapsedMs:N2} seconds".ShowAnimatedText(30);
        }
        private static async Task RunDownloadAsync()
        {
            var websites = WebsiteList.GetWebsiteList();
            foreach (var website in websites)
            {
                var result = await DownloadWebsiteAsync(website);
                result.ReportWebsiteInfo();
            }

        }

        private static async Task<WebsiteDataModel> DownloadWebsiteAsync(string websiteUrl)
        {
            var output = new WebsiteDataModel();
            var client = new HttpClient();

            output.Url = websiteUrl;
            output.Data = await client.GetStringAsync(websiteUrl);
            return output;
        }
    }
}