using System.Threading.Tasks;
using Project.Models;
using Refit;

namespace Project.Services
{
    public interface IYoutubeAPI
    {

        [Get("/videos?part=id,statistics,contentDetails,snippet,player&key={apiKey}&chart=mostPopular&videoCategoryId={categoryId}")]
        Task<VideoResponse> GetTrendingVideos(string categoryId, string apiKey);
    }
}
