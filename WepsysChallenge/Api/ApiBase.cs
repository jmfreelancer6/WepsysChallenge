using System.Net;
using System.Net.Http;

namespace WepsysChallenge.Api
{
    public abstract class ApiBase
    {
        protected static readonly HttpClient client = new HttpClient();
        protected const string url = "https://localhost:44351/api/";
        public abstract string requestApiGet();
        public abstract HttpResponseMessage requestApiPost(object obj);

        public abstract string requestApiDelete(int id);
    }
}
