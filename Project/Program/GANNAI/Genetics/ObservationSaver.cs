﻿using System;
using MySql.Data.MySqlClient;

namespace Genetics {
  public class ObservationSaver {
    private MySqlConnection connection;
    private MySqlCommand cmd;
    private string query;
    private MySqlDataReader dataReader;

    public ObservationSaver() {
      string server = "p6project.cfahefdbp8px.us-west-2.rds.amazonaws.com";
      string port = "3306";
      string dbName = "observation";
      string user = "d601f14";
      string pass = "p6d601f14";

      string connectionString = String.Format("Server={0};" +
        "User={1};Password={2};Database={3};",
        server, port, user, pass, dbName);
      connection = new MySqlConnection(connectionString);
    }

    private void OpenDBConnection(){
      try{
        connection.Open();
      }
      catch (MySqlException e){
        switch (e.Number) {
        case 0: // Cannot connect to server.
          throw new Exception(e.Message);
        case 1045:// Invalid username/password.
          throw new Exception(e.Message);
        default:
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
        throw new Exception(e.Message);
      }
    }

    /// <summary>
    /// Saves the data of the entire simulation.
    /// </summary>
    /// <param name="si">The simulation.</param>
    public void SaveSimulation(Simulation si) {
      Console.WriteLine("Finding corresponding game...");
      int gameId = FindGameInDB(si.Game.Name());
      Console.WriteLine("Game id retrieved!");

      Console.WriteLine("Inserting new simulation data...");
      InsertSimulationInDB(gameId, si);
      Console.WriteLine("Simulation data inserted!");

      Console.WriteLine("Retrieving population id...");
      long simId = cmd.LastInsertedId;

      Console.WriteLine("Inserting new population data...");
      InsertPopulationInDB(simId, si.Population);
      Console.WriteLine("Population data inserted!");

      Console.WriteLine("Closing DB connection...");
      this.CloseDBConnection();
    }

    /// <summary>
    /// Inserts a new simulation in the Database.
    /// </summary>
    /// <param name="gameId">Game id.</param>
    /// <param name="si">Simulation.</param>
    private void InsertSimulationInDB(int gameId, Simulation si){
      int ps = si.PopulationSize;
      double mr = si.MutationRate;
      double cba = si.CrossoverBredAmount;
      double maca = si.MutateAfterCrossoverAmount;
      bool uniform = si.AllowUniformCrossover;
      bool singlepoint = si.AllowSinglePointCrossover;
      bool twopoint = si.AllowTwoPointCrossover;

      query = String.Format("INSERT INTO simulation (game_id, population_size,"
        + " mutation_rate, crossover_breed_amount, mutate_after_crossover_amount,"
        + " uniform_crossover, single_point_crossover, two_point_crossover)"
        + " VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')"
        + " IN observations"
        , gameId, ps, mr, cba, maca, uniform, singlepoint, twopoint);
      cmd = new MySqlCommand(query, connection);
      cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Inserts a new population in Database.
    /// </summary>
    /// <param name="simId">Simulation id.</param>
    /// <param name="p">Population.</param>
    private void InsertPopulationInDB(long simId, Population p){
      int g = p.Generation;
      double minFit = p.GetWorst().GetFitness();
      double meanFit = p.GetMean().GetFitness();
      double maxFit = p.GetBest().GetFitness();
      double avgFit = p.GetAverage();

      query = String.Format("INSERT INTO simulation (simulation_id,"
        + " generation, min_fitness, max_fitness, avg_fitness, mean_fitness)"
        + " VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')"
        + " IN observations"
        , simId, g, minFit, maxFit, avgFit, meanFit);
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
      query = "SELECT COUNT(*) FROM game WHERE name = " 
        + name + " IN observations";
      int dbGameCount = 0;
      this.OpenDBConnection();
      cmd = new MySqlCommand(query, connection);
      //ExecuteScalar will return one value
      dbGameCount = int.Parse(cmd.ExecuteScalar() + "");

      if(dbGameCount == 1){ //row exists
        Console.WriteLine("Game found. Retrieving id...");
        query = "SELECT id FROM game WHERE name = " 
          + name + " IN observations";
        cmd = new MySqlCommand(query, connection);
        dataReader = cmd.ExecuteReader();
        dataReader.Read();
        gameId = int.Parse(dataReader["id"] + "");
        dataReader.Close();
      }
      else if(dbGameCount > 1) //more than one row with same name
        throw new Exception("There is more than one entry of the game in the table!");
      else { //insert new row
        Console.WriteLine("Inserting new game...");
        query = "INSERT INTO game (name) VALUES('" + name + "') IN observations";
        cmd = new MySqlCommand(query, connection);
        cmd.ExecuteNonQuery();
        //get the new id
        Console.WriteLine("New row inserted. Retrieving new id...");
        query = "SELECT id FROM game WHERE name = " 
          + name + " IN observations";
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

