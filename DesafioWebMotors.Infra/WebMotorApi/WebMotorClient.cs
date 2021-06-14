using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioWebMotors.Application.Interfaces.Infra;
using DesafioWebMotors.Application.Models.DTO;
using RestSharp;

namespace DesafioWebMotors.Infra.WebMotorApi
{
    public class WebMotorClient : IWebMotorClient
    {
        private readonly RestClient _client;

        public WebMotorClient()
        {
            _client = new RestClient("https://desafioonline.webmotors.com.br/api/OnlineChallenge");
        }

        public async Task<List<Make>> GetMakesAsync()
        {
            var request = new RestRequest("Make", Method.GET);
            var result = await _client.GetAsync<List<Make>>(request);
            return result;
        }
        public async Task<List<Model>> GetModelAsync(int make)
        {
            var request = new RestRequest("Model", Method.GET);
            request.AddParameter("MakeID", make);
            var result = await _client.GetAsync<List<Model>>(request);
            return result;
        }
        public async Task<List<Version>> GetVersionAsync(int model)
        {
            var request = new RestRequest("Version", Method.GET);
            request.AddParameter("ModelID", model);
            var result = await _client.GetAsync<List<Version>>(request);
            return result;
        }
        public async Task<List<Vehicle>> GetVehicleAsync(int page)
        {
            var request = new RestRequest("Vehicles", Method.GET);
            request.AddParameter("Page", page);
            var result = await _client.GetAsync<List<Vehicle>>(request);
            return result;
        }
    }
}