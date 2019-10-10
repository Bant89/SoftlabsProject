using Project.Models;
using Refit;
using System.Threading.Tasks;

namespace Project.Services
{
    [Headers("Content-Type: application/json")]
    public interface IAPIService
    {
        Task<VideoResponse> GetTrendingVideos();


    }
}
