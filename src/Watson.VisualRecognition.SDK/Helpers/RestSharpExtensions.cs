using System.Threading.Tasks;
using RestSharp;

namespace Watson.VisualRecognition.SDK.Helpers
{
    internal static class RestSharpExtensions
    {

        public static IRestResponse ExecuteSync(this RestClient client, RestRequest request)
        {
            return Task.Run(() =>
            {
                var t = new TaskCompletionSource<IRestResponse>();
                client.ExecuteAsync(request, s => t.TrySetResult(s));
                return t.Task;
            }).Result;
        }
    }
}
