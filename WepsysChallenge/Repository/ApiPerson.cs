using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using WepsysChallenge.Api;

namespace WepsysChallenge.Models
{
    public class ApiPerson : ApiBase
    {
        public override HttpResponseMessage requestApiPost(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(url + "Person", data).GetAwaiter().GetResult();
            return response;
        }

        public override string requestApiGet()
        {
            return new WebClient() { Encoding = Encoding.UTF8 }.DownloadString(url + "Person");
        }

        public override string requestApiDelete(int id)
        {
            var response = client.DeleteAsync(url + "Person/" + id).GetAwaiter().GetResult();
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
    }
}
