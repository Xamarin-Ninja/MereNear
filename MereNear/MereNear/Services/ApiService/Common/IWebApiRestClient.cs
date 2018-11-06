using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MereNear.Services.ApiService.Common
{
    public interface IWebApiRestClient
    {
        Task<TResponse> GetAsync<TResponse>(string uri);
        Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest data);
    }
}
