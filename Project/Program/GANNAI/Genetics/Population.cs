using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GANNAI;

namespace Genetics {
  public class Population {
    private AITrainableGame game;
    private IndividualList individuals;
    private int iteration;
    private int crossovers; //how many individuals of a new population must be born from crossover
    private int mutations; //how many individuals of a new population must be born from mutation
    private int crossoverMutations; //how many individuals of a new population must be born from both mutation and crossover

    public Population(AITrainableGame game, int size, int crossovers, int mutations, int crossoverMutations) {
      if (crossovers + mutations + crossoverMutations > size)
        throw new Exception("The number of crossovers and mutations sum to a value larger than the population size.");
      iteration = 0;
      this.game = game;
      this.crossovers = crossovers;
      this.mutations = mutations;
      this.crossoverMutations = crossoverMutations;
      individuals = new IndividualList(game);
      InitializeRandomPopulation(size);
    }

    //Performs an iteration, where new individuals are born by crossover, mutation and crossover-mutation.
    //A new individual replaces an old individual only if it has a greater fitness.
    public void Iterate() {
      this.iteration++;
      int size = individuals.Count;

      
      IndividualList newIndividuals = BreedIndividuals();

      //merge sort old and new population
      IndividualList resultingPopulation = new IndividualList(individuals, newIndividuals, game);


      individuals = resultingPopulation;
    }

    //Returns a list of new individuals bred from the current population
    private IndividualList BreedIndividuals() {
      IndividualList newlyBred = new IndividualList(game);
      for (int i = 0; i < mutations; i++) {
        AIPlayer individual1 = SelectIndividualRankBased();
        AIPlayer toAdd = individual1.GetMutated();
        newlyBred.Add(toAdd);
      }
      for (int i = 0; i < crossovers; i++) {
        AIPlayer individual1 = SelectIndividualRankBased();
        AIPlayer individual2 = SelectIndividualRankBased();
        AIPlayer toAdd = individual1.GetSinglePointCrossover(individual2);
        newlyBred.Add(toAdd);
      }
      for (int i = 0; i < crossoverMutations; i++) {
        AIPlayer individual1 = SelectIndividualRankBased();
        AIPlayer individual2 = SelectIndividualRankBased();
        AIPlayer crossovered = individual1.GetSinglePointCrossover(individual2);
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

    public void InitializeRandomPopulation(int count) {
      if (individuals == null)
        individuals = new IndividualList(game);
      individuals.Clear();
      List<AIPlayer> result = new List<AIPlayer>();
      for (int i = 0; i < count; i++)
        individuals.Add(new AIPlayer(game));
    }

    /// <summary>
    /// Returns the most fit individual in the population
    /// </summary>
    /// <returns></returns>
    public AIPlayer GetBest() {
      return individuals.Get(0);
    }
  }
}
