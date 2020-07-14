using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeVendas.Models.Enums;

namespace ControleDeVendas.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public StatusDaVenda  Status { get; set; }
        public Vendedor Vendador { get; set; }

        public Vendas()
        {
        }

        public Vendas(int id, DateTime data, double valor, StatusDaVenda status, Vendedor vendador)
        {
            Id = id;
            Data = data;
            Valor = valor;
            Status = status;
            Vendador = vendador;
        }

        
    }
}
