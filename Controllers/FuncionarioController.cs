using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OficinaVesp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuncionarioVesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        public Contexto contexto { get; set; }
        public FuncionarioController(Contexto novoContexto)
        {
            this.contexto = novoContexto;
        }
        [HttpGet]
        public List<Funcionario> Get()
        {
            return contexto.Funcionarios.ToList();
        }


        [HttpGet("{id}")]
        public Funcionario Get(int id)
        {
            return contexto.Funcionarios.First(e => e.IdFuncionario == id);
        }


        [HttpGet("idFuncionario/{idFuncionario}")]
        public List<Funcionario> filtrar(int id)
        {
            return contexto.Funcionarios.Where(e => e.IdFuncionario == id).ToList();
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Funcionario>> Create(Funcionario Funcionario)
        {
            Funcionario.IdFuncionario = 0;
            contexto.Funcionarios.Add(Funcionario);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Funcionario.IdFuncionario, Funcionario });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Funcionario>> Update(Funcionario Funcionario)
        {
            contexto.Funcionarios.Update(Funcionario);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Funcionario.IdFuncionario, Funcionario });
        }

        [HttpDelete]
        public async Task<ActionResult<Funcionario>> Delete(Funcionario Funcionario)
        {
            contexto.Funcionarios.Remove(Funcionario);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Funcionario.IdFuncionario, Funcionario });
        }


    }
}
