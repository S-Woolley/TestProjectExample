using System.Configuration;
using RestSharp;
using System.Net;

namespace ProductApi
{
    public class Client
    {
        private RestClient WebClient;
        public Profile.Profile Profile { get; private set; } 
        
        public CookieCollection Cookies
        {
            get
            {
                return WebClient.CookieContainer.GetCookies(WebClient.BaseUrl);
            }
        }               

        public Client()
        {
            WebClient = new RestClient(ConfigurationManager.AppSettings["SiteUrl"]);
            WebClient.CookieContainer = new System.Net.CookieContainer();
            WebClient.UserAgent = "ProductAPI";
            Profile = new Profile.Profile(WebClient);
        }

        public IRestResponse SignIn(object userName, object password)
        {
            RestRequest request = new RestRequest("1/login", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("X-Requested-With", " XMLHttpRequest");
            request.JsonSerializer.ContentType = "application/json; charset=utf-8";
            request.AddBody(new { username = userName, password = password, });
            return WebClient.Execute(request);          
        }       
    }
}
