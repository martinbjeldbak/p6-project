using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using GANNAI;

namespace Genetics {
  public class Population {
    private SortList<AIPlayer> individuals;
    public Simulation Simulation;
    public Population(Simulation simulation) {
      individuals = new SortList<AIPlayer>();
      InitializeRandomPopulation();
    }

    //Performs an iteration, where new individuals are born by crossover, mutation and crossover-mutation.
    //A new individual replaces an old individual only if it has a greater fitness.

    public void Iterate() {
      SortList<AIPlayer> newIndividuals = BreedIndividuals();

      //merge old and new population
      SortList<AIPlayer> resultingPopulation = new SortList<AIPlayer>(individuals, newIndividuals, individuals.Count);
      individuals = resultingPopulation;
    }

    //Returns a list of new individuals bred from the current population
    private SortList<AIPlayer> BreedIndividuals() {

      int crossovers = (int)(Simulation.PopulationSize * Simulation.CrossoverBredAmount);
      int mutations = Simulation.PopulationSize - crossovers;
      int crossoverMutations = (int)(Simulation.MutateAfterCrossoverAmount * Simulation.MutateAfterCrossoverAmount);
      crossovers -= crossoverMutations;

      SortList<AIPlayer> newlyBred = new SortList<AIPlayer>();
      for (int i = 0; i < mutations; i++) {
        AIPlayer individual1 = SelectIndividualRankBased();
        AIPlayer toAdd = individual1.GetMutated();
        newlyBred.Add(toAdd);
      }
      for (int i = 0; i < crossovers; i++) {
        AIPlayer individual1 = SelectIndividualRankBased();
        AIPlayer individual2 = SelectIndividualRankBased();
        AIPlayer toAdd = AIPlayer.GetCrossover(individual1, individual2);
        newlyBred.Add(toAdd);
      }
      for (int i = 0; i < crossoverMutations; i++) {
        AIPlayer individual1 = SelectIndividualRankBased();
        AIPlayer individual2 = SelectIndividualRankBased();
        AIPlayer crossovered = AIPlayer.GetCrossover(individual1, individual2);
        AIPlayer toAdd = crossovered.GetMutated();
        newlyBred.Add(toAdd);
      }
        return newlyBred;
    }

    //A weighted random selection of an individual based on the rank of each individual (least fitness has rank 1, greatest fitness has rank n)
    private AIPlayer SelectIndividualRankBased() {
      if (individuals.Count == 0)
        throw new Exception("Individual list is empty");

      //Summing 1+2+...+n = n(n+1)/2
      int sum = individuals.Count * (individuals.Count + 1) / 2;
      int ran = Utility.RandomInt(1, sum);
      int index = 0;
      for (int i = 0; i < individuals.Count; i++) {
        ran -= (i + 1);
        if (ran <= 0)
          return individuals.Get(index);
        index++;
      }

      throw new Exception("Something went wrong and no individual was selected based on rank");
    }

    //A weighted random selection of an individual based on the fitness of each individual
    private AIPlayer SelectIndividualFitnessBased() {
      if (individuals.Count == 0)
        throw new Exception("Individual list is empty");

      //Sum all fitness values
      double sum = 0;
      for (int i = 0; i < individuals.Count; i++)
        sum += individuals.Get(i).GetFitness();

      double ran = Utility.RandomDouble() * sum;
      int index = 0;
      for (int i = 0; i < individuals.Count; i++) {
        ran -= individuals.Get(i).GetFitness();
        if (ran <= 0)
          return individuals.Get(index);
        index++;
      }

      throw new Exception("Something went wrong and no individual was selected based on fitness");
    }

    public void InitializeRandomPopulation() {
      if (individuals == null)
        individuals = new SortList<AIPlayer>();
      individuals.Clear();
      List<AIPlayer> result = new List<AIPlayer>();
      for (int i = 0; i < Simulation.PopulationSize; i++)
        individuals.Add(new AIPlayer(this, Simulation.NeuralNetworkMaker.DNALength()));
    }

    /// <summary>
    /// Returns the most fit individual in the population
    /// </summary>
    /// <returns></returns>
    public AIPlayer GetBest() {
      return individuals.Get(0);
    }

    /// <summary>
    /// Returns the fitness values of all individuals in descending order
    /// </summary>
    /// <returns></returns>
    public double[] GetFitnessValues() {
      double[] result = new double[individuals.Count];
      Parallel.For(0, individuals.Count, i => individuals.Get(i).GetFitness());    
      for(int i = 0; i < individuals.Count; i++)
        result[i] = individuals.Get(i).GetFitness();
      return result;
    }
  }
}
