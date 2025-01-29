using Controle_de_Estoque_API.Contract.Pecas;
using Controle_de_Estoque_API.Data;
using Controle_de_Estoque_API.Data.Models;
using Controle_de_Estoque_API.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_Estoque_API.Services
{
    public class PecasServices : BaseResponses
    {
        private readonly ControleDeEstoqueContext _context;

        public PecasServices(ControleDeEstoqueContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetAllPecas()
        {
            return Ok(await _context.Pecas.ToListAsync());
        }

        public async Task<IActionResult> GetPecasByName(string query)
        {
            var pecas = await _context.Pecas.Where(x =>
                x.Marca.Contains(query) || x.Modelo.Contains(query) || query == x.Marca + " " + x.Modelo )
                .ToListAsync();

            return Ok(pecas);
        }

        public async Task<IActionResult> CreatePeca(PostCreatePecaRequest peca)
        {
            if (await _context.Pecas.FirstOrDefaultAsync(x => x.Modelo.Contains(peca.Modelo) && x.Cor.Contains(peca.Cor) && x.Marca.Contains(peca.Marca)) == null)
            {
                Peca p = new Peca
                {
                    Marca = peca.Marca,
                    Modelo = peca.Modelo,
                    Cor = peca.Cor,
                    Grau_Importancia = peca.Grau_Importancia,
                    Quantidade_Estoque = peca.Quantidade_Estoque,
                    Localizacao = peca.Localizacao
                };

                await _context.Pecas.AddAsync(p);
                await _context.SaveChangesAsync();

                return Created(new { message = "Peca cadastrada com sucesso!"});
            }
            else
                return BadRequest(new { message = "Modelo exatamente igual à um já existente." });
            
        }

        public async Task<IActionResult> UpdatePeca(Peca peca)
        {
            var currentPeca = await _context.Pecas.FirstOrDefaultAsync(x => x.Id == peca.Id);

            if (currentPeca == null)
                return BadRequest("Peca não encontrada.");
            else if (currentPeca.Modelo == peca.Modelo && currentPeca.Cor == peca.Cor && currentPeca.Marca == peca.Marca && currentPeca.Quantidade_Estoque == peca.Quantidade_Estoque )
                return BadRequest("Peca exatamente igual já existente.");
            else
            {
                currentPeca.Marca = peca.Marca;
                currentPeca.Modelo = peca.Modelo;
                currentPeca.Cor = peca.Cor;
                currentPeca.Quantidade_Estoque = peca.Quantidade_Estoque;
                currentPeca.Grau_Importancia = peca.Grau_Importancia;
                _context.Entry(currentPeca);
            }
                
            await _context.SaveChangesAsync();
            return Updated();
        }

        public async Task<IActionResult> DeletePeca(int Id)
        {
            var peca = await _context.Pecas.FirstOrDefaultAsync(x => x.Id == Id);

            if (peca != null)
            {
                _context.Pecas.Remove(peca);
                await _context.SaveChangesAsync();
                return Deleted();
            }
            else
                return BadRequest("Peca não encontrada para deletar.");
        }

    }
}
