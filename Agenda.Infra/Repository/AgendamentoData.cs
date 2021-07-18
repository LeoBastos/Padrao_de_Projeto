using Agenda.Infra.Entity;
using DataCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Agenda.Infra.Repository
{
    public class AgendamentoData
    {
        DataCore<Agendamento> Db = new DataCore<Agendamento>(DbConfig.DbConnection);

        public List<Agendamento> GetAllAgendamentos()
        {
            string sql = "SELECT * FROM AGENDAMENTO";

            return Db.ExecuteQuery(sql);
        }

        public List<Agendamento> GetAllFormaDePagamentos()
        {
            string sql = "SELECT FORMADEPAGAMENTO FROM AGENDAMENTO";

            return Db.ExecuteQuery(sql);
        }

        public void InsertAgendamento(Agendamento agenda)
        {
            string sql = @"INSERT INTO AGENDAMENTO ( NomeCliente, DescricaoServico, DataAgendamento, Inicio, Fim, FormaDePagamento, Finalizado) 
                           VALUES (@NomeCliente, @DescricaoServico, @DataAgendamento, @Inicio, @Fim, @FormaDePagamento, @Finalizado)";

            Db.ExecuteCommand(sql, new
            {
                
                NomeCliente = agenda.NomeCliente,
                DescricaoServico = agenda.DescricaoServico,
                DataAgendamento = agenda.DataAgendamento,
                Inicio = agenda.Inicio,
                Fim = agenda.Fim,
                FormaDePagamento = agenda.FormaDePagamento,
                Finalizado = agenda.Finalizado,
            });
        }
        public void UpdateAgendamento(Agendamento agenda)
        {
            string sql = @"UPDATE AGENDAMENTO SET 
                               ID = @ID,
                               NomeCliente = @NomeCliente,
                               ServicoId = @ServicoId,
                               DataAgendamento = @DataAgendamento,
                               Inicio = @Inicio,
                               Fim = @Fim,
                               FormaDePagamento = @FormaDePagamento
                               Finalizado = @Finalizado
                            WHERE ID = @ID";

            Db.ExecuteCommand(sql, new
            {
                Id = agenda.Id,
                NomeCliente = agenda.NomeCliente,
                DescricaoServico = agenda.DescricaoServico,
                DataAgendamento = agenda.DataAgendamento,
                Inicio = agenda.Inicio,
                Fim = agenda.Fim,
                FormaDePagamento = agenda.FormaDePagamento,
                Finalizado = agenda.Finalizado,
            });
        }

        public Agendamento GetAgendamentoById(int id)
        {
            string sql = "SELECT * FROM Agendamento WHERE ID = @ID";

            return Db.ExecuteQuery(sql, new { ID = id }).FirstOrDefault();
        }
    }
}
