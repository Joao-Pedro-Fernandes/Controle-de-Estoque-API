using Controle_de_Estoque_API.Contract.Pecas;
using Controle_de_Estoque_API.Data.Models;
using Controle_de_Estoque_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Controle_de_Estoque_API.Controllers
{
    [Route("[controller]")]
    public class PecasController : Controller
    {
        private readonly PecasServices _services;
        public PecasController(PecasServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPecas()
        {
            return await _services.GetAllPecas();
        }

        [HttpGet("ByName={query}")]
        public async Task<IActionResult> GetPecasByName(string query)
        {
            return await _services.GetPecasByName(query);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePeca([FromBody] PostCreatePecaRequest request)
        {
            return await _services.CreatePeca(request);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePeca([FromBody] Peca request)
        {
            return await _services.UpdatePeca(request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeca(int id)
        {
            return await _services.DeletePeca(id);
        }
    }
}
