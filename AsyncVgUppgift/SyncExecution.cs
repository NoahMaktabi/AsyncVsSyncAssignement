using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;

namespace AsyncVgUppgift
{
    public class SyncExecution
    {
        public static void Start()
        {
            var watch = Stopwatch.StartNew();
            RunDownloadSync();
            watch.Stop();

            var elapsedMs = (double)watch.ElapsedMilliseconds / 1000;
            $"Total execution time: {elapsedMs:N2} seconds".ShowAnimatedText(30);
        }

        private static void RunDownloadSync()
        {
            var websites = WebsiteList.GetWebsiteList();

            foreach (var url in websites)
            {
                DownloadWebsite(url);
            }
        }

        private static WebsiteDataModel DownloadWebsite(string websiteUrl)
        {
            var output = new WebsiteDataModel();
            var client = new WebClient();
            
            output.Url = websiteUrl;
            output.Data = client.DownloadString(websiteUrl);
            output.ReportWebsiteInfo();
            return output;
        }

    }
}