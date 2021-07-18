using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Infra.Entity
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public FormaDePagamento FormaDePagamento{ get; set; }
        public Finalizado Finalizado { get; set; }
        public string NomeCliente { get; set; }
        public string DescricaoServico { get; set; }       
    }

    public enum FormaDePagamento
    {
        CartaoDeCredito,
        CartaoDeDebito,
        Convenio,
        Dinheiro,
    }

    public enum Finalizado
    {
        Aberto,
        Finalizado,
    }
}
