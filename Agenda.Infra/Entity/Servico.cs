using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Infra.Entity
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool IsActiveService { get; set; }
    }
}
