using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GANNAI {
  public class Population {
    private AITrainableGame game;
    private List<AIPlayer> individuals;
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
      individuals = MakeRandomPopulation(size);
      SortPopulation();
    }

    //Performs an iteration, where new individuals are born by crossover, mutation and crossover-mutation.
    //A new individual replaces an old individual only if it has a greater fitness.
    public void Iterate() {
      this.iteration++;
      int size = individuals.Count;

      //this list is sorted according to fitness, just as this.individuals is
      List<AIPlayer> newIndividuals = BreedIndividuals();

      //merge sort old and new population
      List<AIPlayer> resultingPopulation = new List<AIPlayer>();

      int a = 0;
      int b = 0;
      for (int i = 0; i < size; i++) {
        if (b < newIndividuals.Count && newIndividuals[a].GetFitness(game) > individuals[b].GetFitness(game))
          resultingPopulation.Add(newIndividuals[a++]);
        else
          resultingPopulation.Add(individuals[b++]);
      }

      individuals = resultingPopulation;
    }

    //Returns a list of new individuals bred from the current population
    public List<AIPlayer> BreedIndividuals() {

    }

    public List<AIPlayer> MakeRandomPopulation(int count) {
      List<AIPlayer> result = new List<AIPlayer>();
      for (int i = 0; i < count; i++)
        result.Add(new AIPlayer());
      return result;
    }
  }
}
