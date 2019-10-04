using Project.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    [Headers("Content-Type: application/json")]
    public interface IYoutubeApi
    {
        [Get("/commentThreads?part=snippet&videoId={videoId}&fields=items%2Fsnippet%2FtopLevelComment&key=AIzaSyCO4bqpLYO0u_vfKOMpvlUgHEHb1Z6GCzs")]
        Task<HttpResponseMessage> GetGomments(string videoId);
    }
}
