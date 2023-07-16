using Newtonsoft.Json;
using System.Net.Http;
using UserApp.AppCore.DTOs.UserDTO;

namespace UserApp.UI.ApiProvider
{
    public class UserProvider
    {
        HttpClient _httpClient;

        public UserProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<UserDTO>?> AllUsers()
        {
            List<UserDTO>? list = null;
            var responseMessage = await _httpClient.GetAsync($"User/UserList");
            if (responseMessage.IsSuccessStatusCode)
            {
                list = JsonConvert.DeserializeObject<List<UserDTO>>(await responseMessage.Content.ReadAsStringAsync());
            }

            return list;
        }
    }
}
