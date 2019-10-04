using System;
using System.Collections.Generic;
using System.Text;
using Polly;
using Refit;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Plugin.Connectivity;
using System.Threading;
using System.Linq;

namespace Project.Services
{
    public class ApiManager : IApiManager
    {

        IUserDialogs _userDialogs = UserDialogs.Instance;
        IConnectivity _connectivity = CrossConnectivity.Current;
        IApiService<IYoutubeApi> youtubeApi;
        public bool IsConnected { get; set; }
        public bool IsReachable { get; set; }
        Dictionary<int, CancellationTokenSource> runningTasks = new Dictionary<int, CancellationTokenSource>();
        Dictionary<string, Task<HttpResponseMessage>> taskContainer = new Dictionary<string, Task<HttpResponseMessage>>();

        public ApiManager(IApiService<IYoutubeApi> _youtubeAPI) {
            youtubeApi = _youtubeAPI;
            IsConnected = _connectivity.IsConnected;
            _connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsConnected = e.IsConnected;

            if(!e.IsConnected)
            {
                var items = runningTasks.ToList();
                foreach(var item in items)
                {
                    item.Value.Cancel();
                    runningTasks.Remove(item.Key);
                }
            }
        }

        public async Task<HttpResponseMessage> GetComments(string videoId = "2j3x0VYnehg")
        {

            System.Diagnostics.Debug.WriteLine("CORRIENDO EN GET COMMENTS");
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync(youtubeApi.GetApi(Fusillade.Priority.UserInitiated).GetGomments(videoId));
            runningTasks.Add(task.Id, cts);

            return await task;
        }


        protected async Task<TData> RemoteRequestAsync<TData>(Task<TData> task)
            where TData: HttpResponseMessage,
            new()
        {
            TData data = new TData();

            if (!IsConnected)
            {
                var stringResponse = "There's not a network connection";
                data.StatusCode = HttpStatusCode.BadRequest;
                data.Content = new StringContent(stringResponse);

                _userDialogs.Toast(stringResponse, TimeSpan.FromSeconds(1));
                return data;
            }

            IsReachable = await _connectivity.IsRemoteReachable(Config.ApiHostName);

            if(!IsReachable)
            {
                var stringResponse = "There's not an internet connection";
                data.StatusCode = HttpStatusCode.BadRequest;
                data.Content = new StringContent(stringResponse);

                _userDialogs.Toast(stringResponse, TimeSpan.FromSeconds(1));
                return data;
            }

            data = await Policy
                .Handle<WebException>()
                .Or<ApiException>()
                .Or<TaskCanceledException>()
                .WaitAndRetryAsync
                (
                    retryCount: 1,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                ).ExecuteAsync(async () =>
                {
                    var result = await task;

                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {

                    }
                    runningTasks.Remove(task.Id);

                    return result;
                });

                return data;
        }
 
    }
}
