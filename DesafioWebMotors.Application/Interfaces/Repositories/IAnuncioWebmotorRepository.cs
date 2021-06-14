using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioWebMotors.Domain.Models;

namespace DesafioWebMotors.Application.Interfaces.Repositories
{
    public interface IAnuncioWebmotorRepository
    {
        Task<List<AnuncioWebmotor>> GetAll();
        Task Save(AnuncioWebmotor anuncioWebmotor);
        Task<AnuncioWebmotor> Get(int id);
        Task Delete(int id);
    }
}