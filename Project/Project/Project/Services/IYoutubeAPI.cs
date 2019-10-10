using System.Threading.Tasks;
using Project.Models;
using Refit;

namespace Project.Services
{
    public interface IYoutubeAPI
    {

        [Get("/videos?part=id,statistics,contentDetails,snippet&key=AIzaSyCO4bqpLYO0u_vfKOMpvlUgHEHb1Z6GCzs&chart=mostPopular")]
        Task<VideoResponse> GetTrendingVideos();
    }
}
