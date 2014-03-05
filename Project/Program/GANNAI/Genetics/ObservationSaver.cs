using System;
using Simple.Data;

namespace Genetics {
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

    public void SaveSimulation(Simulation si) {
      // Simulation information to be saved
      int ps = si.PopulationSize;
      int mr = si.MutationRate;
      int cba = si.CrossoverBredAmount;
      int maca = si.MutateAfterCrossoverAmount;
      bool uniform = si.AllowUniformCrossover;
      bool singlepoint = si.AllowSinglePointCrossover;
      bool twopoint = si.AllowTwoPointCrossover;

      // Population information to be saved
      Population p = si.Population;
      int g = p.Generation;
      int minFit = p.GetWorst().GetFitness();
      int meanFit = p.GetMean().GetFitness();
      int maxFit = p.GetBest().GetFitness();
      double avgFit = p.GetAverage();

      // Game information to be saved
      string name = si.Game.Name();
    }
  }
}

