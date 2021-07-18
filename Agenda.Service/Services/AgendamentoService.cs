using Agenda.Infra.Entity;
using Agenda.Infra.Repository;
using Agenda.Service.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;


namespace Agenda.Service.Services
{
    public class AgendamentoService
    {
        AgendamentoData Data = new AgendamentoData();

        public AgendamentoIndexDto GetAllAgendamentos()
        {
            return new AgendamentoIndexDto
            {
                Agendamentos = Data.GetAllAgendamentos()
                    .Select(i => new AgendamentoDto
                    {
                        Cliente = i.NomeCliente,
                        Servico = i.DescricaoServico,
                        FormaDePagamento = i.FormaDePagamento.ToString(),
                        Finalizado = i.Finalizado.ToString(),
                        DataAgendamento = i.DataAgendamento,
                        Inicio = i.Inicio,
                        Fim = i.Fim,
                    }).ToList()
            };
        }

        public AgendamentoFormDto GetNewAgendamento()
        {
            return new AgendamentoFormDto
            {
                SelectCliente = new ClienteData().GetAllClientes().Select(i => new SelectListItem { Value = i.Nome, Text = i.Nome }),
                SelectServico = new ServicoData().GetAllServicos().Select(i => new SelectListItem { Value = i.Descricao, Text = i.Descricao }),
            };
        }

        public AgendamentoFormDto GetAgendamentoById(int id)
        {
            return AgendamentoToDto(Data.GetAgendamentoById(id));
        }

        public List<AgendamentoFormDto> GetAllFormaDePagamentos()
        {
            return MapToList(Data.GetAllFormaDePagamentos());
        }

        public void AddAgendamento(AgendamentoFormDto agendamentodto)
        {
            Agendamento agendamento = DtoToAgendamento(agendamentodto);

            Data.InsertAgendamento(agendamento);

        }

        public void UpdateAgendamento(AgendamentoFormDto agendamentoDto)
        {
            Agendamento agendamento = DtoToAgendamento(agendamentoDto);

            Data.UpdateAgendamento(agendamento);
        }
        public void SubmitAgendamento(AgendamentoFormDto agendamentodto)
        {
            if (agendamentodto.Id == 0)
                AddAgendamento(agendamentodto);
            else
                UpdateAgendamento(agendamentodto);
        }

        private AgendamentoFormDto AgendamentoToDto(Agendamento agenda) // parte externa renderizada view para o usuario
        {
            return new AgendamentoFormDto
            {
                Id = agenda.Id,
                DataAgendamento = agenda.DataAgendamento,
                Inicio = agenda.Inicio,
                Fim = agenda.Fim,
                FormaDePagamento = (int)agenda.FormaDePagamento,
                Finalizado = (int)agenda.Finalizado,
                Cliente = new ClienteDto() { Nome = agenda.NomeCliente },
                Servico = new ServicoDto() { Descricao = agenda.DescricaoServico },
                SelectCliente = new ClienteData().GetAllClientes().Select(i => new SelectListItem { Value = i.Nome, Text = i.Nome }),
                SelectServico = new ServicoData().GetAllServicos().Select(i => new SelectListItem { Value = i.Descricao, Text = i.Descricao }),
            };
        }

        private Agendamento DtoToAgendamento(AgendamentoFormDto agendadto) //parte interna que está recebendo
        {
            return new Agendamento
            {
                Id = agendadto.Id,
                DataAgendamento = agendadto.DataAgendamento,
                Inicio = agendadto.Inicio,
                Fim = agendadto.Fim,
                FormaDePagamento = (FormaDePagamento)agendadto.FormaDePagamento,
                Finalizado = (Finalizado)agendadto.Finalizado,
                NomeCliente = agendadto.Cliente.Nome,
                DescricaoServico = agendadto.Servico.Descricao,
            };
        }
        private List<AgendamentoFormDto> MapToList(List<Agendamento> services)
        {
            return services.Select(i => AgendamentoToDto(i)).ToList();
        }
    }
}
