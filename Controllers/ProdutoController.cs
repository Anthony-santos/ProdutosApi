using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosApi.Data;
using ProdutosApi.Models;

namespace testeef.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoControler : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Produto>>> Get([FromServices] DataContext context)
        {
            var produtos = await context.Produtos.ToListAsync();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> GetById([FromServices] DataContext context, int id)
        {
            var produto = await context.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(produto);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> Delete([FromServices] DataContext context, int id)
        {
            var produto = await context.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            context.Produtos.Remove(produto);
            context.SaveChanges();
            return Ok("Produto excluído com sucesso");
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produto>> Post([FromServices] DataContext context, [FromBody] Produto model)
        {
            if (ModelState.IsValid)
            {
                context.Produtos.Add(model);
                await context.SaveChangesAsync();
                return Ok("Produto Cadastrado");
            }
            else
            {
                return StatusCode(412, "Produto Cadastrado");
            }
        }

    }
}