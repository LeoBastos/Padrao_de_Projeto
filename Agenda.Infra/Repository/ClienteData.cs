using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Agenda.Infra.Entity;
using DataCore;

namespace Agenda.Infra.Repository
{
    public class ClienteData
    {
        DataCore<Cliente> Db = new DataCore<Cliente>(DbConfig.DbConnection);

        public Cliente GetClienteById(int id)
        {
            string sql = "SELECT * FROM CLIENTE WHERE ID = @ID AND ISACTIVE = 1";

            return Db.ExecuteQuery(sql, new { ID = id }).FirstOrDefault();
        }

        public List<Cliente> GetAllClientes()
        {
            string sql = "SELECT * FROM CLIENTE WHERE ISACTIVE = 1";

            return Db.ExecuteQuery(sql);
        }
        
        public void InsertCliente(Cliente cliente)
        {
            string sql = @"INSERT INTO CLIENTE (Nome, Cpf, Email, Telefone, DataNascimento) 
                           VALUES (@Nome, @Cpf, @Email, @Telefone, @DataNascimento)";

            Db.ExecuteCommand(sql, new
            {
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                DataNascimento = cliente.DataNascimento
            });
        }

        public void UpdateCliente(Cliente cliente)
        {
            string sql = @"UPDATE CLIENTE SET 
                               NOME = @NOME,
                               CPF = @CPF,
                               EMAIL = @EMAIL,
                               TELEFONE = @TELEFONE,
                               DATANASCIMENTO = @DATANASCIMENTO 
                            WHERE ID = @ID";

            Db.ExecuteCommand(sql, new
            {
                ID = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                DataNascimento = cliente.DataNascimento
            });
        }

        public void DeleteCliente(int id)
        {
            string sql = @"UPDATE CLIENTE SET ISACTIVE = 0 WHERE ID = @ID";

            Db.ExecuteCommand(sql, new { ID = id });
        }      
    }
}
