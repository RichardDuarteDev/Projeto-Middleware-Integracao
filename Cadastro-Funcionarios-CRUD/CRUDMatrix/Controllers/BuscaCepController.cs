using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CRUDMatrix.Models;

public class BuscaCepController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BuscaCepController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public IActionResult BuscaCep()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> BuscaCep(string cep)
    {
        if (string.IsNullOrWhiteSpace(cep))
        {
            ModelState.AddModelError("", "Informe um CEP válido.");
            return View();
        }

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://brasilapi.com.br/api/cep/v1/{cep}");

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError("", "CEP não encontrado.");
            return View();
        }

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BuscaCepModel>(json);

        return View(result);
    }
}