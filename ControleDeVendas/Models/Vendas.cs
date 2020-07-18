using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControleDeVendas.Models.Enums;

namespace ControleDeVendas.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double Valor { get; set; }
        public StatusDaVenda  Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public Vendas()
        {
        }

        public Vendas(int id, DateTime data, double valor, StatusDaVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Valor = valor;
            Status = status;
            Vendedor = vendedor;
        }

        
    }
}
