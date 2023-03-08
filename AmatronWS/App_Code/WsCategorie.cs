using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descrizione di riepilogo per WsCategorie
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WsCategorie : System.Web.Services.WebService
{

    public WsCategorie()
    {

        //Rimuovere il commento dalla riga seguente se si utilizzano componenti progettati 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void CATEGORIE_Insert(string categoria)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spCATEGORIE_Insert";
        DB.cmd.Parameters.AddWithValue("categoria", categoria);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public void CATEGORIE_Update(int chiave, string categoria)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spCATEGORIE_Update";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.cmd.Parameters.AddWithValue("categoria", categoria);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public DataTable CATEGORIE_SelectByKey(int chiave)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCATEGORIE_SelectByKey";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByKey";
        return dt;
    }

    [WebMethod]
    public DataTable CATEGORIE_SelectAll()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCATEGORIE_SelectAll";
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectAll";
        return dt;
    }
}