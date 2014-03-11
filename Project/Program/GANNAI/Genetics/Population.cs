using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using Utility;

namespace Genetics {
  public class Population {
    private SortList<AIPlayer> individuals;

    public int Generation { get; private set; }

    public Simulation Simulation;

    public Population(Simulation simulation, int generation) {
      Simulation = simulation;
      Generation = generation;
      individuals = new SortList<AIPlayer>();
      InitializeRandomPopulation();
    }

    public int TotalIndividuals() {
      return 0;
      // Return the total amount of total individual, which this generation * population size
    }

    /// <summary>
    ///Performs an iteration, where new individuals are born by crossover, mutation and crossover-mutation.
    ///A new individual replaces an old individual only if it has a greater fitness.
    /// </summary>
    public void Iterate() {
      List<AIPlayer> offspring = BreedIndividuals();
      offspring.ForEach(p => p.CalcFitness(Simulation.Game));
      Simulation.offspringMerger.Merge(individuals, offspring, Simulation);
      individuals.Crop(Simulation.PopulationSize);
      Generation++;
    }
    //Returns a list of new individuals bred from the current population
    private List<AIPlayer> BreedIndividuals() {

      int crossovers = (int)(Simulation.PopulationSize * Simulation.CrossoverBredAmount);
      int mutations = Simulation.PopulationSize - crossovers;
      int crossoverMutations = (int)(Simulation.MutateAfterCrossoverAmount * Simulation.MutateAfterCrossoverAmount);
      crossovers -= crossoverMutations;

      List<AIPlayer> newlyBred = new List<AIPlayer>();
      for (int i = 0; i < mutations; i++) {
        AIPlayer parent = SelectIndividualRankBased();
        DNA newDNA = parent.DNA.GetMutated(Simulation.MutationRate);
        AIPlayer toAdd = new AIPlayer(newDNA, parent, null, Simulation.NeuralNetworkMaker);
        newlyBred.Add(toAdd);
      }
      for (int i = 0; i < crossovers; i++) {
        AIPlayer parent1 = SelectIndividualRankBased();
        AIPlayer parent2 = SelectIndividualRankBased();
        CrossoverMethod crossoverMethod = Simulation.RandomCrossoverMethod();
        DNA crossedDNA = crossoverMethod.Cross(parent1.DNA, parent2.DNA);
        AIPlayer toAdd = new AIPlayer(crossedDNA, parent1, parent2, Simulation.NeuralNetworkMaker);
        newlyBred.Add(toAdd);
      }
      for (int i = 0; i < crossoverMutations; i++) {
        AIPlayer parent1 = SelectIndividualRankBased();
        AIPlayer parent2 = SelectIndividualRankBased();
        CrossoverMethod crossoverMethod = Simulation.RandomCrossoverMethod();
        DNA crossedDNA = crossoverMethod.Cross(parent1.DNA, parent2.DNA);
        DNA crossedAndMutatedDNA = crossedDNA.GetMutated(Simulation.MutationRate);
        AIPlayer toAdd = new AIPlayer(crossedAndMutatedDNA, parent1, parent2, Simulation.NeuralNetworkMaker);
        newlyBred.Add(toAdd);
      }

      Parallel.For(0, newlyBred.Count, i => newlyBred[i].CalcFitness(Simulation.Game));

      return newlyBred;
    }
    //A weighted random selection of an individual based on the rank of each individual (least fitness has rank 1, greatest fitness has rank n)
    private AIPlayer SelectIndividualRankBased() {
      RankMethod rankMethod = new LinearRankMethod();
      return individuals.Get(rankMethod.GetRandomIndex(individuals.Count));
    }
    public void InitializeRandomPopulation() {
      if (individuals == null)
        individuals = new SortList<AIPlayer>();
      individuals.Clear();
      for (int i = 0; i < Simulation.PopulationSize; i++) {
        AIPlayer randomIndividual = new AIPlayer(Simulation.NeuralNetworkMaker);
        randomIndividual.CalcFitness(Simulation.Game);
        individuals.Add(randomIndividual);
      }
    }

    /// <summary>
    /// Returns the most fit individual in the population
    /// </summary>
    /// <returns></returns>
    public AIPlayer GetBest() {
      return individuals.Get(0);
    }

    /// <summary>
    /// Gets the least fit individual.
    /// </summary>
    /// <returns>The least fit individual in the population.</returns>
    public AIPlayer GetWorst() {
      return individuals.Get(individuals.Count - 1);
     }

    /// <summary>
    /// Gets the mean individual.
    /// </summary>
    /// <returns>The individual in the middle of the list of individuals.</returns>
    public AIPlayer GetMean(){
      return individuals.Get((int)(individuals.Count / 2.0));
    }

    /// <summary>
    /// Gets the average fitness of the entire population.
    /// </summary>
    /// <returns>The average fitness of the population.</returns>
    public double GetAverage(){
      double total = 0.0;
      for(int i = 0; i < individuals.Count; i++)
        total += individuals.Get(i).GetFitness();
      return total / individuals.Count;
    }

    /// <summary>
    /// Returns the fitness values of all individuals in descending order
    /// </summary>
    /// <returns></returns>
    public double[] GetFitnessValues() {
      double[] result = new double[individuals.Count];
      for(int i = 0; i < individuals.Count; i++)
        result[i] = individuals.Get(i).GetFitness();
      return result;
    }

    /// <summary>
    /// Calculates the fitness of all AIPlayers in the population by
    /// simulating a game being played with each AIPlayer. 
    /// The fitness values can be retrieved by balling GetFitnessValues()
    /// This method will 
    /// </summary>
    public void CalcFitnessValues(SortList<AIPlayer> list) {
      Parallel.For(0, list.Count, i => list.Get(i).CalcFitness(Simulation.Game));
  }

    /// <summary>
    /// Measures the diversity.
    /// </summary>
    /// <returns>The diversity.</returns>
    /// <param name="runs">Number of runs. Default is 1.</param>
    public double MeasureDiversity(int runs = 1) {
      int outputSize = individuals.Get(0).neuralNetwork.GetNumberOfOutputs();
      int[] outputCount = new int[outputSize];
      double[] diversities = new double[runs];

      for(int j = 0; j < runs; j++) {
        double[] randInputs = new double[individuals.Get(0).neuralNetwork.GetNumberOfInputs()];
        for(int i = 0; i < randInputs.Length; i++)
          randInputs[i] = RandomNum.RandomDouble();

      foreach(AIPlayer i in individuals)
          outputCount[i.GetOutput(randInputs)]++;
      
      double numerator = 0.0;
      for (int i = 0; i < outputSize; i++)
        numerator += outputCount[i] * ( outputCount[i] - 1 );

      int s = individuals.Count;
      double demoninator = s * (s - 1); 
        diversities[j] = 1.0 - numerator / demoninator;
    }
      double diversity = 0;
      for(int i = 0; i < runs; i++)
        diversity += diversities[i];

      return diversity / (double)(runs);
  }
}
}
