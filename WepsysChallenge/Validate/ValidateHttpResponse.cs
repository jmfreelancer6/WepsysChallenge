using Newtonsoft.Json;
using System.Net.Http;

namespace WepsysChallenge.Models
{
    public class ValidateHttpResponse
    {
        public (Error, Response) ValidateResponse(HttpResponseMessage respon)
        {
            if (respon.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return (JsonConvert.DeserializeObject<Error>(respon.Content.ReadAsStringAsync().GetAwaiter().GetResult()), null);
            }
            return (null, JsonConvert.DeserializeObject<Response>(respon.Content.ReadAsStringAsync().GetAwaiter().GetResult()));
        }
    }
}
