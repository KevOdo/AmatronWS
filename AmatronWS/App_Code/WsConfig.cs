using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descrizione di riepilogo per WsConfig
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
// [System.Web.Script.Services.ScriptService]
public class WsConfig : System.Web.Services.WebService
{

    public WsConfig()
    {

        //Rimuovere il commento dalla riga seguente se si utilizzano componenti progettati 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void CONFIG_Update(int costoprime, int perc1_10, int perc11_100, int perc101_1000, int perc1001)
    {
        DATABASE DB = new DATABASE();
        DB.cmd.Parameters.Clear();
        DB.query = "spCONFIG_Update";
        DB.cmd.Parameters.AddWithValue("costoprime", costoprime);
        DB.cmd.Parameters.AddWithValue("perc1_10", perc1_10);
        DB.cmd.Parameters.AddWithValue("perc11_100", perc11_100);
        DB.cmd.Parameters.AddWithValue("perc101_1000", perc101_1000);
        DB.cmd.Parameters.AddWithValue("perc1001", perc1001);
        DB.EseguiSPNonRead();
    }

    [WebMethod]
    public DataTable CONFIG_SelectAll()
    {
        DATABASE DB = new DATABASE();
        DataTable dt = new DataTable();
        DB.cmd.Parameters.Clear();
        DB.query = "spCONFIG_SelectAll";       
        dt = DB.EseguiSPRead();
        dt.TableName = "SelectAll";
        return dt;
    }
}