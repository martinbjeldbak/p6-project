using System;
using MySql.Data.MySqlClient;
using Utility;

namespace Genetics {
  public class ObservationSaver {
    private MySqlConnection connection;
    private MySqlCommand cmd;
    private string query;
    private long simId;
    private int gameId;
    private long confId;
    private MySqlDataReader dataReader;
    private Simulation si;

    public ObservationSaver(Simulation si) {
      this.si = si;
      string server = "p6project.cfahefdbp8px.us-west-2.rds.amazonaws.com";
      string dbName = "gannai";
      string user = "d601f14";
      string pass = "p6d601f14";
      string connectionString = String.Format("Server={0};" +
        "User={1};Password={2};Database={3};", server, user, pass, dbName);
      connection = new MySqlConnection(connectionString);

      Initialize();
    }

    /// <summary>
    /// Initialize the simulation instance in the Database.
    /// </summary>
    private void Initialize() {
      Log.Info("Opening DB connection...");
      this.OpenDBConnection();

      Log.Info("Initializing iteration.");
      Log.Info("Finding corresponding game...");
      FindGameInDB(si.Game.Name());
      Log.Info("Game id retrieved!");

      Log.Info("Inserting initial data...");
      InsertConfigurationInDB(si);
      Log.Info("Initial configuration, simulation, and population data inserted!");

      Log.Info("Closing DB connection...");
      this.CloseDBConnection();
    }

    private void OpenDBConnection() {
      try {
        connection.Open();
      }
      catch(MySqlException e) {
        switch(e.Number) {
        case 0: // Cannot connect to server.
          Log.Error(e.Message);
          throw new Exception(e.Message);
        case 1045:// Invalid username/password.
          Log.Error(e.Message);
          throw new Exception(e.Message);
        default:
          Log.Error("Something unexpected went wrong while connecting to DB.");
          throw new Exception("Something unexpected went wrong" +
          " while connecting to DB.");
        }
      }
    }

    private void CloseDBConnection() {
      try {
        connection.Close();
      }
      catch(MySqlException e) {
        Log.Error(e.Message);
        throw new Exception(e.Message);
      }
    }

    /// <summary>
    /// Saves the data of the Population.
    /// </summary>
    public void SavePopulation() {
      Log.Info("Opening DB connection...");
      this.OpenDBConnection();

      Log.Info("Inserting new population data...");
      InsertPopulationInDB();
      Log.Info("Population data inserted!");

      Log.Info("Closing DB connection...");
      this.CloseDBConnection();
    }

    /// <summary>
    /// Insert the simulation in the database.
    /// </summary>
    private void InsertSimulationInDB() {
      string started_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
      query = String.Format("INSERT INTO gannai.simulation (configuration_id, started_at)"
        + " VALUES('{0}', '{1}')", confId, started_at);
      cmd = new MySqlCommand(query, connection);
      Log.Info("Inserting simulation into database.");
      cmd.ExecuteNonQuery();
      Log.Info("Retrieving simulation id...");
      simId = cmd.LastInsertedId;
    }

