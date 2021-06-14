using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioWebMotors.Application.Models.DTO;

namespace DesafioWebMotors.Application.Interfaces.Infra
{
    public interface IWebMotorClient
    {
        Task<List<Make>> GetMakesAsync();
        Task<List<Model>> GetModelAsync(int make);
        Task<List<Version>> GetVersionAsync(int model);
        Task<List<Vehicle>> GetVehicleAsync(int page);
    }
}