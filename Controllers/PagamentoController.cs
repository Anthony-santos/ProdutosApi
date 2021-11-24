using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosApi.Data;
using ProdutosApi.Models;

namespace testeef.Controllers
{
    [ApiController]
    [Route("api/pagamentos")]
    public class PagamentoControler : ControllerBase
    {
        [HttpPost]
        [Route("/compras")]
        public async Task<ActionResult<Compra>> Post([FromServices] DataContext context, [FromServices] Compra model)
        {
            if (ModelState.IsValid)
            {
                context.Compras.Add(model);
                await context.SaveChangesAsync();
                return StatusCode(200, "Venda Realizada");
            }
            else
            {
                return StatusCode(412, ModelState);
            }
        }
    }
}