using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosAnfir.Model
{
    public class BoletoAnfir
    {
        public string Razao { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string munMUNICIP { get; set; }
        public string munEST { get; set; }
        public string EspecieDocumento { get; set; }
        public string CNPJ { get; set; }
        public string Nosso_Numero { get; set; }
        public double Valor { get; set; }
        public DateTime Data_Venc { get; set; }
        public string situacao { get; set; }
        public DateTime Data_Doc { get; set; }
    }
}
