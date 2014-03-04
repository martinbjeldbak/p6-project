using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GANNAI;

namespace Genetics {
  public class Simulation {

    public int Generation { get; private set; }
    public int PopulationSize;

    /// <summary>
    /// The chance of each single bit to be inverted when mutating a DNA string
    /// </summary>
    public double MutationRate;

    /// <summary>
    /// The fraction of newly breeded individuals that should be bred from crossover. The remaining amount will be bred from mutation
    /// </summary>
    public double CrossoverBredAmount;

    /// <summary>
    /// The fraction of newly breeded individuals from crossover, that should also be mutated
    /// </summary>
    public double MutateAfterCrossoverAmount;

    public bool AllowUniformCrossover {
      get {
        return IsCrossoverMethodAllowed(AIPlayer.GetUniformCrossover);
      }
      set{
          AllowCrossoverMethod(AIPlayer.GetUniformCrossover, value);
        }
    }
    public bool AllowSinglePointCrossover {
      get {
        return IsCrossoverMethodAllowed(AIPlayer.GetSinglePointCrossover);
      }
      set{
          AllowCrossoverMethod(AIPlayer.GetSinglePointCrossover, value);
        }
    }
    public bool AllowTwoPointCrossover {
      get {
        return IsCrossoverMethodAllowed(AIPlayer.GetTwoPointCrossover);
      }
      set {
        AllowCrossoverMethod(AIPlayer.GetTwoPointCrossover, value);
      }
    }

    /// <summary>
    /// A list of all allowed crossover methods. Changing the Configuration will automatically change the list content
    /// </summary>
    public List<Func<AIPlayer, AIPlayer, AIPlayer>> AllowedCrossoverMethods =
      new List<Func<AIPlayer, AIPlayer, AIPlayer>>() { AIPlayer.GetSinglePointCrossover, AIPlayer.GetTwoPointCrossover, AIPlayer.GetUniformCrossover };
    private AITrainableGame[] gameInstances;
    private int nextGameInstanceId = 0;
    public AITrainableGame Game { 
      get {
        if (nextGameInstanceId >= gameInstances.Length)
          nextGameInstanceId = 0;
        return gameInstances[nextGameInstanceId++];
      }
      set {
        nextGameInstanceId = 0;
        gameInstances = new AITrainableGame[PopulationSize];
        for (int i = 0; i < PopulationSize; i++)
          gameInstances[i] = value.GetNewGameInstance();
      }
    }

    public NNMaker NeuralNetworkMaker;

    public Simulation() {
      Generation = 0;
    }

    /// <summary>
    /// Returns whether a given method for crossover is allowed to be used in the given configuration
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    public bool IsCrossoverMethodAllowed(Func<AIPlayer, AIPlayer, AIPlayer> func) {
      return AllowedCrossoverMethods.Contains(func);
    }

    /// <summary>
    /// Allows or disallows a crossover method to be used
    /// </summary>
    /// <param name="func">A crossover method</param>
    /// <param name="allow">Whether the given method should be allowed</param>
    public void AllowCrossoverMethod(Func<AIPlayer, AIPlayer, AIPlayer> func, bool allow) {
      if (AllowedCrossoverMethods.Contains(func)) {
        if (!allow)
          AllowedCrossoverMethods.Remove(func);
      }
      else if (allow) {
        AllowedCrossoverMethods.Add(func);
      }
    }
  }
}
