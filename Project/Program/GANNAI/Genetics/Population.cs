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
    public int Generation { get; private set; }
    public Simulation Simulation;
    public Population(Simulation simulation, int generation) {
      Simulation = simulation;
      Generation = generation;
      individuals = new SortList<AIPlayer>();
      InitializeRandomPopulation();
    }

    /// <summary> 
    ///Performs an iteration, where new individuals are born by crossover, mutation and crossover-mutation.
    ///A new individual replaces an old individual only if it has a greater fitness.
    /// </summary>
    public void Evolve() {
      List<AIPlayer> newlyBred = BreedIndividuals();
      newlyBred.ForEach(p => p.CalcFitness(Simulation.Game));

      if (Simulation.OffspringUseCondition == OffspringUseCondition.IfBetterThanAll)
        newlyBred.RemoveAll(p => p.GetFitness() <= individuals.Get(0).GetFitness());

      SortList<AIPlayer> newIndividuals = new SortList<AIPlayer>();
      newlyBred.ForEach(p => newIndividuals.Add(p));

      individuals = new SortList<AIPlayer>(individuals, newIndividuals, individuals.Count);
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
        AIPlayer toAdd = new AIPlayer(parent.Parent1, parent.Parent2, parent.DNA.GetMutated(Simulation.MutationRate), Simulation.NeuralNetworkMaker);
        newlyBred.Add(toAdd);
      }
      for (int i = 0; i < crossovers; i++) {
        AIPlayer parent1 = SelectIndividualRankBased();
        AIPlayer parent2 = SelectIndividualRankBased();
        CrossoverMethod crossoverMethod = Simulation.RandomCrossoverMethod();
        AIPlayer toAdd = new AIPlayer(parent1, parent2, crossoverMethod.Cross(parent1.DNA, parent2.DNA), Simulation.NeuralNetworkMaker);
        newlyBred.Add(toAdd);
      }
      for (int i = 0; i < crossoverMutations; i++) {
        AIPlayer parent1 = SelectIndividualRankBased();
        AIPlayer parent2 = SelectIndividualRankBased();
        CrossoverMethod crossoverMethod = Simulation.RandomCrossoverMethod();
        DNA crossedDNA = crossoverMethod.Cross(parent1.DNA, parent2.DNA);
        DNA crossedAndMutatedDNA = crossedDNA.GetMutated(Simulation.MutationRate);
        AIPlayer toAdd = new AIPlayer(parent1, parent2, crossedAndMutatedDNA, Simulation.NeuralNetworkMaker);
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
        individuals.Add(new AIPlayer(null, null, Simulation.NeuralNetworkMaker));
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
  }


}
