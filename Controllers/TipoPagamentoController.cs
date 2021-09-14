using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OficinaVesp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TipoPagamentoVesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPagamentoController : ControllerBase
    {
        public Contexto contexto { get; set; }
        public TipoPagamentoController(Contexto novoContexto)
        {
            this.contexto = novoContexto;
        }
        [HttpGet]
        public List<TipoPagamento> Get()
        {
            return contexto.TiposPagamentos.ToList();
        }


        [HttpGet("{id}")]
        public TipoPagamento Get(int id)
        {
            return contexto.TiposPagamentos.First(e => e.IdTipo_Pagamento == id);
        }


        [HttpGet("IdTipo_Pagamento/{IdTipo_Pagamento}")]
        public List<TipoPagamento> filtrar(int id)
        {
            return contexto.TiposPagamentos.Where(e => e.IdTipo_Pagamento == id).ToList();
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<TipoPagamento>> Create(TipoPagamento TipoPagamento)
        {
            TipoPagamento.IdTipo_Pagamento = 0;
            contexto.TiposPagamentos.Add(TipoPagamento);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = TipoPagamento.IdTipo_Pagamento, TipoPagamento });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<TipoPagamento>> Update(TipoPagamento TipoPagamento)
        {
            contexto.TiposPagamentos.Update(TipoPagamento);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = TipoPagamento.IdTipo_Pagamento, TipoPagamento });
        }

        [HttpDelete]
        public async Task<ActionResult<TipoPagamento>> Delete(TipoPagamento TipoPagamento)
        {
            contexto.TiposPagamentos.Remove(TipoPagamento);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = TipoPagamento.IdTipo_Pagamento, TipoPagamento });
        }


    }
}
