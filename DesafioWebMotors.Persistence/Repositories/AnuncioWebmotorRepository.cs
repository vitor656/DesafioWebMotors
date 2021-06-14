using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioWebMotors.Application.Interfaces.Repositories;
using DesafioWebMotors.Domain.Models;
using DesafioWebMotors.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DesafioWebMotors.Persistence.Repositories
{
    public class AnuncioWebmotorRepository : IAnuncioWebmotorRepository
    {
        private readonly ApplicationContext _applicationContext;
        public AnuncioWebmotorRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task Delete(int id)
        {
            var anuncio = await _applicationContext.AnuncioWebmotors.Where(e => e.Id == id).FirstAsync();
            _applicationContext.AnuncioWebmotors.Remove(anuncio);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<AnuncioWebmotor> Get(int id)
        {
            var data = await _applicationContext.AnuncioWebmotors.Where(e => e.Id == id).FirstAsync();
            return data;
        }

        public async Task<List<AnuncioWebmotor>> GetAll()
        {
            var anuncios = await _applicationContext.AnuncioWebmotors.ToListAsync();
            return anuncios;
        }

        public async Task Save(AnuncioWebmotor anuncioWebmotor)
        {
            if (anuncioWebmotor.Id > 0)
            {
                _applicationContext.AnuncioWebmotors.Update(anuncioWebmotor);
            }
            else
            {
                await _applicationContext.AnuncioWebmotors.AddAsync(anuncioWebmotor);
            }

            await _applicationContext.SaveChangesAsync();
        }
    }
}