using BoletosAnfir.Data;
using BoletosAnfir.Model;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosAnfir.Business
{
    public class BoletoBusiness
    {
        public MemoryStream GenerateBoleto(string numeroDoc)
        {
            try
            {
                var boletoData = new BoletoData();
                var numeroDocucumento = numeroDoc;
                var boletoAnfir = boletoData.GetBoleto(numeroDocucumento);

                if (boletoAnfir != null)
                {
                    if (boletoAnfir.situacao == "E")
                    {
                        var boletoBancoDoBrasilBusiness = new BoletoBancoDoBrasilBusiness();
                        var dadosCedente = new DadosCedenteBB();
                        var dadosCedente = new DadosCedente();
                        var html = boletoBancoDoBrasilBusiness.GeraHtmlBoleto(boletoAnfir, dadosCedente);
                        var stream = ConvertePdf(html, boletoAnfir);
                        return stream;
                    }
                    else if (boletoAnfir.situacao == "A")
                    {
                        var boletoBradescoBusiness = new BoletoBradescoBusiness();
                        var dadosCedente = new DadosCedenteBradesco();
                        var dadosCedente = new DadosCedente();
                        var html = boletoBradescoBusiness.GeraHtmlBoleto(boletoAnfir, dadosCedente);
                        var stream = ConvertePdf(html, boletoAnfir);
                        return stream;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private MemoryStream ConvertePdf(string html, BoletoAnfir boletoAnfir)
        {
            var converter = new HtmlToPdf();
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;

            var doc = converter.ConvertHtmlString(html);

            var passwordPdf = boletoAnfir.CNPJ.Replace(".", "").Substring(0, 4);

            doc.Security.OwnerPassword = "Anfir306@#";
            doc.Security.UserPassword = passwordPdf;
            doc.Security.CanAssembleDocument = false;
            doc.Security.CanCopyContent = true;
            doc.Security.CanEditAnnotations = true;
            doc.Security.CanEditContent = true;
            doc.Security.CanFillFormFields = true;
            doc.Security.CanPrint = true;

            // Salvar o conteúdo PDF em um MemoryStream
            var stream = new MemoryStream();
            doc.Save(stream);
            doc.Close();

            return stream;
        }
    }
}
