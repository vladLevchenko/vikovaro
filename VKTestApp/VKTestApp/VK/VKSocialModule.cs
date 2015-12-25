using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infra.Data;
using Infra.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using VKTestApp.DTO;

namespace VKTestApp.VK
{
    
    public class VKSocialModule : ISocialModule
    {

       
        private string RootURL { get { return "https://api.vk.com/method/"; } }

        public VKSocialModule()
        {

        }
        public List<InfoPoint> GetInfoPointsByIds(List<int> Ids)
        {
            throw new NotImplementedException();
        }

		public List<InfoPoint> GetUserInfoPoints(NetworkUser user)
        {
           var query = new StringBuilder(RootURL);
            query.Append("groups.get?").
                Append("user_id=").
				Append(user.ID).
                Append("&access_token=").
				Append(user.Token).
                Append("&filter=groups,publics").
                Append("&extended=1");
                
            using (var client = new HttpClient())
            {
                var groupsList = new List<GroupDTO>();
                var res = new List<InfoPoint>();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

               
                var task = client.GetAsync(query.ToString())
                    .ContinueWith((taskWithResponse)=> 
                    {
                        var response = taskWithResponse.Result;
                        var jsonString = response.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        var jsonResponse = JObject.Parse(jsonString.Result);
                        var jarrayResponse = (JArray)jsonResponse["response"];
                        jarrayResponse.RemoveAt(0);
                        groupsList = JsonConvert.DeserializeObject<List<GroupDTO>>(jarrayResponse.ToString());
                    });
                task.Wait();
                foreach (var jsonGroup in groupsList)
                    res.Add(new VKPage { InfoPointID = jsonGroup.Gid, Name = jsonGroup.Name, ImageLink = jsonGroup.Photo });
                return res;
            };
          
        }

        public List<InfoPoint> SearchInfoPoints(string searchString)
        {
            throw new NotImplementedException();
        }

      
    }
}
