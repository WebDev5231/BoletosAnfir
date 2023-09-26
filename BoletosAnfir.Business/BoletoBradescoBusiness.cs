using BoletoNet;
using BoletosAnfir.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosAnfir.Business
{
    public class BoletoBradescoBusiness
    {
        public string GeraHtmlBoleto(BoletoAnfir boleto, DadosCedenteBradesco dadosCedente)
        public string GeraHtmlBoleto(BoletoAnfir boleto, DadosCedente dadosCedente)
        {
            var boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = 237;

            var dataVencimento = boleto.Data_Venc;

            Instrucao_Bradesco item = new Instrucao_Bradesco(9, 5);

            Cedente c = new Cedente(dadosCedente.CNPJ, dadosCedente.Empresa, dadosCedente.Agencia, dadosCedente.DigitoAgencia, dadosCedente.NumeroConta, dadosCedente.DigitoConta);
            c.Codigo = "";

            Boleto b = new Boleto(dataVencimento, 1.01m, dadosCedente.NumeroCarteira, boleto.Numero_Doc, c);

            b.Banco = new Banco(237);
            b.NumeroDocumento = boleto.Nosso_Numero;
            b.DataVencimento = dataVencimento;
            b.ValorBoleto = Math.Round(boleto.Valor, 2);
            b.DataDocumento = boleto.Data_Doc;

            b.Sacado = new Sacado(boleto.CNPJ, boleto.Razao);
            b.Sacado.Endereco.End = boleto.Endereco;
            b.Sacado.Endereco.Cidade = boleto.munMUNICIP;
            b.Sacado.Endereco.CEP = boleto.Cep;
            b.Sacado.Endereco.UF = boleto.munEST;

            Instrucao i = new Instrucao(237);

            var dataContribuicao = boleto.Data_Doc;
            i.Descricao = $"CONTRIBUIÇÃO ASSOCIATIVA " + dataContribuicao.ToString("MMMM DE yyyy", new CultureInfo("pt-BR")).ToUpper();

            b.Instrucoes.Add(i);
            b.EspecieDocumento = new EspecieDocumento_Bradesco("01");
            b.Carteira = dadosCedente.NumeroCarteira;
            b.NumeroDocumento = boleto.Nosso_Numero;

            boletoBancario.MostrarContraApresentacaoNaDataVencimento = false;

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            var html = boletoBancario.MontaHtml();
            html = $"<html><head><meta charset='UTF-8'></head><body><div>{html}</div></body></html>";
            return html;
        }
    }
}
