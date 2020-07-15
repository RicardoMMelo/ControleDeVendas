using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeVendas.Data;
using ControleDeVendas.Models;
using ControleDeVendas.Models.Enums;


namespace ControleDeVendas.Data
{
    public class SeedingService
    {
        private ControleDeVendasContext _context;

        public SeedingService(ControleDeVendasContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Departamento.Any() ||
               _context.Vendedor.Any() ||
               _context.Vendas.Any())
            {
                return;
            }


             Departamento d1 = new Departamento(1, "Computers");
             Departamento d2 = new Departamento(2, "Electrônicos");
             Departamento d3 = new Departamento(3, "Eletros");
             Departamento d4 = new Departamento(4, "Livros");

             Vendedor s1 = new Vendedor(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
             Vendedor s2 = new Vendedor(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
             Vendedor s3 = new Vendedor(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
             Vendedor s4 = new Vendedor(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
             Vendedor s5 = new Vendedor(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
             Vendedor s6 = new Vendedor(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

             Vendas r1 = new Vendas(1, new DateTime(2018, 09, 25), 11000.0, StatusDaVenda.Faturado, s1);
             Vendas r2 = new Vendas(2, new DateTime(2018, 09, 4), 7000.0, StatusDaVenda.Faturado, s5);
             Vendas r3 = new Vendas(3, new DateTime(2018, 09, 13), 4000.0, StatusDaVenda.Cancelado, s4);
             Vendas r4 = new Vendas(4, new DateTime(2018, 09, 1), 8000.0, StatusDaVenda.Faturado, s1);
             Vendas r5 = new Vendas(5, new DateTime(2018, 09, 21), 3000.0, StatusDaVenda.Faturado, s3);
             Vendas r6 = new Vendas(6, new DateTime(2018, 09, 15), 2000.0, StatusDaVenda.Faturado, s1);
             Vendas r7 = new Vendas(7, new DateTime(2018, 09, 28), 13000.0, StatusDaVenda.Faturado, s2);
             Vendas r8 = new Vendas(8, new DateTime(2018, 09, 11), 4000.0, StatusDaVenda.Faturado, s4);
             Vendas r9 = new Vendas(9, new DateTime(2018, 09, 14), 11000.0, StatusDaVenda.Pendente, s6);
             Vendas r10 = new Vendas(10, new DateTime(2018, 09, 7), 9000.0, StatusDaVenda.Faturado, s6);
             Vendas r11 = new Vendas(11, new DateTime(2018, 09, 13), 6000.0, StatusDaVenda.Faturado, s2);
             Vendas r12 = new Vendas(12, new DateTime(2018, 09, 25), 7000.0, StatusDaVenda.Pendente, s3);
             Vendas r13 = new Vendas(13, new DateTime(2018, 09, 29), 10000.0, StatusDaVenda.Faturado, s4);
             Vendas r14 = new Vendas(14, new DateTime(2018, 09, 4), 3000.0, StatusDaVenda.Faturado, s5);
             Vendas r15 = new Vendas(15, new DateTime(2018, 09, 12), 4000.0, StatusDaVenda.Faturado, s1);
             Vendas r16 = new Vendas(16, new DateTime(2018, 10, 5), 2000.0, StatusDaVenda.Faturado, s4);
             Vendas r17 = new Vendas(17, new DateTime(2018, 10, 1), 12000.0, StatusDaVenda.Faturado, s1);
             Vendas r18 = new Vendas(18, new DateTime(2018, 10, 24), 6000.0, StatusDaVenda.Faturado, s3);
             Vendas r19 = new Vendas(19, new DateTime(2018, 10, 22), 8000.0, StatusDaVenda.Faturado, s5);
             Vendas r20 = new Vendas(20, new DateTime(2018, 10, 15), 8000.0, StatusDaVenda.Faturado, s6);
             Vendas r21 = new Vendas(21, new DateTime(2018, 10, 17), 9000.0, StatusDaVenda.Faturado, s2);
             Vendas r22 = new Vendas(22, new DateTime(2018, 10, 24), 4000.0, StatusDaVenda.Faturado, s4);
             Vendas r23 = new Vendas(23, new DateTime(2018, 10, 19), 11000.0, StatusDaVenda.Cancelado, s2);
             Vendas r24 = new Vendas(24, new DateTime(2018, 10, 12), 8000.0, StatusDaVenda.Faturado, s5);
             Vendas r25 = new Vendas(25, new DateTime(2018, 10, 31), 7000.0, StatusDaVenda.Faturado, s3);
             Vendas r26 = new Vendas(26, new DateTime(2018, 10, 6), 5000.0, StatusDaVenda.Faturado, s4);
             Vendas r27 = new Vendas(27, new DateTime(2018, 10, 13), 9000.0, StatusDaVenda.Pendente, s1);
             Vendas r28 = new Vendas(28, new DateTime(2018, 10, 7), 4000.0, StatusDaVenda.Faturado, s3);
             Vendas r29 = new Vendas(29, new DateTime(2018, 10, 23), 12000.0, StatusDaVenda.Faturado, s5);
             Vendas r30 = new Vendas(30, new DateTime(2018, 10, 12), 5000.0, StatusDaVenda.Faturado, s2);

             _context.Departamento.AddRange(d1, d2, d3, d4);

                 _context.Vendedor.AddRange(s1, s2, s3, s4, s5, s6);

                 _context.Vendas.AddRange(
                     r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                     r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                     r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
                 );

                 _context.SaveChanges();
        }
    }
}
