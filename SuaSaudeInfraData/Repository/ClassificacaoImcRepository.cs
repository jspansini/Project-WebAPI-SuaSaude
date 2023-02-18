using Dapper;
using MySqlConnector;
using SuaSaudeService.Entity;
using SuaSaudeService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuaSaudeInfraData.Repository
{
    public class ClassificacaoImcRepository : IClassificacaoIMCRepository
    {

        private string _stringConnection;

        //metodo construtor
        public ClassificacaoImcRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }


        public List<ClassificacaoIMCEntity> ConsultarClassificacaoIMC()
        {
            string query = "SELECT * FROM ClassificacaoIMC";

            using MySqlConnection conn = new(_stringConnection);

            return conn.Query<ClassificacaoIMCEntity>(query).ToList();
        }
    }
}
