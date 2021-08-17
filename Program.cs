using System;

using System.Net.Http;

using System.Threading.Tasks;


using System.Collections.Generic;
using System.Text.RegularExpressions;


using Newtonsoft.Json;
using System.Text;

using System.Net.Http.Headers;

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
            var content = await client.GetStringAsync(url);
            Console.WriteLine(content);

            //(2)Second Example
            var result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
            Console.WriteLine(result);

           
            
           //(3.)Third Example
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
        
        
        //(4) Fourth Example

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

        */


            //(5)Fifth Example

            using var client = new HttpClient();

            client.BaseAddress = new Uri("https://api.github.com");
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var url = "repos/symfony/symfony/contributors";
            HttpResponseMessage response = await client.GetAsync(url);
            
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();


            //var data = new StringContent(resp, Encoding.UTF8, "application/json");
           
            List<Contributors> contributors = JsonConvert.DeserializeObject<List<Contributors>>(resp);

            foreach (var item in contributors)
            {
                Console.WriteLine($"Login is {item.login} and contribution is {item.contributions}");
            }
           
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

