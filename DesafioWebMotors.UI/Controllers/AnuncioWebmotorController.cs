using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioWebMotors.Application.Interfaces.Services;
using DesafioWebMotors.Application.Models.DTO;
using DesafioWebMotors.Domain.Models;
using DesafioWebMotors.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioWebMotors.UI.Controllers
{
    public class AnuncioWebmotorController : Controller
    {
        private readonly IAnuncioWebmotorService _anuncioWebMotorService;
        private readonly IWebmotorApiService _webMotorApiService;

        public AnuncioWebmotorController(IAnuncioWebmotorService anuncioWebmotorService, IWebmotorApiService webMotorApiService)
        {
            _anuncioWebMotorService = anuncioWebmotorService;
            _webMotorApiService = webMotorApiService;
        }

        public async Task<IActionResult> Index()
        {
            List<AnuncioWebMotorViewModel> dados = new List<AnuncioWebMotorViewModel>();
            var anuncios = await _anuncioWebMotorService.GetAll();
            anuncios.ForEach(a =>
            {
                dados.Add(new AnuncioWebMotorViewModel
                {
                    Ano = a.Ano,
                    Marca = a.Marca,
                    Id = a.Id,
                    Modelo = a.Modelo,
                    Observacao = a.Observacao,
                    Quilometragem = a.Quilometragem,
                    Versao = a.Versao
                });
            });

            return View(dados);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var makes = await _webMotorApiService.GetMakes();
            makes.Insert(0, new Make
            {
                ID = 0,
                Name = "-- Selecione uma marca --"
            });
            ViewBag.makes = makes;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnuncioWebMotorViewModel anuncioWebMotorViewModel)
        {
            AnuncioWebmotor anuncioWebmotor = new AnuncioWebmotor
            {
                Ano = anuncioWebMotorViewModel.Ano,
                Marca = anuncioWebMotorViewModel.Marca,
                Modelo = anuncioWebMotorViewModel.Modelo,
                Observacao = anuncioWebMotorViewModel.Observacao,
                Quilometragem = anuncioWebMotorViewModel.Quilometragem,
                Versao = anuncioWebMotorViewModel.Versao
            };

            await _anuncioWebMotorService.Save(anuncioWebmotor);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var anuncio = await _anuncioWebMotorService.Get(id);
            AnuncioWebMotorViewModel viewModel = new AnuncioWebMotorViewModel
            {
                Ano = anuncio.Ano,
                Id = anuncio.Id,
                Marca = anuncio.Marca,
                Modelo = anuncio.Modelo,
                Observacao = anuncio.Observacao,
                Quilometragem = anuncio.Quilometragem,
                Versao = anuncio.Versao
            };

            var makes = await _webMotorApiService.GetMakes();
            var selectedMake = makes.FirstOrDefault(c => c.Name == viewModel.Marca);
            ViewBag.makes = makes;

            var models = await _webMotorApiService.GetModels(selectedMake.ID);
            var selectedModel = models.FirstOrDefault(f => f.Name == viewModel.Modelo);
            ViewBag.models = models;

            var versions = await _webMotorApiService.GetVersions(selectedModel.ID);
            ViewBag.versions = versions;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AnuncioWebMotorViewModel viewModel)
        {
            var anuncio = await _anuncioWebMotorService.Get(viewModel.Id);
            anuncio.Ano = viewModel.Ano;
            anuncio.Marca = viewModel.Marca;
            anuncio.Modelo = viewModel.Modelo;
            anuncio.Observacao = viewModel.Observacao;
            anuncio.Quilometragem = viewModel.Quilometragem;
            anuncio.Versao = viewModel.Versao;

            await _anuncioWebMotorService.Save(anuncio);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _anuncioWebMotorService.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<JsonResult> ObterModelos(string name)
        {
            var makes = await _webMotorApiService.GetMakes();
            var selected = makes.FirstOrDefault(c => c.Name == name);
            var modelos = await _webMotorApiService.GetModels(selected.ID);

            return Json(modelos);
        }
        public async Task<JsonResult> ObterVersoes(string marca, string modelo)
        {
            var makes = await _webMotorApiService.GetMakes();
            var selected = makes.FirstOrDefault(c => c.Name == marca);
            var modelos = await _webMotorApiService.GetModels(selected.ID);
            var selectedModel = modelos.FirstOrDefault(d => d.Name == modelo);
            var versions = await _webMotorApiService.GetVersions(selectedModel.ID);

            return Json(versions);
        }

    }
}