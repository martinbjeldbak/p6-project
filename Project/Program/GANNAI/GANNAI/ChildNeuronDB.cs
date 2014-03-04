using System;
using System.Data;
using Npgsql;

namespace GANNAI {
  public class ChildNeuronDB {
    private DataSet ds = new DataSet();
    private DataTable dt = new DataTable();


    public ChildNeuronDB() {
      string server = "p6project.cfahefdbp8px.us-west-2.rds.amazonaws.com";
      string port = "5432";
      string dbName = "gannai";
      string user = "d601f14";
      string pass = "p6d601f14";

      string connString = String.Format("Server={0};Port={1};" +
        "User Id={2};Password={3};Database={4};",
        server, port, user, pass, dbName);

      try {
        NpgsqlConnection conn = new NpgsqlConnection(connString);
        conn.Open();

        NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM test", conn);
        NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM test", conn);

        Console.WriteLine(command.ExecuteReader());

        da.Fill(ds, "test");


        foreach(DataRow dr in ds.Tables["test"].Rows) {
          Console.WriteLine(dr["person_id"].ToString());
        }


        Console.WriteLine(dt);

        conn.Close();
      }
      catch(Exception ex) {
        Console.WriteLine(ex.Message);
      }
    }
  }
}

