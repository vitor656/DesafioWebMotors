using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioWebMotors.Application.Interfaces.Infra;
using DesafioWebMotors.Application.Interfaces.Services;
using DesafioWebMotors.Application.Models.DTO;

namespace DesafioWebMotors.Application.Services
{
    public class WebmotorApiService : IWebmotorApiService
    {
        private readonly IWebMotorClient _client;

        public WebmotorApiService(IWebMotorClient client)
        {
            _client = client;
        }
        public Task<List<Make>> GetMakes()
        {
            return _client.GetMakesAsync();
        }

        public Task<List<Model>> GetModels(int make)
        {
            return _client.GetModelAsync(make);
        }

        public Task<List<Vehicle>> GetVechicles(int page)
        {
            return _client.GetVehicleAsync(page);
        }

        public Task<List<Version>> GetVersions(int model)
        {
            return _client.GetVersionAsync(model);
        }
    }
}