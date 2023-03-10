using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descrizione di riepilogo per WsResi
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WsResi : System.Web.Services.WebService
{
    
    public WsResi()
    {

        //Rimuovere il commento dalla riga seguente se si utilizzano componenti progettati 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void Resi_Insert(int chiaveordine, string descrizione, int qtaresa, bool accettazione,string datarichiesta, string dataemissione)
    {
        DATABASE DB = new DATABASE();
        DB.query = "spRESI_Insert";
        DB.cmd.Parameters.AddWithValue("chiaveORDINE", chiaveordine);
        DB.cmd.Parameters.AddWithValue("DESCRIZIONE", descrizione);
        DB.cmd.Parameters.AddWithValue("QTARESA", qtaresa);
        DB.cmd.Parameters.AddWithValue("ACCETTAZIONE", accettazione);
        DB.cmd.Parameters.AddWithValue("DATARICHIESTA", datarichiesta);
        DB.cmd.Parameters.AddWithValue("DATAEMISSIONE", dataemissione);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public void Resi_Update(int chiave, bool accettazione, string dataemissione)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spRESI_Update";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);     
        DB.cmd.Parameters.AddWithValue("ACCETTAZIONE", accettazione);     
        DB.cmd.Parameters.AddWithValue("DATAEMISSIONE", dataemissione);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public DataTable Resi_SelectAll()
    {
        DataTable dt = new DataTable();
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spRESI_SelectAll";
        dt= DB.EseguiSPRead();
        dt.TableName = "SelectAll";
        return dt;
    }

    [WebMethod]
    public DataTable RESI_SelectAll_DDL()
    {
        DataTable dt = new DataTable();
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spRESI_SelectAll_DDL";
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectAllDDL";
        return dt ;
    }
    [WebMethod]
    public DataTable RESI_SelectByKey(int chiave)
    {
        DataTable dt = new DataTable();
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spRESI_SelectByKey";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        dt =  DB.EseguiSPRead();
        dt.TableName = "SelectByKey";
        return dt;
    }

    [WebMethod]
    public DataTable RESI_SelectByOrder(int chiaveordine)
    {
        DataTable dt = new DataTable();
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spRESI_SelectByOrder";
        DB.cmd.Parameters.AddWithValue("chiaveOrdine", chiaveordine);
        dt= DB.EseguiSPRead();
        dt.TableName = "SelectByOrder";
        return dt;
    }
    
    [WebMethod]
    public DataTable RESI_SelectCount(int chiaveordine)
    {
        DataTable dt = new DataTable();
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spRESI_SelectCount";
        DB.cmd.Parameters.AddWithValue("chiaveOrdine", chiaveordine);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectCount";
        return dt;
    }
}
