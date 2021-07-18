using Agenda.Infra.Entity;
using Agenda.Infra.Repository;
using Agenda.Service.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Service.Services
{
    public class ClienteService
    {
        ClienteData Data = new ClienteData();

        public ClienteDto GetClienteById(int id)
        {
            return ClienteToDto(Data.GetClienteById(id));
        }

        public IndexDto GetAllClientes()
        {
            return new IndexDto
            {
                Clientes = MapToList(Data.GetAllClientes())
            };
        }

        public void SubmitCliente(ClienteDto clientedto)
        {
            if (clientedto.Id == 0)
                AddCliente(clientedto);
            else
                UpdateCliente(clientedto);
        }

        public void AddCliente(ClienteDto clientedto)
        {
            Cliente cliente = DtoToCliente(clientedto);

            Data.InsertCliente(cliente);
            //Data.InsertCliente(DtoToCliente(clientedto)); //analisar
        }

        public void UpdateCliente(ClienteDto clienteDto)
        {
            Cliente cliente = DtoToCliente(clienteDto);

            Data.UpdateCliente(cliente);
        }

        public void DeleteCliente(int id) => Data.DeleteCliente(id);


        private ClienteDto ClienteToDto(Cliente cliente) // parte externa renderizada view para o usuario
        {
            return new ClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                DataNascimento = cliente.DataNascimento
            };
        }

        private Cliente DtoToCliente(ClienteDto clientedto) //parte interna que está recebendo
        {
            return new Cliente
            {
                Id = clientedto.Id,
                Nome = clientedto.Nome,
                Cpf = clientedto.Cpf,
                Email = clientedto.Email,
                Telefone = clientedto.Telefone,
                DataNascimento = clientedto.DataNascimento
            };
        }

        private List<ClienteDto> MapToList(List<Cliente> clientes)
        {
            return clientes.Select(i => ClienteToDto(i)).ToList();
        }
    }
}

