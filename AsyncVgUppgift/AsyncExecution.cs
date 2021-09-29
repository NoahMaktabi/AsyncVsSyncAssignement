using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
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
            var tasks = websites.Select(DownloadWebsiteAsync).ToList();
            var results = await Task.WhenAll(tasks);

        }

        private static async Task<WebsiteDataModel> DownloadWebsiteAsync(string websiteUrl)
        {
            var output = new WebsiteDataModel();
            var client = new HttpClient();

            output.Url = websiteUrl;
            output.Data = await client.GetStringAsync(websiteUrl);
            output.ReportWebsiteInfo();
            return output;
        }
    }
}