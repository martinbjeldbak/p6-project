using System;
using Simple.Data;

namespace GANNAI {
  public class ObservationSaver {
    private Database db;

    public ObservationSaver() {
      string server = "p6project.cfahefdbp8px.us-west-2.rds.amazonaws.com";
      string port = "3306";
      string dbName = "observation";
      string user = "d601f14";
      string pass = "p6d601f14";

      string connString = String.Format("Server={0}" +
        "User={1};Password={2};Database={3};",
        server, port, user, pass, dbName);

      db = Database.OpenConnection(connString);
    }

    public void SaveSimulation(Simulation) {
    }
  }
}

