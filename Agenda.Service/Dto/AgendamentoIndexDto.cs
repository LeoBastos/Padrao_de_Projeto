using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Service.Dto
{
    public class AgendamentoIndexDto
    {       
        public int TotalAgendamentos
        {
            get
            {
                return Agendamentos.Count();
            }
        }

        public List<AgendamentoDto> Agendamentos { get; set; } = new List<AgendamentoDto>();
    }

    public class AgendamentoDto
    {
        public int Id { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public string FormaDePagamento { get; set; }
        public string Finalizado { get; set; }
        public string Cliente { get; set; }
        public string Servico { get; set; }
    }
}
