using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataRequestHelperLibrary
{
    public class DataRequestHelper
    {
        private readonly HttpClient _client;

        private Uri _baseAddress;

        public DataRequestHelper(string baseAddress)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }
        public async Task<T> PostJsonDataAsync<T>(string url, object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(url, content);
            return await HandleResponse<T>(response);
        }

        public async Task<T> PutJsonDataAsync<T>(string url, object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync(url, content);
            return await HandleResponse<T>(response);
        }
        public async Task<T> DeleteJsonDataAsync<T>(string url)
        {
            HttpResponseMessage response = await _client.DeleteAsync(url);
            return await HandleResponse<T>(response);
        }

        public async Task<T> GetJsonDataAsync<T>(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            return await HandleResponse<T>(response);
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseBody);
            }
            else
            {
                throw new Exception($"Lỗi khi gửi yêu cầu: {response.StatusCode}");
            }
        }
    }
}
