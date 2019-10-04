using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public interface IApiManager
    {
        Task<HttpResponseMessage> GetComments(string videoId);
    }
}
