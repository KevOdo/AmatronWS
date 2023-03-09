using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descrizione di riepilogo per WSLogin
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WSLogin : System.Web.Services.WebService
{

    public WSLogin()
    {

    }

    [WebMethod]
    public DataTable Login(string EMAIL, string PWD)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spLOGIN";
        DB.cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
        DB.cmd.Parameters.AddWithValue("@PWD", PWD);
        DataTable DT = DB.EseguiSPRead();
        DT.TableName = "LoginResponse";
        return DT;
    }

    [WebMethod]
    public DataTable RECUPERAPWD(string EMAIL)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spRECUPERAPWD";
        DB.cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
        DataTable DT = DB.EseguiSPRead();
        DT.TableName = "RecuperaPwd";
        return DT;
    }

}
