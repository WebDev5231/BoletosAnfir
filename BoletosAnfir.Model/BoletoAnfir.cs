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
        public decimal Valor { get; set; }
        public DateTime Data_Venc { get; set; }
        public string situacao { get; set; }
        public string Numero_Doc { get; set; }
        public DateTime Data_Doc { get; set; }
    }
    public class DadosCedente
    {
        public string Empresa { get; set; } = "ASSOC. NAC. DOS FAB. DE IMP. RODOVIÁRIOS";
        public string CNPJ { get; set; } = "90.773.102/0001-32";
        public string Agencia { get; set; } = "3304";
        public string DigitoAgencia { get; set; } = "9";
        public string NumeroCarteira { get; set; } = "09";
        public string NumeroConta { get; set; } = "0002244";
        public string DigitoConta { get; set; } = "6";
    }
}
