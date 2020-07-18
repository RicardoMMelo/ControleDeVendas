using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVendas.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} - Campo Obrigatório.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="O {0} não pode ser menor que {2} ou maior {1}")]
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Digite um Email Válido!")]
        [Required(ErrorMessage = "{0} - Campo Obrigatório.")]
        public string Email { get; set; }
        [Display(Name = "Aniversário")]
        [Required(ErrorMessage = "{0} - Campo Obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime Aniversario { get; set; }
        [Display(Name = "Salário Base")]
        [Required(ErrorMessage = "{0} - Campo Obrigatório.")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} - deve ser > {1} e < {2}")]
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }
        public ICollection<Vendas> Vendas { get; set; } = new List<Vendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime aniversario, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Aniversario = aniversario;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionaVendas(Vendas sr)
        {
            Vendas.Add(sr);
        }

        public void ApagaVendas(Vendas sr)
        {
            Vendas.Remove(sr);
        }
        public double VendasTotais(DateTime inicial, DateTime final)
        {
            return Vendas.Where(sr => sr.Data >= inicial && sr.Data <= final).Sum(sr => sr.Valor);
        }
    }
}
