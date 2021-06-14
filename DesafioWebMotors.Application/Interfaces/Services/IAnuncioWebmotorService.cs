using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioWebMotors.Domain.Models;

namespace DesafioWebMotors.Application.Interfaces.Services
{
    public interface IAnuncioWebmotorService
    {
        Task<List<AnuncioWebmotor>> GetAll();
        Task Save(AnuncioWebmotor anuncioWebmotor);
        Task<AnuncioWebmotor> Get(int id);
        Task Remove(int id);
    }
}