    /// <summary>
    /// Inserts a new simulation in the Database.
    /// </summary>
    /// <param name="si">A simulation.</param>
    private void InsertConfigurationInDB(Simulation si) {
      int ps = si.PopulationSize;
      string mr = si.MutationRate.ToString(System.Globalization.CultureInfo.InvariantCulture);
      string cba = si.CrossoverBredAmount.ToString(System.Globalization.CultureInfo.InvariantCulture);
      string maca = si.MutateAfterCrossoverAmount.ToString(System.Globalization.CultureInfo.InvariantCulture);
      int uniform = si.AllowUniformCrossover ? 1 : 0;
      int singlepoint = si.AllowSinglePointCrossover ? 1 : 0;
      int twopoint = si.AllowTwoPointCrossover ? 1 : 0;
      int mergetype = si.OffspringMergeType;

      query = String.Format("SELECT COUNT(*) FROM gannai.configuration WHERE game_id = '{0}' "
      + "AND population_size = '{1}' AND mutation_rate = '{2}' AND crossover_breed_amount = '{3}' "
      + "AND mutate_after_crossover_amount = '{4}' AND uniform_crossover = '{5}' "
      + "AND single_point_crossover = '{6}' AND two_point_crossover = '{7}' AND offspring_merge_type = '{8}'"
        , gameId, ps, mr, cba, maca, uniform, singlepoint, twopoint, mergetype);
      cmd = new MySqlCommand(query, connection);
      int dbConfCount = int.Parse(cmd.ExecuteScalar() + "");

      if(dbConfCount == 1) {
        Log.Info("Configuration already in database..");
        Log.Info("Reusing configuration id..");
        query = String.Format("SELECT id FROM gannai.configuration WHERE game_id = '{0}' "
        + "AND population_size = '{1}' AND mutation_rate = '{2}' AND crossover_breed_amount = '{3}' "
        + "AND mutate_after_crossover_amount = '{4}' AND uniform_crossover = '{5}' "
        + "AND single_point_crossover = '{6}' AND two_point_crossover = '{7}' AND offspring_merge_type = '{8}'"
        , gameId, ps, mr, cba, maca, uniform, singlepoint, twopoint, mergetype);

        cmd = new MySqlCommand(query, connection);
        dataReader = cmd.ExecuteReader();
        dataReader.Read();
        confId = int.Parse(dataReader["id"] + "");
        Log.Info("Configuration id found: " + confId);
        dataReader.Close();
      }
      else if(dbConfCount > 1) { //more than one row with same name
        Log.Error("There is more than one configuration entry of a in the table!");
        throw new Exception("There is more than one configuration entry of a in the table!");
      }
      else {
        query = String.Format("INSERT INTO gannai.configuration (game_id, population_size,"
        + " mutation_rate, crossover_breed_amount, mutate_after_crossover_amount,"
        + " uniform_crossover, single_point_crossover, two_point_crossover, offspring_merge_type)"
        + " VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')"
          , gameId, ps, mr, cba, maca, uniform, singlepoint, twopoint, mergetype);
        cmd = new MySqlCommand(query, connection);
        cmd.ExecuteNonQuery();
        Log.Info("Retrieving configuration id...");
        confId = cmd.LastInsertedId;
      }
      InsertSimulationInDB();
      InsertPopulationInDB();
    }

    /// <summary>
    /// Inserts a new population in Database.
    /// </summary>
    /// <param name="simId">Simulation id.</param>
    /// <param name="p">Population.</param>
    private void InsertPopulationInDB() {
      Population p = si.Population;
      int g = p.Generation;
      string minFit = p.GetWorst().GetFitness().ToString(System.Globalization.CultureInfo.InvariantCulture);
      string meanFit = p.GetMean().GetFitness().ToString(System.Globalization.CultureInfo.InvariantCulture);
      string maxFit = p.GetBest().GetFitness().ToString(System.Globalization.CultureInfo.InvariantCulture);
      string avgFit = p.GetAverage().ToString(System.Globalization.CultureInfo.InvariantCulture);
      string simulated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

      query = String.Format("INSERT INTO gannai.population (simulation_id,"
        + " generation, min_fitness, max_fitness, avg_fitness, mean_fitness, simulated_at)"
        + " VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
        simId, g, minFit, maxFit, avgFit, meanFit, simulated_at);
      cmd = new MySqlCommand(query, connection);
      cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Finds the game in Database.
    /// If no game exists, it creates a new row with the name of the game.
    /// </summary>
    /// <returns>The id of the game.</returns>
    /// <param name="name">Name of the game.</param>
    private void FindGameInDB(string name) {
      query = "SELECT COUNT(*) FROM gannai.game WHERE name = '" + name + "'";
      cmd = new MySqlCommand(query, connection);
      int dbGameCount = int.Parse(cmd.ExecuteScalar() + "");

      if(dbGameCount == 1) {
        Log.Info("Game found. Retrieving id...");
        query = "SELECT id FROM gannai.game WHERE name = '" + name + "'";
        cmd = new MySqlCommand(query, connection);
        dataReader = cmd.ExecuteReader();
        dataReader.Read();
        gameId = int.Parse(dataReader["id"] + "");
        dataReader.Close();
      }
      else if(dbGameCount > 1) { 
        Log.Info("There is more than one entry of the game in the table!");
        throw new Exception("There is more than one entry of the game in the table!");
      }
      else {
        Log.Info("Inserting new game...");
        query = "INSERT INTO gannai.game (name) VALUES('" + name + "')";
        cmd = new MySqlCommand(query, connection);
        cmd.ExecuteNonQuery();
        Log.Info("New row inserted. Retrieving new id...");
        query = "SELECT id FROM gannai.game WHERE name = '" + name + "'";
        cmd = new MySqlCommand(query, connection);
        dataReader = cmd.ExecuteReader();
        dataReader.Read();
        gameId = int.Parse(dataReader["id"] + "");
        dataReader.Close();
      }
    }
  }
}

