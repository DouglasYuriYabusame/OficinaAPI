using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaVesp.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Oficina> Oficinas { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<TipoPagamento> TiposPagamentos { get; set; }
        public DbSet<TipoServico> TiposServicos { get; set; }

        public Contexto(DbContextOptions opcoes) : base(opcoes)
        {

        }

    }

}