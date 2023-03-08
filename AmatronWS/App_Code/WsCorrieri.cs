using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descrizione di riepilogo per WsCorrieri
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WsCorrieri : System.Web.Services.WebService
{

    public WsCorrieri()
    {

        //Rimuovere il commento dalla riga seguente se si utilizzano componenti progettati 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void CORRIERI_Insert(string email, string PWD, bool abilitato, float costocorriere, string ragionesociale, string piva, string indirizzo, string citta, string provincia, string CAP, string telefono)
    {
        DATABASE DB = new DATABASE();
        DB.query = "spCORRIERI_Insert";
        DB.cmd.Parameters.Clear();
        DB.cmd.Parameters.AddWithValue("email", email);     
        DB.cmd.Parameters.AddWithValue("PWD", PWD);     
        DB.cmd.Parameters.AddWithValue("abilitato", abilitato);     
        DB.cmd.Parameters.AddWithValue("costocorriere", costocorriere);     
        DB.cmd.Parameters.AddWithValue("ragionesociale", ragionesociale);     
        DB.cmd.Parameters.AddWithValue("piva", piva);     
        DB.cmd.Parameters.AddWithValue("indirizzo", indirizzo);     
        DB.cmd.Parameters.AddWithValue("citta", citta);     
        DB.cmd.Parameters.AddWithValue("provincia", provincia);     
        DB.cmd.Parameters.AddWithValue("CAP", CAP);     
        DB.cmd.Parameters.AddWithValue("telefono", telefono);     
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public void CORRIERI_Update(int chiave, string email, string PWD, bool abilitato, float costocorriere, string ragionesociale, string piva, string indirizzo, string citta, string provincia, string CAP, string telefono)
    {
        DATABASE DB = new DATABASE();
        DB.query = "spCORRIERI_Update";
        DB.cmd.Parameters.Clear();
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.cmd.Parameters.AddWithValue("email", email);
        DB.cmd.Parameters.AddWithValue("PWD", PWD);
        DB.cmd.Parameters.AddWithValue("abilitato", abilitato);
        DB.cmd.Parameters.AddWithValue("costocorriere", costocorriere);
        DB.cmd.Parameters.AddWithValue("ragionesociale", ragionesociale);
        DB.cmd.Parameters.AddWithValue("piva", piva);
        DB.cmd.Parameters.AddWithValue("indirizzo", indirizzo);
        DB.cmd.Parameters.AddWithValue("citta", citta);
        DB.cmd.Parameters.AddWithValue("provincia", provincia);
        DB.cmd.Parameters.AddWithValue("CAP", CAP);
        DB.cmd.Parameters.AddWithValue("telefono", telefono);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public DataTable CORRIERI_SelectAll()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCORRIERI_SelectAll";
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectAll";
        return dt;
    }

    [WebMethod]
    public DataTable CORRIERI_SelectAll_DDL()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCORRIERI_SelectAll_DDL";
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectAll_DDL";
        return dt;
    }

    [WebMethod]
    public DataTable CORRIERI_SelectByKey(int chiave)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCORRIERI_SelectByKey";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectByKey";
        return dt;
    }

    [WebMethod]
    public DataTable CORRIERI_Login(string email, string PWD)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCORRIERI_Login";
        DB.cmd.Parameters.AddWithValue("email", email);
        DB.cmd.Parameters.AddWithValue("PWD", PWD);
        dt = DB.EseguiSPRead();
        dt.TableName = "Login";
        return dt;
    }

    [WebMethod]
    public void CORRIERI_Abilita(int chiave)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spCORRIERI_Abilita";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public DataTable CORRIERI_CountSPEDIZIONI(int chiave, int anno, int mese)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCORRIERI_CountSPEDIZIONI";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.cmd.Parameters.AddWithValue("anno", anno);
        DB.cmd.Parameters.AddWithValue("mese", mese);
        dt = DB.EseguiSPRead();
        dt.TableName = "TotaleRicaviCorriere";
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
}
