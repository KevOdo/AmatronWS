using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Services;

/// <summary>
/// Descrizione di riepilogo per WsClienti
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WsClienti : System.Web.Services.WebService
{

    public WsClienti()
    {

        //Rimuovere il commento dalla riga seguente se si utilizzano componenti progettati 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void CLIENTI_Insert(string email, string PWD, bool prime, string scadenzaprime, string cognome, string nome, string indirizzo, string citta, string provincia, string CAP, string telefono)
    {
        DATABASE DB = new DATABASE();      
        DB.cmd.Parameters.Clear();
        DB.query = "spCLIENTI_Insert";
        DB.cmd.Parameters.AddWithValue("email", email);     
        DB.cmd.Parameters.AddWithValue("PWD", PWD);     
        DB.cmd.Parameters.AddWithValue("prime", prime);     
        DB.cmd.Parameters.AddWithValue("scadenzaprime", scadenzaprime);     
        DB.cmd.Parameters.AddWithValue("cognome", cognome);     
        DB.cmd.Parameters.AddWithValue("nome", nome);     
        DB.cmd.Parameters.AddWithValue("indirizzo", indirizzo);     
        DB.cmd.Parameters.AddWithValue("citta", citta);     
        DB.cmd.Parameters.AddWithValue("provincia", provincia);     
        DB.cmd.Parameters.AddWithValue("CAP", CAP);     
        DB.cmd.Parameters.AddWithValue("telefono", telefono);            
        DB.EseguiSPNonRead();       
    }

    [WebMethod]
    public void CLIENTI_Update(int chiave, string email, string PWD,string cognome, string nome, string indirizzo, string citta, string provincia, string CAP, string telefono)
    {
        DATABASE DB = new DATABASE();      
        DB.cmd.Parameters.Clear();
        DB.query = "spCLIENTI_Update";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.cmd.Parameters.AddWithValue("email", email);
        DB.cmd.Parameters.AddWithValue("PWD", PWD);
        DB.cmd.Parameters.AddWithValue("cognome", cognome);
        DB.cmd.Parameters.AddWithValue("nome", nome);
        DB.cmd.Parameters.AddWithValue("indirizzo", indirizzo);
        DB.cmd.Parameters.AddWithValue("citta", citta);
        DB.cmd.Parameters.AddWithValue("provincia", provincia);
        DB.cmd.Parameters.AddWithValue("CAP", CAP);
        DB.cmd.Parameters.AddWithValue("telefono", telefono);
        DB.EseguiSPNonRead();      
    }

    [WebMethod]
    public DataTable CLIENTI_SelectAll()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCLIENTI_SelectAll";
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectAll";
        return dt;
    }
    
    [WebMethod]
    public DataTable CLIENTI_SelectAll_DDL()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCLIENTI_SelectAll_DDL";
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectAll_DDL";
        return dt;
    } 
    
    [WebMethod]
    public DataTable CLIENTI_SelectByKey(int chiave)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCLIENTI_SelectByKey";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectbyKey";
        return dt;
    }

    [WebMethod]
    public DataTable CLIENTI_Login(string email, string PWD)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCLIENTI_Login";
        DB.cmd.Parameters.AddWithValue("email", email);
        DB.cmd.Parameters.AddWithValue("PWD", PWD);
        dt = DB.EseguiSPRead();
        dt.TableName = "Login";
        return dt;
    }
    [WebMethod]
    public void CLIENTI_Prime(int chiave)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spClienti_Prime";
        DB.cmd.Parameters.AddWithValue("chiave", chiave);
        DB.EseguiSPNonRead();
    }
}
