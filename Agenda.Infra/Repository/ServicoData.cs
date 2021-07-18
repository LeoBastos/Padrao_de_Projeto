using Agenda.Infra.Entity;
using DataCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace Agenda.Infra.Repository
{
    public class ServicoData
    {
        DataCore<Servico> Db = new DataCore<Servico>(new SqlConnection(@"Server=localhost\SqlExpress;Database=Agenda;User Id=sa;Password=qwaszx12"));

        public Servico GetServicoById(int id)
        {
            string sql = "SELECT * FROM SERVICO WHERE ID = @ID AND ISACTIVESERVICE = 1";

            return Db.ExecuteQuery(sql, new { ID = id }).FirstOrDefault();
        }

        public List<Servico> GetAllServicos()
        {
            string sql = "SELECT * FROM SERVICO WHERE ISACTIVESERVICE = 1";

            return Db.ExecuteQuery(sql);
        }

        public void InsertServico(Servico servico)
        {
            string sql = @"INSERT INTO SERVICO (Descricao) VALUES (@Descricao)";

            Db.ExecuteCommand(sql, new
            {
                Descricao = servico.Descricao,      
            });
        }

        public void UpdateServico(Servico servico)
        {
            string sql = @"UPDATE SERVICO SET 
                               DESCRICAO = @DESCRICAO,                               
                            WHERE ID = @ID";

            Db.ExecuteCommand(sql, new
            {
                ID = servico.Id,
                DESCRICAO = servico.Descricao,                
            });
        }

        public void DeleteServico(int id)
        {
            string sql = @"UPDATE SERVICO SET ISACTIVESERVICE = 0 WHERE ID = @ID";

            Db.ExecuteCommand(sql, new { ID = id });
        }

    }
}
