using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileMerge2._0
{
    public static class APIcallService
    {
        readonly static string token = "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";

        readonly static HttpClient client = new HttpClient();

        

        public static async void GetComponents(List<string> listOfComponents, string url)
        {
            
            //using (HttpClient client = new HttpClient())
            
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");//Set the User Agent to "request"

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);

                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsByteArrayAsync();
                    string str = Encoding.Default.GetString(responseBody);
                    var jSon = JsonConvert.DeserializeObject<List<Dictionary<string, Object>>>(str);
                    Console.WriteLine(response.StatusCode);
                    foreach (var item in jSon)
                    {
                        foreach (var item2 in item)
                        {
                            if(item2.Key == "url")
                            {
                                listOfComponents.Add(item2.Value.ToString());
                            }
                        };
                    }

                }
            
        }
        public static async void GetLanguages(List<Dictionary<string, Object>> jsonList, string url)
        {

            //using (HttpClient client = new HttpClient())

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");//Set the User Agent to "request"

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);

            using (HttpResponseMessage response = client.GetAsync(url).Result)
            {
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsByteArrayAsync();
                string str = Encoding.Default.GetString(responseBody);
                var jSon = JsonConvert.DeserializeObject<Dictionary<string, Object>>(str);

                jsonList.Add(jSon);

                Console.WriteLine(response.StatusCode);
                //foreach (var item in jSon)
                //{
                    
                //        if (item.Key == "content")
                //        {
                //            Console.WriteLine(item.Value);
                //        }
                    
                //}

            }

        }
    }
}
