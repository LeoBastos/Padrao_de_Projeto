using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Service.Dto
{
    public class IndexDto
    {   
        public int TotalClientes
        {
            get
            {
                return Clientes.Count();
            }
        }

        public int TotalServicos
        {
            get
            {
                return Servicos.Count();
            }
        }

        public int TotalAgendamentos
        {
            get
            {
                return Agendamentos.Count();
            }
        }

        public List<ClienteDto> Clientes { get; set; } = new List<ClienteDto>();
        public List<ServicoDto> Servicos { get; set; } = new List<ServicoDto>();
        public List<AgendamentoFormDto> Agendamentos { get; set; } = new List<AgendamentoFormDto>();
    }
}
