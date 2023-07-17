using Newtonsoft.Json;
using System.Text;

namespace UserApp.UI.ApiProvider.Bases
{
    public class ProviderBase<T> where T : class
    {
        HttpClient _httpClient;

        public ProviderBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <summary>
        /// provider metotlarin get async serialize islemini yapan base metot
        /// </summary>
        /// <param name="uriPath"></param>
        /// <returns></returns>
        public async Task<T> ProviderBaseGetAsync(string uriPath)
        {
            T test = null;
            var responseMessage = await _httpClient.GetAsync(uriPath);
            if (responseMessage.IsSuccessStatusCode)
            {
                test = JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());
            }
            return test;
        }

        public async Task<List<T>> ProviderBaseListGetAsync(string uriPath)
        {
            List<T> test = null;
            var responseMessage = await _httpClient.GetAsync(uriPath);
            if (responseMessage.IsSuccessStatusCode)
            {
                test = JsonConvert.DeserializeObject<List<T>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return test;
        }

        public async Task<T> ProviderBasePostAsync<T>(string uriPath, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uriPath, content);

            if (response.IsSuccessStatusCode)
            {
                var resultJson = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(resultJson);
                return result;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("API yanıtı hata mesajı: " + errorMessage);
            }
                return default(T);
        }

    }
}
