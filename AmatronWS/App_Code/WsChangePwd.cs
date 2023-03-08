using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Webmethod per il cambio password generico per tutti i tipi di utenti
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WsChangePwd : System.Web.Services.WebService
{

    public WsChangePwd()
    {

        //Rimuovere il commento dalla riga seguente se si utilizzano componenti progettati 
        //InitializeComponent(); 
    }

    [WebMethod]

    public void ChangePwd(string EMAIL, string TIPO, string PWD)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spCHANGEPWD";
        DB.cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
        DB.cmd.Parameters.AddWithValue("@TIPO", TIPO);
        DB.cmd.Parameters.AddWithValue("@PWD", PWD);
        DB.EseguiSPNonRead();
    }

}
