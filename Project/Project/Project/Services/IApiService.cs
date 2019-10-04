using Fusillade;
using Project.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public interface IApiService<T>
    {

        T GetApi(Priority priority);

    }
}
