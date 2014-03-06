using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {
  public class Simulation {

    public Population Population { get; private set; }

    /// <summary>
    /// If set, an individual x can only be added to the population if it is better than
    /// the most similar individual y already contained in the population. 
    /// If x is added, y is removed.
    /// </summary>
    public readonly bool ForceDiversity;

    /// <summary>
    /// The number of individuals in a population
    /// </summary>
    public readonly int PopulationSize;

    /// <summary>
    /// The chance of each single bit to be inverted when mutating a DNA string
    /// </summary>
    public readonly double MutationRate;

    /// <summary>
    /// The fraction of newly breeded individuals that should be bred from crossover. The remaining amount will be bred from mutation
    /// </summary>
    public readonly double CrossoverBredAmount;

    /// <summary>
    /// The fraction of newly breeded individuals from crossover, that should also be mutated
    /// </summary>
    public readonly double MutateAfterCrossoverAmount;

    public readonly bool AllowUniformCrossover;

    public readonly bool AllowTwoPointCrossover;

    public readonly bool AllowSinglePointCrossover;

    /// <summary>
    /// A list of all allowed crossover methods. Changing the Configuration will automatically change the list content
    /// </summary>
    private List<CrossoverMethod> allowedCrossoverMethods =
      new List<CrossoverMethod>() { new SinglePointCrossover(), new TwoPointCrossover(), new UniformCrossover() };
    
    /// <summary>
    /// When setting the property Game, x game instances are made, where x is population size.
    /// This is convenient for running multi threaded
    /// </summary>
    private AITrainableGame[] gameInstances;
    
    /// <summary>
    /// The next game instance that can be used by a new thread
    /// </summary>
    private int nextGameInstanceId = 0;
    
    public AITrainableGame Game { 
      get {
        if (nextGameInstanceId >= gameInstances.Length)
          nextGameInstanceId = 0;
        return gameInstances[nextGameInstanceId++];
      }
      set {
        //use a new neural network maker which number of hidden neurons is based on number of inputs and outputs of the game. 
        NeuralNetworkMaker = new SimpleNNMaker(value);
        nextGameInstanceId = 0;
        gameInstances = new AITrainableGame[PopulationSize];
        for (int i = 0; i < PopulationSize; i++)
          gameInstances[i] = value.GetNewGameInstance();
      }
    }

    public NNMaker NeuralNetworkMaker { get; private set; }

    public Simulation(AITrainableGame game, int populationSize = 100, double crossOverBredAmount = 0.5, double mutateAfterCrossoverAmount = 0.1, 
      double mutationRate = 0.05, bool allowSinglePointCrossover = true, bool allowTwoPointCrossover = true, bool allowUniformCrossover = true,
      bool forceDiversity = false) {
      PopulationSize = populationSize;
      CrossoverBredAmount = crossOverBredAmount;
      MutateAfterCrossoverAmount = mutateAfterCrossoverAmount;
      MutationRate = mutationRate;
      AllowSinglePointCrossover = allowSinglePointCrossover;
      AllowTwoPointCrossover = allowTwoPointCrossover;
      AllowUniformCrossover = allowUniformCrossover;
      ForceDiversity = forceDiversity;

      allowedCrossoverMethods = new List<CrossoverMethod>();
      if (AllowSinglePointCrossover)
        allowedCrossoverMethods.Add(new SinglePointCrossover());
      if (AllowTwoPointCrossover)
        allowedCrossoverMethods.Add(new TwoPointCrossover());
      if (AllowUniformCrossover)
        allowedCrossoverMethods.Add(new UniformCrossover());
      Game = game;
      NeuralNetworkMaker = new SimpleNNMaker(game);
      Population = new Population(this, 1);
    }

    public void Restart() {
      Population = new Population(this, 1);
    }

    /// <summary>
    /// Simulates the population evolving for a number of generations
    /// </summary>
    /// <param name="generations">The number of generations to evolve</param>
    public void Simulate(int generations) {
      for (int i = 0; i < generations; i++) {
        Population.Evolve();
      }
    }

    public double[] GetFitnessValues() {
      return Population.GetFitnessValues();
    }

    public AIPlayer GetBest() {
      return Population.GetBest();
    }

    /// <summary>
    /// Returns a random of the allowed crossover methods
    /// </summary>
    /// <returns></returns>
    public CrossoverMethod RandomCrossoverMethod() {
      int randomFuncIndex = RandomNum.RandomInt(0, allowedCrossoverMethods.Count);
      return allowedCrossoverMethods[randomFuncIndex];
    }

    /// <summary>
    /// Saves information about simulation state to the database
    /// </summary>
    public void SaveSimulation() {
    }
  }
}
