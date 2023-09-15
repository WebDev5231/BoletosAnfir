using BoletosAnfir.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosAnfir.Data
{
    public class BoletoData
    {
        public BoletoAnfir GetBoleto(string numeroDoc)
        {
            using (var cn = new SqlConnection(Database.ConnectionString))
            {
                var sql = "SELECT boleto_assoc.*, cadastro.Razao, cadastro.CNPJ,cadastro.Endereco, cadastro.Numero, cadastro.Bairro, cadastro.Cep, municipios.munMUNICIP, municipios.munEST FROM boleto_assoc INNER JOIN cadastro ON cadastro.ID_Empresa = boleto_assoc.ID_Empresa LEFT OUTER JOIN municipios ON municipios.munCOD = cadastro.ID_Cidade WHERE boleto_assoc.Numero_Doc = @NumeroDoc";

                return cn.QueryFirstOrDefault<BoletoAnfir>(sql, new { NumeroDoc = numeroDoc });
            }
        }
    }
}
