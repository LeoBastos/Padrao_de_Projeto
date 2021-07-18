using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;


namespace Agenda.Service.Dto
{
    public class AgendamentoFormDto
    {
        public int Id { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int FormaDePagamento { get; set; }
        public int Finalizado { get; set; }
        public ClienteDto Cliente { get; set; }
        public ServicoDto Servico { get; set; }
        public IEnumerable<SelectListItem> SelectCliente { get; set; }
        public IEnumerable<SelectListItem> SelectServico { get; set; }
    }
}
