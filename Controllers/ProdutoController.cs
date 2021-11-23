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
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Produto>>> Get([FromServices] DataContext context)
        {
            var produtos = await context.Produtos.ToListAsync();
            return produtos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> GetById([FromServices] DataContext context, int id)
        {
            var produto = await context.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return produto;
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<string>> Post([FromServices] DataContext context, [FromBody] Produto model)
        {
            if (ModelState.IsValid)
            {
                context.Produtos.Add(model);
                await context.SaveChangesAsync();
                return "Produto Cadastrado";
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}