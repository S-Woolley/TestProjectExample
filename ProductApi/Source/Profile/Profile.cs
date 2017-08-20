using RestSharp;
using System.Threading.Tasks;

namespace ProductApi.Profile
{
    public class Profile:ReuestBase
    {
        public Profile(RestClient client) : base(client) { }

        private RestRequest CreateEditCommand(object userId, object payload)
        {
            RestRequest request = new RestRequest("1/users/{userId}/profile", Method.PUT);
            request.AddParameter("userId", userId, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer.ContentType = "application/json;";
            request.AddBody(payload);
            return request;
        }
        
        public IRestResponse<EditNameResponse> Edit(object userId,object payload)
        {
            return Execute<EditNameResponse>(CreateEditCommand(userId,payload));
        }

        public Task<IRestResponse<EditNameResponse>> EditAsync(object userId, object payload)
        {
            return ExecuteAsync<EditNameResponse>(CreateEditCommand(userId, payload));
        }

        public IRestResponse<EditNameResponse> EditName(string userId, string firstName, string surname)
        {
            return Edit(userId, new { firstName = firstName, surname = surname });
        }

        public IRestResponse<GetUserResponse> GetUser(object email)
        {
            RestRequest request = new RestRequest("1/users", Method.GET);
            request.AddParameter("email", email, ParameterType.QueryString);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer.ContentType = "application/json;";
            return Execute<GetUserResponse>(request);
        }
    }
}
