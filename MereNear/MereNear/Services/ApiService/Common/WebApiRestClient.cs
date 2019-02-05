using Acr.UserDialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MereNear.Services.ApiService.Common
{
    public class WebApiRestClient : IWebApiRestClient
    {
        private readonly JsonSerializerSettings _jsonSettings;
        Uri baseUri = new Uri("http://peertechnologies.in/Mnear/Merenear/");
        public WebApiRestClient()
        {
            _jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include
            };

        }

        HttpClient client = new HttpClient();

        public async Task<TResponse> GetAsync<TResponse>(string action)
        {            
            Uri uri = new Uri(baseUri, action);
            try
            {
                //UserDialogs.Instance.ShowLoading("Loading Data...");
                var response = await client.GetStringAsync(uri);
                UserDialogs.Instance.HideLoading();
                return JsonConvert.DeserializeObject<TResponse>(response);
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                Debug.WriteLine("Error in GetApi:-",ex.Message);
                UserDialogs.Instance.Alert("Error in GetApi:" + ex.Message);
                return JsonConvert.DeserializeObject<TResponse>(null);
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string action, TRequest request)
        {
            Uri uri = new Uri(baseUri, action);
            var json = JsonConvert.SerializeObject(request, _jsonSettings);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(uri, content).ConfigureAwait(false);

                return await HandleResponse<TResponse>(response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in GetApi:-", ex.Message);
                UserDialogs.Instance.Alert("Error in PostApi:" + ex.Message);
                return await HandleResponse<TResponse>(null);
            }
        }

        private async Task<TResponse> HandleResponse<TResponse>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception(content);
                }

                throw new HttpRequestException(content);
            }
            else
            {
                string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var result = JsonConvert.DeserializeObject<TResponse>(responseData);
                return result;
            }
        }
    }
}
