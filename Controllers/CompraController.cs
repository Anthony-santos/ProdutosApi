using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosApi.Data;
using ProdutosApi.Models;

namespace testeef.Controllers
{
    [ApiController]
    [Route("api/compras")]
    public class CompraControler : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Compra>> Post([FromServices] DataContext context, [FromBody] Compra model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == model.Produto_Id);
                    produto.Qtde_Estoque -= model.Qtde_Comprada;
                    produto.Valor_Ultima_venda = produto.Valor_Unitario * model.Qtde_Comprada;
                    produto.Ultima_Venda = DateTime.Now;

                    await context.SaveChangesAsync();
                    return StatusCode(200, "Venda Realizada");
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}