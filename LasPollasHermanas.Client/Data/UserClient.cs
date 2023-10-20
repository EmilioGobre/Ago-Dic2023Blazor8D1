namespace LasPollasHermanas.Client.Data;
using LasPollasHermanas.Client.Models;
using System.Net.Http.Json;
public class UserClient
{
    private readonly HttpClient httpClient;

    public UserClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<Users[]?> GetUsersAsync()
    {
        return await httpClient.GetFromJsonAsync<Users[]>("Users");
    }

    public async Task<Users> GetUserEmail(int id)
    {
        return await httpClient.GetFromJsonAsync<Users>($"Users/ByEmail/{id}/email") ??
        throw new Exception("Couldn't get user email");
    }

    public async Task AddUserAsync(Users User)
    {
        await httpClient.PostAsJsonAsync("Users", User);
    }

    public async Task<Users> GetUserAsync(int id)
    {
        return await httpClient.GetFromJsonAsync<Users>($"Users/ById/{id}") ??
        throw new Exception("Could not find User");
    }

    public async Task UpdateUserAsync(Users updatedUser)
    {
        await httpClient.PutAsJsonAsync($"Users/{updatedUser.idUser}", updatedUser);
    }

    public async Task DeleteUserAsync(int id)
    {
        await httpClient.DeleteAsync($"Users/{id}");
    }
}