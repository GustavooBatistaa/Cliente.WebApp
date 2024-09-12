using Microsoft.AspNetCore.Mvc;

using Cliente.Models; 

namespace WebApp.Controllers
{
    public class ClientesController : Controller
    {
        private readonly HttpClient _httpClient;

        public ClientesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var clientes = await _httpClient.GetFromJsonAsync<List<ClienteViewModel>>("api/clientes/todos");
            return View(clientes);
        }
        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _httpClient.GetFromJsonAsync<ClienteViewModel>($"api/clientes/{id}");
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("api/clientes", clienteDto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                // Adicione tratamento para erro, se necessário
                ModelState.AddModelError("", "Erro ao criar cliente.");
            }
            return View(clienteDto);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _httpClient.GetFromJsonAsync<ClienteViewModel>($"api/clientes/{id}");
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClienteViewModel clienteDto)
        {
            if (id != clienteDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"api/clientes/{id}", clienteDto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                // Adicione tratamento para erro, se necessário
                ModelState.AddModelError("", "Erro ao atualizar cliente.");
            }
            return View(clienteDto);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _httpClient.GetFromJsonAsync<ClienteViewModel>($"api/clientes/{id}");
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/clientes/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            // Adicione tratamento para erro, se necessário
            return BadRequest("Erro ao deletar cliente.");
        }
    }
}
