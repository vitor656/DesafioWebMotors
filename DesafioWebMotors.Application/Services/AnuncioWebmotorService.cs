using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioWebMotors.Application.Interfaces.Repositories;
using DesafioWebMotors.Application.Interfaces.Services;
using DesafioWebMotors.Domain.Models;

namespace DesafioWebMotors.Application.Services
{
    public class AnuncioWebmotorService : IAnuncioWebmotorService
    {
        private readonly IAnuncioWebmotorRepository _repository;

        public AnuncioWebmotorService(IAnuncioWebmotorRepository anuncioWebmotorRepository)
        {
            _repository = anuncioWebmotorRepository;
        }

        public async Task Save(AnuncioWebmotor anuncioWebmotor)
        {
            await _repository.Save(anuncioWebmotor);
        }

        public async Task<List<AnuncioWebmotor>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<AnuncioWebmotor> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task Remove(int id)
        {
            await _repository.Delete(id);
        }
    }
}