using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Cadastro_de_Funcionários.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Cadastro_de_Funcionários.Controllers
{
    public class ClientesAPIController : Controller
    {
        public async Task<IActionResult> GetClienteAPI()
        {
            List<ClientesAPIModel> clientes = new List<ClientesAPIModel>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://localhost:7180/Cliente");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    clientes = JsonConvert.DeserializeObject<List<ClientesAPIModel>>(jsonString);
                }
            }
            return View(clientes);



        }
    }
}
