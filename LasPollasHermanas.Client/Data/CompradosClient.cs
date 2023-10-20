namespace LasPollasHermanas.Client.Data;
using LasPollasHermanas.Client.Models;
using System.Net.Http.Json;
public class CompradosClient
{
    private readonly HttpClient httpClient;

    public CompradosClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }


    public async Task AddDildoCompradoAsync(Comprado dildoComprado)
    {
        await httpClient.PostAsJsonAsync("comprados", dildoComprado);
    }

    public async Task<Comprado[]?> GetDildosCompradosAsync(int id)
    {
        return await httpClient.GetFromJsonAsync<Comprado[]>($"/comprados/{id}") ??
        throw new Exception("Could not find dildos");
    }

}