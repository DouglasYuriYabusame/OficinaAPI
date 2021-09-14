using Microsoft.AspNetCore.Mvc;
using OficinaVesp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OficinaVesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OficinaController : ControllerBase
    {
        public Contexto contexto { get; set; }
        public OficinaController(Contexto novoContexto)
        {
            this.contexto = novoContexto;
        }
        [HttpGet]
        public List<Oficina> Get()
        {
            return contexto.Oficinas.ToList();
        }


        [HttpGet("{id}")]
        public Oficina Get(int id)
        {
            return contexto.Oficinas.First(e => e.IdOficina == id);
        }


        [HttpGet("idOficina/{idOficina}")]
        public List<Oficina> filtrar(int id)
        {
            return contexto.Oficinas.Where(e => e.IdOficina == id).ToList();
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Oficina>> Create(Oficina Oficina)
        {
            Oficina.IdOficina = 0;
            contexto.Oficinas.Add(Oficina);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Oficina.IdOficina, Oficina });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Oficina>> Update(Oficina Oficina)
        {
            contexto.Oficinas.Update(Oficina);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Oficina.IdOficina, Oficina });
        }


        [HttpDelete]
        public async Task<ActionResult<Oficina>> Delete(Oficina Oficina)
        {
            contexto.Oficinas.Remove(Oficina);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Oficina.IdOficina, Oficina });
        }

    }
}