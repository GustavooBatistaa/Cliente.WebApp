using Cliente.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace WebApp.Controllers
{
    public class OcorrenciasController : Controller
    {
        private readonly HttpClient _httpClient;

        public OcorrenciasController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Ocorrencias
        public async Task<IActionResult> Index()
        {
            var ocorrencias = await _httpClient.GetFromJsonAsync<List<OcorrenciaViewModel>>("https://localhost:44307/api/ocorrencias");
            return View(ocorrencias);
        }

        // GET: Ocorrencias/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var ocorrencia = await _httpClient.GetFromJsonAsync<OcorrenciaViewModel>($"https://localhost:44307/api/ocorrencias/{id}");
            if (ocorrencia == null)
            {
                return NotFound();
            }
            return View(ocorrencia);
        }

        // GET: Ocorrencias/Create
        public async Task<IActionResult> Create()
        {
            var clientes = await _httpClient.GetFromJsonAsync<List<ClienteViewModel>>("https://localhost:44307/api/clientes");
            ViewBag.Clientes = clientes;
            return View();
        }

        // POST: Ocorrencias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OcorrenciaViewModel ocorrenciaDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:44307/api/ocorrencias", ocorrenciaDto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            var clientes = await _httpClient.GetFromJsonAsync<List<ClienteViewModel>>("https://localhost:44307/api/clientes");
            ViewBag.Clientes = clientes;
            return View(ocorrenciaDto);
        }

        // GET: Ocorrencias/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var ocorrencia = await _httpClient.GetFromJsonAsync<OcorrenciaViewModel>($"https://localhost:44307/api/ocorrencias/{id}");
            if (ocorrencia == null)
            {
                return NotFound();
            }
            var clientes = await _httpClient.GetFromJsonAsync<List<ClienteViewModel>>("https://localhost:44307/api/clientes");
            ViewBag.Clientes = clientes;
            return View(ocorrencia);
        }

    }
}

     