using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Infra
{
    static class DbConfig
    {
        public static SqlConnection DbConnection 
        { get 
            { 
                return new SqlConnection(@"Server=localhost\SqlExpress;Database=Agenda;User Id=sa;Password=qwaszx12"); 
            } 
        }
    }
}
