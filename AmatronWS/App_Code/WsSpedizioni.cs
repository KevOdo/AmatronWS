using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descrizione di riepilogo per WsSpedizioni
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WsSpedizioni : System.Web.Services.WebService
{

    public WsSpedizioni()
    {

        //Rimuovere il commento dalla riga seguente se si utilizzano componenti progettati 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void SPEDIZIONI_Insert(int chiaveOrdine, string stato, string dataora)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spSPEDIZIONI_Insert";  
        DB.cmd.Parameters.AddWithValue("chiaveOrdine", chiaveOrdine);     
        DB.cmd.Parameters.AddWithValue("stato", stato);     
        DB.cmd.Parameters.AddWithValue("dataora", dataora);     
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public DataTable SPEDIZIONI_SelectAll()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spSPEDIZIONI_SelectAll";
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectAll";
        return dt;
    }

    [WebMethod]
    public DataTable SPEDIZIONI_SelectByKey(int chiave)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spSPEDIZIONI_SelectByKey";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByKey";
        return dt;
    }
    
    [WebMethod]
    public DataTable SPEDIZIONI_SelectByOrdine(int chiave)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spSPEDIZIONI_SelectByOrdine";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByOrdine";
        return dt;
    }

    [WebMethod]
    public void SPEDIZIONI_UpdateStato(int chiave, string STATO)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spSPEDIZIONI_UpdateStato";
        DB.cmd.Parameters.AddWithValue("chiaveSPEDIZIONE", chiave);
        DB.cmd.Parameters.AddWithValue("STATOSPEDIZIONE", STATO);
        DB.EseguiSPNonRead();
    }
}
