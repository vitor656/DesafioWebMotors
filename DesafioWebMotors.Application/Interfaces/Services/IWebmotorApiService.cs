using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioWebMotors.Application.Models.DTO;

namespace DesafioWebMotors.Application.Interfaces.Services
{
    public interface IWebmotorApiService
    {
        Task<List<Make>> GetMakes();
        Task<List<Model>> GetModels(int make);
        Task<List<Version>> GetVersions(int model);
        Task<List<Vehicle>> GetVechicles(int page);

    }
}