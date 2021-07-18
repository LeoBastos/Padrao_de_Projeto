using Agenda.Infra.Entity;
using Agenda.Infra.Repository;
using Agenda.Service.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Service.Services
{
    public class ServicoService
    {
        ServicoData Data = new ServicoData();

        public ServicoDto GetServicoById(int id)
        {
            return ServicoToDto(Data.GetServicoById(id));
        }

        public List<ServicoDto> GetAllServicos()
        {
            return MapToList(Data.GetAllServicos());
        }


        public void SubmitServico(ServicoDto servicodto)
        {
            if (servicodto.Id == 0)
                AddServico(servicodto);
            else
                UpdateServico(servicodto);
        }

        public void AddServico(ServicoDto servicodto)
        {
            Servico servico = DtoToServico(servicodto);

            Data.InsertServico(servico);
            //Data.InsertCliente(DtoToCliente(clientedto)); //analisar
        }

        public void UpdateServico(ServicoDto servicoDto)
        {
            Servico servico = DtoToServico(servicoDto);

            Data.UpdateServico(servico);
        }

        public void DeleteServico(int id) => Data.DeleteServico(id);



        private ServicoDto ServicoToDto(Servico servico) // parte externa renderizada view para o usuario
        {
            return new ServicoDto
            {
                Id = servico.Id,
                Descricao = servico.Descricao,
            };
        }

        private Servico DtoToServico(ServicoDto servicodto) //parte interna que está recebendo
        {
            return new Servico
            {
                Id = servicodto.Id,
                Descricao = servicodto.Descricao,                           
            };
        }

        private List<ServicoDto> MapToList(List<Servico> services)
        {
            return services.Select(i => ServicoToDto(i)).ToList();
        }
    }
}
