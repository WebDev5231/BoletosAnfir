using BoletosAnfir.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoletosAnfir
{
    public partial class GeraBoleto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["var1"] != null && Request.QueryString["var2"] != null)
                {
                    string numeroDoc = Request.QueryString["var1"];
                    string idEmpresa = Request.QueryString["var2"];

                    var boletoBusiness = new BoletoBusiness();
                    var boletoStream = boletoBusiness.GenerateBoleto(numeroDoc);

                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=boleto.pdf");
                    Response.BinaryWrite(boletoStream.ToArray());
                    Response.End();
                }
                else
                {
                    Response.Write("Parâmetros inválidos.");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Ocorreu um erro " + ex);
            }
        }
    }
}