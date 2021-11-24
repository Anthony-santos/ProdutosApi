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
            if (ModelState.IsValid)
            {
                context.Compras.Add(model);
                if (!CartaoIsValid(model.Cartao))
                    return StatusCode(412, "Cartao não é válido");
                await context.SaveChangesAsync();
                return StatusCode(200, "Venda Realizada");
            }
            else
            {
                return StatusCode(412, ModelState);
            }
        }

        public bool CartaoIsValid(Cartao cartao)
        {
            return false;
        }
    }
}