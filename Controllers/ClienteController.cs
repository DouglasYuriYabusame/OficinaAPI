using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OficinaVesp.Models;

namespace ClienteVesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public Contexto contexto { get; set; }
        public ClienteController(Contexto novoContexto)
        {
            this.contexto = novoContexto;
        }
        [HttpGet]
        public List<Cliente> Get()
        {
            return contexto.Clientes.ToList();
        }


        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            return contexto.Clientes.First(e => e.IdCliente == id);
        }


        [HttpGet("idCliente/{idCliente}")]
        public List<Cliente> filtrar(int id)
        {
            return contexto.Clientes.Where(e => e.IdCliente == id).ToList();
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Cliente>> Create(Cliente Cliente)
        {
            Cliente.IdCliente = 0;
            contexto.Clientes.Add(Cliente);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Cliente.IdCliente, Cliente });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Cliente>> Update(Cliente Cliente)
        {
            contexto.Clientes.Update(Cliente);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Cliente.IdCliente, Cliente });
        }

        [HttpDelete]
        public async Task<ActionResult<Cliente>> Delete(Cliente Cliente)
        {
            contexto.Clientes.Remove(Cliente);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Cliente.IdCliente, Cliente });
        }


    }
}
