using Newtonsoft.Json;
using System.Net.Http;
using UserApp.AppCore.DTOs.UserDTO;
using UserApp.AppCore.Results.Bases;
using UserApp.UI.ApiProvider.Bases;

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
        public async Task<Result> AddUser(AddUserDTO user)
        {
            ProviderBase<AddUserDTO> addedUser = new ProviderBase<AddUserDTO>(_httpClient);

            return await addedUser.ProviderBasePostAsync<Result>($"User/AddUser", user);

        }

        public async Task<UserDTO?> GetUser(int id)
        {
            ProviderBase<UserDTO> user = new ProviderBase<UserDTO>(_httpClient);

            return await user.ProviderBaseGetAsync($"User/GetUser/{id}");
        }
    }
}
