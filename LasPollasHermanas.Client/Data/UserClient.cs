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

  public async Task<Users> GetUserEmail(string email)
  {
    return await httpClient.GetFromJsonAsync<Users>($"Users/byEmail/{email}") ??
        throw new Exception("Couldn't get user by email");
  }


  public async Task AddUserAsync(Users User)
  {
    await httpClient.PostAsJsonAsync("Users", User);
  }

  public async Task<Users> GetUserAsync(int id)
  {
    return await httpClient.GetFromJsonAsync<Users>($"Users/{id}") ??
    throw new Exception("Could not find User");
  }

  public async Task UpdateUserAsync(Users updatedUser)
  {
    await httpClient.PutAsJsonAsync($"Users/{updatedUser.Id}", updatedUser);
  }

  public async Task DeleteUserAsync(int id)
  {
    await httpClient.DeleteAsync($"Users/{id}");
  }
}