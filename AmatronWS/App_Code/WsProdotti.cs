using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descrizione di riepilogo per WsProdotti
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WsProdotti : System.Web.Services.WebService
{

    public WsProdotti()
    {

        //Rimuovere il commento dalla riga seguente se si utilizzano componenti progettati 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void PRODOTTI_Insert(int chiaveVENDITORE, int chiaveCATEGORIA, string titolo, string descrizione, float prezzo, int qta, string datacaricamento, int percamatron)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spPRODOTTI_Insert";
        DB.cmd.Parameters.AddWithValue("chiaveVENDITORE", chiaveVENDITORE);
        DB.cmd.Parameters.AddWithValue("chiaveCATEGORIA", chiaveCATEGORIA);
        DB.cmd.Parameters.AddWithValue("titolo", titolo);
        DB.cmd.Parameters.AddWithValue("descrizione", descrizione);
        DB.cmd.Parameters.AddWithValue("prezzo", prezzo);
        DB.cmd.Parameters.AddWithValue("qta", qta);
        DB.cmd.Parameters.AddWithValue("DATACARICAMENTO", datacaricamento);
        DB.cmd.Parameters.AddWithValue("percamatron", percamatron);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public void PRODOTTI_Update(int chiave, int chiaveVENDITORE, int chiaveCATEGORIA, string TITOLO, string descrizione, float prezzo, int qta, string datacaricamento, int percamatron)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spPRODOTTI_Update";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.cmd.Parameters.AddWithValue("chiaveVENDITORE", chiaveVENDITORE);
        DB.cmd.Parameters.AddWithValue("chiaveCATEGORIA", chiaveCATEGORIA);
        DB.cmd.Parameters.AddWithValue("TITOLO", TITOLO);
        DB.cmd.Parameters.AddWithValue("descrizione", descrizione);
        DB.cmd.Parameters.AddWithValue("prezzo", prezzo);
        DB.cmd.Parameters.AddWithValue("qta", qta);
        DB.cmd.Parameters.AddWithValue("datacaricamento", datacaricamento);
        DB.cmd.Parameters.AddWithValue("PERCAMATRON", percamatron);
        DB.EseguiSPNonRead();
    }
    [WebMethod]
    public void PRODOTTI_Update_QTA(int chiave, int qta)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spPRODOTTI_Update_QTA";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.cmd.Parameters.AddWithValue("qta", qta);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public void PRODOTTI_Delete(int chiave)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spPRODOTTI_Delete";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public DataTable PRODOTTI_SelectAll()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spPRODOTTI_SelectAll";
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectAll";
        return dt;
    }

    [WebMethod]
    public DataTable PRODOTTI_SelectAll_DDL()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spPRODOTTI_SelectAll_DDL";
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectAll_DDL";
        return dt;
    }

    [WebMethod]
    public DataTable PRODOTTI_SelectByKey(int chiave)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spPRODOTTI_SelectByKey";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectbyKey";
        return dt;
    }

    [WebMethod]
    public DataTable PRODOTTI_SelectByVenditore(int chiaveVENDITORE)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spPRODOTTI_SelectByVenditore";
        DB.cmd.Parameters.AddWithValue("chiaveVENDITORE", chiaveVENDITORE);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectbyVenditore";
        return dt;
    }

    [WebMethod]
    public DataTable PRODOTTI_SelectByCategoria(int chiaveCATEGORIA)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spPRODOTTI_SelectByCategoria";
        DB.cmd.Parameters.AddWithValue("chiaveCATEGORIA", chiaveCATEGORIA);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectbyCategoria";
        return dt;
    }
    [WebMethod]
    public DataTable PRODOTTI_SelectByImmagineVenditore(int chiaveVENDITORE)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spPRODOTTI_SelectByImmagineVenditore";
        DB.cmd.Parameters.AddWithValue("chiaveVENDITORE", chiaveVENDITORE);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectbyImmagineVenditore";
        return dt;
    }

    

    [WebMethod]
    public DataTable PRODOTTI_MAX20Novità()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spPRODOTTI_MAX20Novità";
        dt = DB.EseguiSPRead();
        dt.TableName = "MAX20Novità";
        return dt;
    }

    [WebMethod]
    public DataTable PRODOTTI_MAX20Valutazione()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spPRODOTTI_MAX20Valutazione";
        dt = DB.EseguiSPRead();
        dt.TableName = "MAX20Valutazione";
        return dt;
    }

    [WebMethod]
    public DataTable PRODOTTI_MAX20Venduti()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spPRODOTTI_MAX20Venduti";
        dt = DB.EseguiSPRead();
        dt.TableName = "PRODOTTI_MAX20Venduti";
        return dt;
    }

    [WebMethod]
    public DataTable IMMAGINI_Max20RandomCategoria(int chiaveCATEGORIA)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spIMMAGINI_Max20RandomCategoria";
        DB.cmd.Parameters.AddWithValue("chiaveCATEGORIA", chiaveCATEGORIA);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectImgCategoria";
        return dt;
    }

}