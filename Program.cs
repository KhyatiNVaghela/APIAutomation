using System;

using System.Net.Http;

using System.Threading.Tasks;


using System.Collections.Generic;
using System.Text.RegularExpressions;


using Newtonsoft.Json;
using System.Text;

using System.Net.Http.Headers;

using System.IO;

namespace APIAutomation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var url = "http://webcode.me";

            //using var client = new HttpClient();

            /*
            //(1)First Example
            //C# HttpClient HEAD request

            var content = await client.GetStringAsync(url);
            Console.WriteLine(content);

            //(2)Second Example
            //C# HttpClient HEAD request

            var result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
            Console.WriteLine(result);

           
            
           //(3.)Third Example
           //C# HttpClient multiple async requests

           var urls = new string[] { "http://webcode.me", "http://example.com",
            "http://httpbin.org", "https://ifconfig.me", "http://termbin.com",
            "https://github.com"
            };

            var rx = new Regex(@"<title>\s*(.+?)\s*</title>",
            RegexOptions.Compiled);

            using var client = new HttpClient();

            var tasks = new List<Task<string>>();

            foreach (var url in urls)
            {
                tasks.Add(client.GetStringAsync(url));
            }

            Task.WaitAll(tasks.ToArray());

            var data = new List<string>();

            foreach (var task in tasks)
            {
                data.Add(await task);
            }

            foreach (var content in data)
            {
                var matches = rx.Matches(content);

                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
            }
        
        
            //(4.) Fourth Example
            //C# HttpClient POST request


            var person = new {
                Name = "John Doe", 
                Occupation = "gardener"
            };
            // var clientdata = new{
            //     clientName = "xyz",
            //     clientEmail = "xyz@example.com"
            // };

            var json = JsonConvert.SerializeObject(person);
            //var json = JsonConvert.SerializeObject(clientdata);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://httpbin.org/post";
            //var url = "https://simple-books-api.glitch.me/api-clients";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);
        
            string result = response.Content.ReadAsStringAsync().Result;
         
            Console.WriteLine(result);
        

            //record Person(string Name, string Occupation);        

        



            //(5.)Fifth Example
            //C# HttpClient JSON request

            using var client = new HttpClient();

            client.BaseAddress = new Uri("https://api.github.com");
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var url = "repos/symfony/symfony/contributors";
            HttpResponseMessage response = await client.GetAsync(url);
            
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();


            List<Contributors> contributors = JsonConvert.DeserializeObject<List<Contributors>>(resp);

            foreach (var item in contributors)
            {
                Console.WriteLine($"Login is {item.login} and contribution is {item.contributions}");
            }

            
            
            
            //(6.)Sixth Example
            //C# HttpClient download image

            using var httpClient = new HttpClient();
            var url = "http://webcode.me/favicon.ico";
            byte[] imageBytes = await httpClient.GetByteArrayAsync(url);

            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string localFilename = "favicon.ico";
            string localPath = Path.Combine(documentsPath, localFilename);

            Console.WriteLine(localPath);
            File.WriteAllBytes(localPath, imageBytes);

            */

            //(7.)Seventh Example
            //C# HttpClient Basic authentication

            var userName = "user7";
            var passwd = "passwd";
            var url = "https://httpbin.org/basic-auth/user7/passwd";

            using var client = new HttpClient();

            var authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(authToken));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            Console.WriteLine(content);

        }
    }

    public class Contributors
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
        public int contributions { get; set; }
    }

    //  public class Root
    // {
    //    public List<MyArray> MyArray { get; set; }
    //}
}

