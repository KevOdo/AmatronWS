using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descrizione di riepilogo per WsOrdini
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WsOrdini : System.Web.Services.WebService
{

    public WsOrdini()
    {

        //Rimuovere il commento dalla riga seguente se si utilizzano componenti progettati 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void ORDINI_Insert(int chiavecorriere, int chiaveprodotto, int chiavecliente, string datatransazione, int qta, int numeroordine)
    {
        DATABASE DB = new DATABASE();
        DB.query = "spORDINI_Insert";
        DB.cmd.Parameters.AddWithValue("chiaveCORRIERE", chiavecorriere);
        DB.cmd.Parameters.AddWithValue("chiavePRODOTTO", chiaveprodotto);
        DB.cmd.Parameters.AddWithValue("chiaveCLIENTE", chiavecliente);
        DB.cmd.Parameters.AddWithValue("DATATRANSAZIONE", datatransazione);
        DB.cmd.Parameters.AddWithValue("QTA", qta);
        DB.cmd.Parameters.AddWithValue("NUMEROORDINE", numeroordine);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public void ORDINI_Update(int chiave, string datatransazione, int qta, int numeroordine)
    {
        DATABASE DB = new DATABASE();
        DB.query = "spORDINI_Update";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.cmd.Parameters.AddWithValue("DATATRANSAZIONE", datatransazione);
        DB.cmd.Parameters.AddWithValue("QTA", qta);
        DB.cmd.Parameters.AddWithValue("NUMEROORDINE", numeroordine);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public DataTable ORDINI_SelectAll()
    {
        DataTable dt = new DataTable();
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spORDINI_SelectAll";
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByAll";
        return dt;
    }

    [WebMethod]
    public DataTable ORDINI_SelectByKey(int chiave)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spORDINI_SelectByKey";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByKey";
        return dt;
    }

    [WebMethod]
    public DataTable ORDINI_SelectByCorriere(int chiavecorriere)
    {
        DataTable dt = new DataTable();
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spORDINI_SelectByCorriere";
        dt.TableName = "SelectByCorriere";
        DB.cmd.Parameters.AddWithValue("chiaveCORRIERE", chiavecorriere);
        // DB.cmd.Parameters.AddWithValue();
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByCorriere";
        return dt;
    }

    [WebMethod]
    public DataTable ORDINI_SelectByProdotto(int chiaveprodotto)
    {
        DataTable dt = new DataTable();
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spORDINI_SelectByProdotto";
        DB.cmd.Parameters.AddWithValue("chiavePRODOTTO", chiaveprodotto);
        // DB.cmd.Parameters.AddWithValue();
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByProdotto";
        return dt;
    }

    [WebMethod]
    public DataTable ORDINI_SelectByCliente(int chiavecliente)
    {
        DataTable dt = new DataTable();
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spORDINI_SelectByCliente";
        DB.cmd.Parameters.AddWithValue("chiaveCLIENTE", chiavecliente);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByKey";
        return dt;
    }

    [WebMethod]
    public void ORDINI_Delete(int chiave)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spORDINI_Delete";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.EseguiSPNonRead();
    }

    /// WebMethod creato per l'accettazione dell'ordine (George D.)
    [WebMethod]
    public void ORDINI_GESTITO(int chiave, int chiaveCorriere, bool gestito)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spORDINI_GESTITO";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.cmd.Parameters.AddWithValue("chiaveCORRIERE", chiaveCorriere);
        DB.cmd.Parameters.AddWithValue("GESTITO", gestito);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public DataTable ORDINI_GESTISCI()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spORDINI_GESTISCI";
        dt = DB.EseguiSPRead();
        dt.TableName = "OrdiniGestisci";
        return dt;
    }

    [WebMethod]
    public DataTable CLIENTI_ProdottoAcquistato(int chiaveProdotto, int chiaveCliente)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCLIENTI_ProdottoAcquistato";
        DB.cmd.Parameters.AddWithValue("chiaveProdotto", chiaveProdotto);
        DB.cmd.Parameters.AddWithValue("chiaveCliente", chiaveCliente);
        dt = DB.EseguiSPRead();
        dt.TableName = "ProdottoAcquistato";
        return dt;
    }

    [WebMethod]
    public DataTable CORRIERI_CHIAVERandom()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCORRIERI_CHIAVERandom";
        dt = DB.EseguiSPRead();
        dt.TableName = "CORRIERI_CHIAVERandom";
        return dt;
    }

    [WebMethod]
    public DataTable ORDINI_SelectOrdineCliente(int chiaveCliente)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spORDINI_SelectOrdineCliente";
        DB.cmd.Parameters.AddWithValue("chiaveCliente", chiaveCliente);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectOrdineCliente";
        return dt;
    }
}
