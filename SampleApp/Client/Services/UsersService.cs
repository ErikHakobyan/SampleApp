using Newtonsoft.Json;
using SampleApp.Client.Models;
using System.Net.Http.Json;
using System.Text;

namespace SampleApp.Client.Services;

public class UsersService
{
    HttpClient _client;
    public UsersService(HttpClient client)
    {
        _client = client;
    }

    public async Task<User> GetUserById(int Id)
    {
        return await _client.GetFromJsonAsync<User>($"api/Users/{Id}");
    }
    public async Task<PaginatedList<User>> GetUsers(int pageNumber =1, int pageSize=10)
    {
        return await _client.GetFromJsonAsync<PaginatedList<User>>($"api/Users?PageNumber={pageNumber}&PageSize={pageSize}");
    }
    public async Task<int> CreateUser(AddUserForm user)
    {
        int id = -1;

        using (var response = await _client.PostAsJsonAsync("api/Users", user))
        {
            if (response.IsSuccessStatusCode)
            {
                Int32.TryParse(await response.Content.ReadAsStringAsync(), out id);
            }
        }

        return id;
    }

    public async Task UpdateUser(int Id, UpdateUserForm user)
    {
        await _client.PutAsJsonAsync($"api/Users/{Id}", user);
    }
    public async Task DeleteUser(int Id)
    {
        await _client.DeleteAsync($"api/Users/{Id}");
    }
}

