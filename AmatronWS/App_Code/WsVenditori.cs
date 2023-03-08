using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descrizione di riepilogo per WsVenditori
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WsVenditori : System.Web.Services.WebService
{

    public WsVenditori()
    {

        //Rimuovere il commento dalla riga seguente se si utilizzano componenti progettati 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void VENDITORI_Insert(string ragionesociale, string piva, string indirizzo, string provincia, string citta, string CAP, string telefono, string email, string PWD, bool abilitato)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spVENDITORI_Insert";
        DB.cmd.Parameters.AddWithValue("ragionesociale", ragionesociale);     
        DB.cmd.Parameters.AddWithValue("piva", piva);     
        DB.cmd.Parameters.AddWithValue("indirizzo", indirizzo);     
        DB.cmd.Parameters.AddWithValue("provincia", provincia);     
        DB.cmd.Parameters.AddWithValue("citta", citta);     
        DB.cmd.Parameters.AddWithValue("CAP", CAP);     
        DB.cmd.Parameters.AddWithValue("telefono", telefono);     
        DB.cmd.Parameters.AddWithValue("email", email);     
        DB.cmd.Parameters.AddWithValue("PWD", PWD);     
        DB.cmd.Parameters.AddWithValue("abilitato", abilitato);     
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public void VENDITORI_Update(int chiave, string ragionesociale, string piva, string indirizzo, string provincia, string citta, string CAP, string telefono, string email, string PWD, bool abilitato)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spVENDITORI_Update";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.cmd.Parameters.AddWithValue("ragionesociale", ragionesociale);
        DB.cmd.Parameters.AddWithValue("piva", piva);
        DB.cmd.Parameters.AddWithValue("indirizzo", indirizzo);
        DB.cmd.Parameters.AddWithValue("provincia", provincia);
        DB.cmd.Parameters.AddWithValue("citta", citta);
        DB.cmd.Parameters.AddWithValue("CAP", CAP);
        DB.cmd.Parameters.AddWithValue("telefono", telefono);
        DB.cmd.Parameters.AddWithValue("email", email);
        DB.cmd.Parameters.AddWithValue("PWD", PWD);
        DB.cmd.Parameters.AddWithValue("abilitato", abilitato);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public DataTable VENDITORI_SelectAll()
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
    public DataTable VENDITORI_SelectAll_DDL()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spVENDITORI_SelectAll_DDL";
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectAll_DDL";
        return dt;
    }

    [WebMethod]
    public DataTable VENDITORI_SelectByKey(int chiave)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spVENDITORI_SelectByKey";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectbyKey";
        return dt;
    }

    [WebMethod]
    public DataTable VENDITORI_Login(string email, string PWD)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spVENDITORI_Login";
        DB.cmd.Parameters.AddWithValue("email", email);
        DB.cmd.Parameters.AddWithValue("PWD", PWD);
        dt = DB.EseguiSPRead();
        dt.TableName = "Login";
        return dt;
    }

    [WebMethod]
    public void VENDITORI_Abilita(int chiave)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spVENDITORI_Abilita";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public DataTable VENDITORI_ORDINI_SelectAll(int chiave)
    {
        DataTable DT = new DataTable();
        DATABASE D = new DATABASE();
        D.cmd.Parameters.Clear();
        D.query = "spORDINI_PRODOTTI_CATEGORIA_SelectByVenditore";
        D.cmd.Parameters.AddWithValue("chiaveVENDITORE", chiave);
        DT = D.EseguiSPRead();
        DT.TableName = "VOSelectAll";
        return DT;
    }

    [WebMethod]
    public DataTable VENDITORI_ORDINI_Filter(int chiave, string TITOLO, int chiaveCATEGORIA, int chiaveORDINI, string DInizio, string DFine)
    {
        DataTable DT = new DataTable();
        DATABASE D = new DATABASE();
        D.cmd.Parameters.Clear();
        D.query = "spORDINI_PRODOTTI_CATEGORIA_Filter";
        D.cmd.Parameters.AddWithValue("TITOLO", TITOLO);
        D.cmd.Parameters.AddWithValue("chiaveORDINI", chiaveORDINI);
        D.cmd.Parameters.AddWithValue("chiaveCATEGORIA", chiaveCATEGORIA);
        D.cmd.Parameters.AddWithValue("chiaveVENDITORE", chiave);

        if (string.IsNullOrWhiteSpace(DInizio))
        {
            D.cmd.Parameters.AddWithValue("STARTDATE", DBNull.Value);
        }
        else
        {
            D.cmd.Parameters.AddWithValue("STARTDATE", DateTime.Parse(DInizio));
        }
        if (string.IsNullOrWhiteSpace(DFine))
        {
            D.cmd.Parameters.AddWithValue("ENDDATE", DBNull.Value);
        }
        else
        {
            D.cmd.Parameters.AddWithValue("ENDDATE", DateTime.Parse(DFine));
        }

        DT = D.EseguiSPRead();
        DT.TableName = "VOFilter";
        return DT;
    }
}
