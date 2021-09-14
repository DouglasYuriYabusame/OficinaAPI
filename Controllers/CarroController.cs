using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OficinaVesp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarroVesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        public Contexto contexto { get; set; }
        public CarroController(Contexto novoContexto)
        {
            this.contexto = novoContexto;
        }
        [HttpGet]
        public List<Carro> Get()
        {
            return contexto.Carros.ToList();
        }


        [HttpGet("{id}")]
        public Carro Get(int id)
        {
            return contexto.Carros.First(e => e.IdCarro == id);
        }


        [HttpGet("idCarro/{idCarro}")]
        public List<Carro> filtrar(int id)
        {
            return contexto.Carros.Where(e => e.IdCarro == id).ToList();
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Carro>> Create(Carro Carro)
        {
            Carro.IdCarro = 0;
            contexto.Carros.Add(Carro);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Carro.IdCarro, Carro });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Carro>> Update(Carro Carro)
        {
            contexto.Carros.Update(Carro);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Carro.IdCarro, Carro });
        }

        [HttpDelete]
        public async Task<ActionResult<Carro>> Delete(Carro Carro)
        {
            contexto.Carros.Remove(Carro);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Carro.IdCarro, Carro });
        }


    }
}
