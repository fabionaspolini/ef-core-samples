using System;
using System.Linq;
using ConsoleApp.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace ConsoleApp
{
    class Program
    {
        public const string ConnectioString = "Server=localhost;Port=5432;Database=ef-core-samples;User Id=postgres;Password=123456;";
        static void Main(string[] args)
        {
            Console.WriteLine("EF Core Samples!");

            var optionsBuilder = new DbContextOptionsBuilder<SampleContext>();
            optionsBuilder.UseNpgsql(ConnectioString);
            optionsBuilder.LogTo(Console.WriteLine);

            using var conn = new SampleContext(optionsBuilder.Options);

            var query = conn.Fretes
                .Where(x => x.Remetente.Cidade.UF == "SC")
                .OrderByDescending(x => x.Valor)
                .Take(10)
                .Skip(30)
                .Select(x => new
                {
                    x.Id,
                    x.Valor,
                    NomeRemetente = x.Remetente.Nome,
                    NomeDestinatario = x.Destinatario.Nome,
                    CidadeRemente = x.Remetente.Cidade.Nome,
                    CidadeDestinatario = x.Destinatario.Cidade.Nome
                });
            var fretes = query.ToList();

            Console.WriteLine("Fim");
        }
    }
}
