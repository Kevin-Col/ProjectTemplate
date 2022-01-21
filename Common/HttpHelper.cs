using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class HttpHelper
    {
        public static async Task<string> Get(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var strjson = await response.Content.ReadAsStringAsync();
            return strjson;
        }
        public static async Task<T> Get<T>(string url)
        {
            var json = await Get(url);
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

    }
}
