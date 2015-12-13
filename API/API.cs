using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Infra.Interfaces;

namespace API
{
    public class API : IWebRequestsModule
    {
        public Task<HttpResponseMessage> GetAsync(string requestUrl)
        {
            using (var client = new HttpClient())
                return client.GetAsync(requestUrl);
        }

        public Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            using (var client = new HttpClient())            
                return client.PostAsync(url, content);
            
        }
    }
}
