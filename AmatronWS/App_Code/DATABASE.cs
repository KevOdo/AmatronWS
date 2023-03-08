using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public class DATABASE
{
    //membri della classe che diventano proprietà dell'oggetto
    public string query;
    public SqlConnection conn = new SqlConnection();
    public SqlCommand cmd = new SqlCommand();
    public SqlDataAdapter DA = new SqlDataAdapter();
    public DataTable DT = new DataTable();

    public DATABASE()
    {
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["AMATRONDBConnectionString"].ConnectionString;
        cmd.Connection = conn;
    }
    //carica i dati dal db con una query diretta scritta in sql
    public DataTable EseguiQueryRead()
    {

        cmd.CommandText = query;
        DA.SelectCommand = cmd;
        cmd.CommandType = CommandType.Text;
        DA.Fill(DT);
        return DT;

    }

    //esegue INSERT, DELETE, UPDATE
    public void EseguiQueryNonRead()
    {
        cmd.CommandText = query;
        cmd.CommandType = CommandType.Text;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();

    }
    // eseguo una stored procedure senza ritorno di dati
    public void EseguiSPNonRead()
    {
        cmd.CommandText = query;
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }



    public DataTable EseguiSPRead()
    {
        cmd.CommandText = query;
        cmd.CommandType = CommandType.StoredProcedure;
        DA.SelectCommand = cmd;
        DA.Fill(DT);
        return DT;

    }
}