using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {
  public class Simulation {

    public Population Population { get; private set; }

    public readonly ReplacementRule offspringMerger;
    public readonly int ReplacementRule;

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
		
    public readonly double InitialMutation;
		
    public readonly double InitialSimilarity;

    public readonly bool AllowUniformCrossover;

    public readonly bool AllowTwoPointCrossover;

    public readonly bool AllowSinglePointCrossover;

    /// <summary>
    /// A list of all allowed crossover methods. Changing the Configuration will automatically change the list content
    /// </summary>
    private List<CrossoverMethod> allowedCrossoverMethods =
      new List<CrossoverMethod>() { new SinglePointCrossover(), new TwoPointCrossover(), new UniformCrossover() };
    
    ///Keeps track of which game instance to give to to the next thread asking for it.
    ///Only 'Population.Count' instances can run in parallel 
    private int nextGameInstanceIndex = -1;

    /// <summary>
    /// When setting the property Game, x game instances are made, where x is population size.
    /// This is convenient for running multi threaded
    /// </summary>
    private AITrainableGame[] gameInstances;
    
    public AITrainableGame Game {
        get {
            nextGameInstanceIndex = (nextGameInstanceIndex + 1) % PopulationSize;
            return gameInstances[nextGameInstanceIndex];
            
        }
      set {
        //use a new neural network maker which number of hidden neurons is based on number of inputs and outputs of the game. 
        NeuralNetworkMaker = new SimpleNNMaker(value);
        gameInstances = new AITrainableGame[PopulationSize];
        for (int i = 0; i < PopulationSize; i++ )
            gameInstances[i] = value.GetNewGameInstance();
      }
    }

    public NNMaker NeuralNetworkMaker { get; private set; }

    public Simulation(AITrainableGame game, int populationSize = 100, double crossOverBredAmount = 0.5, double mutateAfterCrossoverAmount = 0.1, 
      double mutationRate = 0.05, int allowSinglePointCrossover = 1, int allowTwoPointCrossover = 1, int allowUniformCrossover = 1,
      int offspringSelectionPolicy = 0, double initialMutation = 0.0, double initialSimilarity = 0.0) {
      PopulationSize = populationSize;
      CrossoverBredAmount = crossOverBredAmount;
      MutateAfterCrossoverAmount = mutateAfterCrossoverAmount;
      MutationRate = mutationRate;
      AllowSinglePointCrossover = allowSinglePointCrossover == 1 ? true : false;
      AllowTwoPointCrossover = allowTwoPointCrossover == 1 ? true : false;
      AllowUniformCrossover = allowUniformCrossover == 1 ? true : false;
      ReplacementRule = offspringSelectionPolicy;
      InitialMutation = initialMutation;
      InitialSimilarity = initialSimilarity;

      allowedCrossoverMethods = new List<CrossoverMethod>();
      if (AllowSinglePointCrossover)
        allowedCrossoverMethods.Add(new SinglePointCrossover());
      if (AllowTwoPointCrossover)
        allowedCrossoverMethods.Add(new TwoPointCrossover());
      if (AllowUniformCrossover)
        allowedCrossoverMethods.Add(new UniformCrossover());

      switch (ReplacementRule) {
        case 0: offspringMerger = new NaiveReplacementRule(); break;
        case 1: offspringMerger = new AncestorElitismNoExtinctionReplacementRule(); break;
        case 2: offspringMerger = new AncestorElitismReplacementRule(); break;
        case 3: offspringMerger = new SingleParentElitismReplacementRule(); break;
        case 4: offspringMerger = new ExploreExploitT30ReplacementRule(); break;
        case 5: offspringMerger = new ExploreExploitT20ReplacementRule(); break;
        case 6: offspringMerger = new ExploreExploitT40ReplacementRule(); break;
      default: throw new Exception("Wrong offspring merge type: " + ReplacementRule);
      }

      Game = game;
      NeuralNetworkMaker = new SimpleNNMaker(game);
    }

    public void Restart() {
      Population = new Population(this, 1);
    }

    /// <summary>
    /// Reset the population according to the simulation's configuration
    /// and simulates the population evolving for a number of generations.
    /// </summary>
    /// <param name="generations">The number of generations to evolve</param>
    public void Simulate(int generations, ObservationSaver obs) {
      Restart();
      if (obs != null)
          obs.SavePopulation();
      for (int i = 0; i < generations; i++) {
        Population.Iterate();
        if (obs != null) {
          obs.SavePopulation();
        }
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
  }
}
