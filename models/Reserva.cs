using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospedagem_hotel_C_.models
{
    public class Reserva
    {
        public Reserva()
        {
            Hospedes = new List<Pessoa>();
            Suite = new Suite();
        }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
            Hospedes = new List<Pessoa>();
            Suite = new Suite();
        }

        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if(Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A capacidade de Hospedes excedeu o limite de pessoas");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            Console.WriteLine($"O Valor da diaria R$ {Suite.ValorDiaria}");
            decimal total = DiasReservados * Suite.ValorDiaria;
            decimal desconto = 0;

            if(DiasReservados > 10)
            {
                desconto = total * 10 / 100;
            }

            decimal valorFinal = total - desconto;
            return valorFinal;
        }
    }
}