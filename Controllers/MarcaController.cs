using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OficinaVesp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarcaVesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        public Contexto contexto { get; set; }
        public MarcaController(Contexto novoContexto)
        {
            this.contexto = novoContexto;
        }
        [HttpGet]
        public List<Marca> Get()
        {
            return contexto.Marcas.ToList();
        }


        [HttpGet("{id}")]
        public Marca Get(int id)
        {
            return contexto.Marcas.First(e => e.IdMarca == id);
        }


        [HttpGet("idMarca/{idMarca}")]
        public List<Marca> filtrar(int id)
        {
            return contexto.Marcas.Where(e => e.IdMarca == id).ToList();
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Marca>> Create(Marca Marca)
        {
            Marca.IdMarca = 0;
            contexto.Marcas.Add(Marca);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Marca.IdMarca, Marca });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Marca>> Update(Marca Marca)
        {
            contexto.Marcas.Update(Marca);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Marca.IdMarca, Marca });
        }

        [HttpDelete]
        public async Task<ActionResult<Marca>> Delete(Marca Marca)
        {
            contexto.Marcas.Remove(Marca);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Marca.IdMarca, Marca });
        }


    }
}