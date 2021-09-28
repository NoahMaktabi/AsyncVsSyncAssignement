using System.Collections.Generic;

namespace AsyncVgUppgift
{
    public static class WebsiteList
    {
        public static List<string> GetWebsiteList()
        {
            var output = new List<string>
            {
                "https://www.yahoo.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.youtube.com",
                "https://www.facebook.com",
                "https://www.skatteverket.se",
                "https://www.cdon.com",
                "https://www.migrationsverket.se",
                "https://www.regeringen.se/",
                "https://www.aftonbladet.se",
            };
            return output;
        }
    }
}