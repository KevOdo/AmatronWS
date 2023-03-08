using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descrizione di riepilogo per WsCarrello
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WsCarrello : System.Web.Services.WebService
{

    public WsCarrello()
    {

        //Rimuovere il commento dalla riga seguente se si utilizzano componenti progettati 
        //InitializeComponent(); 
    }
    
    [WebMethod]
    public void CARRELLO_Insert(int chiavecliente, int chiaveprodotto, int qta)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spCARRELLO_Insert";
        DB.cmd.Parameters.AddWithValue("chiavecliente", chiavecliente);
        DB.cmd.Parameters.AddWithValue("chiaveprodotto", chiaveprodotto);
        DB.cmd.Parameters.AddWithValue("qta", qta);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public void CARRELLO_Update(int chiave, int qta)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spCARRELLO_Update";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.cmd.Parameters.AddWithValue("qta", qta);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public void CARRELLO_Delete(int chiave)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spCARRELLO_Delete";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public DataTable CARRELLO_SelectByKey(int chiave)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCARRELLO_SelectByKey";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByKey";
        return dt;
    }

    [WebMethod]
    public DataTable CARRELLO_SelectAll()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spVENDITORI_SelectAll";
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectAll";
        return dt;
    }

    [WebMethod]
    public DataTable CARRELLO_SelectByCliente(int chiaveCLIENTE)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCARRELLO_SelectByCliente";
        DB.cmd.Parameters.AddWithValue("chiaveCLIENTE", chiaveCLIENTE);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByCliente";
        return dt;
    }

    [WebMethod]
    public DataTable CARRELLO_SelectByProdotto(int chiavePRODOTTO)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCARRELLO_SelectByProdotto";
        DB.cmd.Parameters.AddWithValue("chiavePRODOTTO", chiavePRODOTTO);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByProdotto";
        return dt;
    }

    [WebMethod]
    public DataTable CARRELLO_SelectAllItemsInCart(int chiaveCLIENTE)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        //messo sp di test, bisogna prenere anche l'immagine da IMMAGINI
        DB.query = "spv_JoinCARRELLO_PRODOTTI_IMMAGINISelectAllItemsInCart";
        DB.cmd.Parameters.AddWithValue("chiaveCLIENTE", chiaveCLIENTE);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectLastItemInCart";
        return dt;
    }

}