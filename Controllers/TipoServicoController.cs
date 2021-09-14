using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OficinaVesp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TipoServicoVesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicoController : ControllerBase
    {
        public Contexto contexto { get; set; }
        public TipoServicoController(Contexto novoContexto)
        {
            this.contexto = novoContexto;
        }
        [HttpGet]
        public List<TipoServico> Get()
        {
            return contexto.TiposServicos.ToList();
        }


        [HttpGet("{id}")]
        public TipoServico Get(int id)
        {
            return contexto.TiposServicos.First(e => e.IdTipo_Servico == id);
        }


        [HttpGet("IdTipo_Servico/{IdTipo_Servico}")]
        public List<TipoServico> filtrar(int id)
        {
            return contexto.TiposServicos.Where(e => e.IdTipo_Servico == id).ToList();
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<TipoServico>> Create(TipoServico TipoServico)
        {
            TipoServico.IdTipo_Servico = 0;
            contexto.TiposServicos.Add(TipoServico);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = TipoServico.IdTipo_Servico, TipoServico });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<TipoServico>> Update(TipoServico TipoServico)
        {
            contexto.TiposServicos.Update(TipoServico);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = TipoServico.IdTipo_Servico, TipoServico });
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<TipoServico>> Delete(TipoServico TipoServico)
        {
            contexto.TiposServicos.Remove(TipoServico);

            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = TipoServico.IdTipo_Servico, TipoServico });
        }


    }
}
