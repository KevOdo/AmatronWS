using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descrizione di riepilogo per WsAmatron
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WsAmatron : System.Web.Services.WebService
{
    public WsAmatron()
    {

        //Rimuovere il commento dalla riga seguente se si utilizzano componenti progettati 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataTable AMATRON_Login(string email, string PWD)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spAMATRON_Login";
        DB.cmd.Parameters.AddWithValue("email", email);
        DB.cmd.Parameters.AddWithValue("PWD", PWD);
        dt = DB.EseguiSPRead();
        dt.TableName = "Login";
        return dt;
    }

    [WebMethod]
    public DataTable AMATRON_GetAnno()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spAMATRON_GetAnno";
        dt = DB.EseguiSPRead();
        dt.TableName = "GetAnno";
        return dt;
    }

    [WebMethod]
    public DataTable AMATRON_IncassiAnnuali()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spAMATRON_IncassiAnnuali";
        dt = DB.EseguiSPRead();
        dt.TableName = "IncassiAnnuali";
        return dt;
    }

    [WebMethod]
    public DataTable AMATRON_IncassiMensiliByAnno(int anno)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spAMATRON_IncassiMensiliByAnno";
        DB.cmd.Parameters.AddWithValue("anno", anno);
        dt = DB.EseguiSPRead();
        dt.TableName = "IncassiMensiliByAnno";
        return dt;
    }

    [WebMethod]
    public DataTable AMATRON_IncassiPerCategoria()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spAMATRON_IncassiMensiliPerCategoria";
        dt = DB.EseguiSPRead();
        dt.TableName = "IncassiMensiliPerCategoria";
        return dt;
    }
    
    [WebMethod]
    public DataTable AMATRON_RESIFILTRA(string nominativo, int numero_ordine, int startdate, int enddate)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spRESI_ORDINI_PRODOTTI_CLIENTI_Filter";
        DB.cmd.Parameters.AddWithValue("nominativo", nominativo);
        DB.cmd.Parameters.AddWithValue("numero_ordine", numero_ordine);
        DB.cmd.Parameters.AddWithValue("startdate", startdate);
        DB.cmd.Parameters.AddWithValue("enddate", enddate);
        dt = DB.EseguiSPRead();
        dt.TableName = "RESIFILTRA";
        return dt;
    }
}
