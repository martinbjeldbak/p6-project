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
    private MySqlDataReader dataReader;
    private Simulation si;

    public ObservationSaver(Simulation si) {
      string server = "p6project.cfahefdbp8px.us-west-2.rds.amazonaws.com";
      string dbName = "observations";
      string user = "d601f14";
      string pass = "p6d601f14";

      string connectionString = String.Format("Server={0};" +
        "User={1};Password={2};Database={3};",
        server, user, pass, dbName);
      connection = new MySqlConnection(connectionString);

      this.si = si;

      Initialize();
    }

    /// <summary>
    /// Initialize the simulation instance in the Database.
    /// </summary>
    private void Initialize(){
      Log.Info("Opening DB connection...");
      this.OpenDBConnection();

      Log.Info("Finding corresponding game...");
      gameId = FindGameInDB(si.Game.Name());
      Log.Info("Game id retrieved!");

      Log.Info("Inserting new simulation data...");
      InsertSimulationInDB(gameId, si);
      Log.Info("Simulation data inserted!");

      Log.Info("Closing DB connection...");
      this.CloseDBConnection();
    }

    private void OpenDBConnection(){
      try{
        connection.Open();
      }
      catch (MySqlException e){
        switch (e.Number) {
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

    private void CloseDBConnection(){
      try{
        connection.Close();
      }
      catch(MySqlException e){
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
    /// Inserts a new simulation in the Database.
    /// </summary>
    /// <param name="gameId">Game id.</param>
    /// <param name="si">Simulation.</param>
    private void InsertSimulationInDB(int gameId, Simulation si){
      int ps = si.PopulationSize;
      string mr = si.MutationRate.ToString(System.Globalization.CultureInfo.InvariantCulture);
      string cba = si.CrossoverBredAmount.ToString(System.Globalization.CultureInfo.InvariantCulture);
      string maca = si.MutateAfterCrossoverAmount.ToString(System.Globalization.CultureInfo.InvariantCulture);
      bool uniform = si.AllowUniformCrossover;
      bool singlepoint = si.AllowSinglePointCrossover;
      bool twopoint = si.AllowTwoPointCrossover;
      string saved_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

      // check if simulation is already in database
      query = String.Format("SELECT COUNT(*) FROM observations.game WHERE game_id = '{0}' " 
        + "AND population_size = '{1}' AND mutation_rate = '{2}' AND crossover_breed_amount = '{3}' " 
        + "AND mutate_after_crossover_amount = '{4}' AND uniform_crossover = '{5}' "
        + "AND single_point_crossover = '{6}' AND two_point_crossover = '{7}'"
        , gameId, ps, mr, cba, maca, uniform, singlepoint, twopoint);

      int dbSimCount = 0;
      cmd = new MySqlCommand(query, connection);
      dbSimCount = int.Parse(cmd.ExecuteScalar() + "");

      if(dbSimCount == 1) {
        Log.Info("Simulation already in database..");
        Log.Info("Reusing simulation id..");
        query = String.Format("SELECT id FROM observatinos.simulation WHERE game_id = '{0}' "
        + "AND population_size = '{1}' AND mutation_rate = '{2}' AND crossover_breed_amount = '{3}' "
        + "AND mutate_after_crossover_amount = '{4}' AND uniform_crossover = '{5}' "
        + "AND single_point_crossover = '{6}' AND two_point_crossover = '{7}'"
        , gameId, ps, mr, cba, maca, uniform, singlepoint, twopoint);

        cmd = new MySqlCommand(query, connection);
        dataReader = cmd.ExecuteReader();
        dataReader.Read();
        simId = int.Parse(dataReader["id"] + "");
        Log.Info("Simulation id found: " + simId);
        dataReader.Close();

        InsertPopulationInDB();
      }
      else if(dbSimCount > 1){ //more than one row with same name
        Log.Info("There is more than one simulation entry of a in the table!");
        throw new Exception("There is more than one simulation entry of a in the table!");
      }
      else {
        query = String.Format("INSERT INTO observations.simulation (game_id, population_size,"
        + " mutation_rate, crossover_breed_amount, mutate_after_crossover_amount,"
        + " uniform_crossover, single_point_crossover, two_point_crossover, simulated_at)"
        + " VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')"
        , gameId, ps, mr, cba, maca, uniform, singlepoint, twopoint, saved_at);
        cmd = new MySqlCommand(query, connection);
        cmd.ExecuteNonQuery();

        Log.Info("Retrieving simulation id...");
        simId = cmd.LastInsertedId;

        InsertPopulationInDB();
      }
    }

    /// <summary>
    /// Inserts a new population in Database.
    /// </summary>
    /// <param name="simId">Simulation id.</param>
    /// <param name="p">Population.</param>
    private void InsertPopulationInDB(){
      Population p = si.Population;
      int g = p.Generation;
      string minFit = p.GetWorst().GetFitness().ToString(System.Globalization.CultureInfo.InvariantCulture);
      string meanFit = p.GetMean().GetFitness().ToString(System.Globalization.CultureInfo.InvariantCulture);
      string maxFit = p.GetBest().GetFitness().ToString(System.Globalization.CultureInfo.InvariantCulture);
      string avgFit = p.GetAverage().ToString(System.Globalization.CultureInfo.InvariantCulture);

      query = String.Format("INSERT INTO observations.population (simulation_id,"
        + " generation, min_fitness, max_fitness, avg_fitness, mean_fitness)"
        + " VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
        simId, g, minFit, maxFit, avgFit, meanFit);
      cmd = new MySqlCommand(query, connection);
      cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Finds the game in Database.
    /// If no game exists, it creates a new row with the name of the game.
    /// </summary>
    /// <returns>The id of the game.</returns>
    /// <param name="name">Name of the game.</param>
    private int FindGameInDB(string name){
      int gameId;

      query = "SELECT COUNT(*) FROM observations.game WHERE name = '"
        + name + "'";
      int dbGameCount = 0;
      cmd = new MySqlCommand(query, connection);
      //ExecuteScalar will return one value

      dbGameCount = int.Parse(cmd.ExecuteScalar() + "");


      if(dbGameCount == 1) { //row exists
        Log.Info("Game found. Retrieving id...");
        query = "SELECT id FROM observations.game WHERE name = '"
        + name + "'";

        cmd = new MySqlCommand(query, connection);
        dataReader = cmd.ExecuteReader();
        dataReader.Read();
        gameId = int.Parse(dataReader["id"] + "");
        dataReader.Close();
      }
      else if(dbGameCount > 1) { //more than one row with same name
        Log.Info("There is more than one entry of the game in the table!");
        throw new Exception("There is more than one entry of the game in the table!");
      }
      else { //insert new row
        Log.Info("Inserting new game...");
        query = "INSERT INTO observations.game (name) VALUES('" + name + "')";
        cmd = new MySqlCommand(query, connection);
        cmd.ExecuteNonQuery();
        //get the new id
        Log.Info("New row inserted. Retrieving new id...");
        query = "SELECT id FROM observations.game WHERE name = '" 
          + name + "'";
        cmd = new MySqlCommand(query, connection);
        dataReader = cmd.ExecuteReader();
        dataReader.Read();
        gameId = int.Parse(dataReader["id"] + "");
        dataReader.Close();
      }
      return gameId;
    }
  }
}

