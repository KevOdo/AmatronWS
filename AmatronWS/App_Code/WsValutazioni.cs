using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Services;

/// <summary>
/// Descrizione di riepilogo per WsValutazioni
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WsValutazioni : System.Web.Services.WebService
{

    public WsValutazioni()
    {

        //Rimuovere il commento dalla riga seguente se si utilizzano componenti progettati 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void VALUTAZIONI_Insert(int chiaveprodotto, int stelle, string commento, string datacommento)
    {
        DATABASE DB = new DATABASE();
        DB.query = "spVALUTAZIONI_Insert";
        DB.cmd.Parameters.AddWithValue("chiavePRODOTTO", chiaveprodotto);
        DB.cmd.Parameters.AddWithValue("STELLE", stelle);
        DB.cmd.Parameters.AddWithValue("COMMENTO", commento);
        DB.cmd.Parameters.AddWithValue("DATACOMMENTO", datacommento);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public DataTable VALUTAZIONI_SelectAll()
    {
        DataTable dt = new DataTable();
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spVALUTAZIONI_SelectAll";
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByAll";
        return dt;
    }

    [WebMethod]
    public DataTable VALUTAZIONI_SelectAll_DDL()
    {
        DataTable dt = new DataTable();
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spVALUTAZIONI_SelectAll_DDL";
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByAllDDL";
        return dt;
    }

    [WebMethod]
    public DataTable VALUTAZIONI_SelectByKey(int chiave)
    {
        DataTable dt = new DataTable();
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spVALUTAZIONI_SelectByKey";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        dt = DB.EseguiSPRead();
        dt.TableName = "ValutazioniSelectByKey";
        return dt;
    }

    [WebMethod]
    public DataTable VALUTAZIONI_SelectByProdotto(int chiaveprodotto)
    {
        DataTable dt = new DataTable();
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spVALUTAZIONI_SelectByProdotto";
        DB.cmd.Parameters.AddWithValue("chiavePRODOTTO", chiaveprodotto);      
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByProdotto";
        return dt;
    }

    [WebMethod]
    public DataTable VALUTAZIONI_Media(int chiaveprodotto)
    {
        DataTable dt = new DataTable();       
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spVALUTAZIONI_Media";         
        DB.cmd.Parameters.AddWithValue("chiavePRODOTTO", chiaveprodotto);
        dt = DB.EseguiSPRead();
        dt.TableName = "MediaValutazioni";
        return dt;
    }
}