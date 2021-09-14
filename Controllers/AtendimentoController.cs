using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OficinaVesp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendimentoVesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        public Contexto contexto { get; set; }
        public AtendimentoController(Contexto novoContexto)
        {
            this.contexto = novoContexto;
        }
        [HttpGet]
        public List<Atendimento> Get()
        {
            return contexto.Atendimentos.ToList();
        }


        [HttpGet("{id}")]
        public Atendimento Get(int id)
        {
            return contexto.Atendimentos.First(e => e.IdAtendimento == id);
        }


        [HttpGet("idAtendimento/{idAtendimento}")]
        public List<Atendimento> filtrar(int id)
        {
            return contexto.Atendimentos.Where(e => e.IdAtendimento == id).ToList();
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Atendimento>> Create(Atendimento Atendimento)
        {
            Atendimento.IdAtendimento = 0;
            contexto.Atendimentos.Add(Atendimento);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Atendimento.IdAtendimento, Atendimento });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Atendimento>> Update(Atendimento Atendimento)
        {
            contexto.Atendimentos.Update(Atendimento);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Atendimento.IdAtendimento, Atendimento });
        }

        [HttpDelete]
        public async Task<ActionResult<Atendimento>> Delete(Atendimento atendimento)
        {
            contexto.Atendimentos.Remove(atendimento);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = atendimento.IdAtendimento, atendimento });
        }


    }
}
