using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OficinaVesp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoVesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        public Contexto contexto { get; set; }
        public ServicoController(Contexto novoContexto)
        {
            this.contexto = novoContexto;
        }
        [HttpGet]
        public List<Servico> Get()
        {
            return contexto.Servicos.ToList();
        }


        [HttpGet("{id}")]
        public Servico Get(int id)
        {
            return contexto.Servicos.First(e => e.IdServico == id);
        }


        [HttpGet("idServico/{idServico}")]
        public List<Servico> filtrar(int id)
        {
            return contexto.Servicos.Where(e => e.IdServico == id).ToList();
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Servico>> Create(Servico Servico)
        {
            Servico.IdServico = 0;
            contexto.Servicos.Add(Servico);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Servico.IdServico, Servico });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Servico>> Update(Servico Servico)
        {
            contexto.Servicos.Update(Servico);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Servico.IdServico, Servico });
        }


        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<Servico>> Delete(Servico servico)
        {
            contexto.Servicos.Remove(servico);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = servico.IdServico, servico });
        }

    }
}
