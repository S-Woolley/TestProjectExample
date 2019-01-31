using RestSharp;
using System.Threading.Tasks;

namespace ProductApi
{
    public class ReuestBase
    {
        private RestClient client;

        public ReuestBase(RestClient client)
        {
            this.client = client;
        }

        protected IRestResponse<T> Execute<T>(RestRequest request) where T : new()
        {            
            IRestResponse<T> response = client.Execute<T>(request);
            return response;
        }

        protected IRestResponse Execute(RestRequest request)
        {
            IRestResponse response = client.Execute(request);
            return response;
        }

        protected Task<IRestResponse<T>> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            var tcs = new TaskCompletionSource<IRestResponse<T>>();
            RestRequestAsyncHandle han = client.ExecuteAsync<T>(request, response =>
            {
                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    tcs.TrySetResult(response);
                }
                else
                {
                    tcs.TrySetException(response.ErrorException);
                }
            });
            return tcs.Task;
        }
    }
}
