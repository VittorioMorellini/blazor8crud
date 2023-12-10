using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Crud.shared.Entity;
using static System.Net.WebRequestMethods;

namespace Crud.shared.Services
{
    public class ClientGameService: IGameService
    {
        private readonly HttpClient _httpClient;

        public ClientGameService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Game> Add(Game game)
        {
            var result = await _httpClient.PostAsJsonAsync<Game>("/api/game", game);

            return await result.Content.ReadFromJsonAsync<Game>();
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"/api/game/{id}");
            return true;
        }

        public async Task<Game> Edit(int id, Game game)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/game/{id}", game);
            return await result.Content.ReadFromJsonAsync<Game>();
        }

        public Task<List<Game>> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public async Task<Game> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Game>($"/api/game/{id}");
            return result;
        }

    }
}
