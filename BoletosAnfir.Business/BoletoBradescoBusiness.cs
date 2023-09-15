using BoletoNet;
using BoletosAnfir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosAnfir.Business
{
    public class BoletoBradescoBusiness
    {
        public string GeraHtmlBoleto(BoletoAnfir boleto)
        {
            var boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = 237;

            DateTime vencimento = DateTime.Now.AddDays(5);

            Instrucao_Bradesco item = new Instrucao_Bradesco(9, 5);

            Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "1234", "5", "123456", "7");
            c.Codigo = "13000";

            //Carteiras 
            Boleto b = new Boleto(vencimento, 1.01m, "09", "01000000001", c);
            b.Banco = new Banco(237);
            b.NumeroDocumento = "01000000001";

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            item.Descricao += " após " + item.QuantidadeDias.ToString() + " dias corridos do vencimento.";
            b.Instrucoes.Add(item); //"Não Receber após o vencimento");

            Instrucao i = new Instrucao(237);
            i.Descricao = "Nova Instrução";
            b.Instrucoes.Add(i);

            b.EspecieDocumento = new EspecieDocumento_Bradesco("01");

            /* 
             * A data de vencimento não é usada
             * Usado para mostrar no lugar da data de vencimento o termo "Contra Apresentação";
             * Usado na carteira 06
             */
            boletoBancario.MostrarContraApresentacaoNaDataVencimento = true;

            var valorBoleto = 400;
            var carteira = "1234";
            var numeroDocumento = "12345";

            boletoBancario.Boleto = new Boleto(vencimento, valorBoleto, carteira, numeroDocumento, c);
            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            var html = boletoBancario.MontaHtml();
            html = $"<html><head><meta charset='UTF-8'></head><body><div>{html}</div></body></html>";
            return html;
        }
    }
}
