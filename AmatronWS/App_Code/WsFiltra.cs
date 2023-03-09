using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descrizione di riepilogo per WsFiltra
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WsFiltra : System.Web.Services.WebService
{

    public WsFiltra()
    {
        //Rimuovere il commento dalla riga seguente se si utilizzano componenti progettati 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataTable FILTRA(string c, string p)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spFILTRA";
        DB.cmd.Parameters.AddWithValue("c", c);
        DB.cmd.Parameters.AddWithValue("p", p);
        dt = DB.EseguiSPRead();
        dt.TableName = "searchTerm";
        return dt;
    }

    [WebMethod]
    public DataTable FILTRA_Corrieri(string CORRIERI)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spFILTRA_Corrieri";
        DB.cmd.Parameters.AddWithValue("CORRIERI", CORRIERI);
        dt = DB.EseguiSPRead();
        dt.TableName = "FiltraCorrieri";
        return dt;
    }

    [WebMethod]
    public DataTable FILTRA_Venditori(string VENDITORI)
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spFILTRA_Venditori";
        DB.cmd.Parameters.AddWithValue("VENDITORI", VENDITORI);
        dt = DB.EseguiSPRead();
        dt.TableName = "FiltraVenditori";
        return dt;
    }
}
