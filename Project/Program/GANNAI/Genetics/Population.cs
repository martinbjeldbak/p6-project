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
    public void Evolve() {
      List<AIPlayer> offspring = BreedIndividuals();
      offspring.ForEach(p => p.CalcFitness(Simulation.Game));

      if (Simulation.ForceDiversity) {
        foreach (AIPlayer o in offspring) {
          AIPlayer mostSimilar = o.MostSimilar(individuals);
          if (o.CalcSimilarity(mostSimilar) > 0.9) {
            if (o.GetFitness() > mostSimilar.GetFitness()) {
              individuals.Remove(mostSimilar);
              individuals.Add(o);
            }
          }
          else {
            individuals.Add(o);
          }
        }
      }
      else {
        offspring.ForEach(p => individuals.Add(p));
      }


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
        AncestorLink ancestorLink = new AncestorLink(parent.DNA, null, 1.0, 0.0);
        AIPlayer toAdd = new AIPlayer(ancestorLink, newDNA, Simulation.NeuralNetworkMaker);
        newlyBred.Add(toAdd);
      }
      for (int i = 0; i < crossovers; i++) {
        AIPlayer parent1 = SelectIndividualRankBased();
        AIPlayer parent2 = SelectIndividualRankBased();
        CrossoverMethod crossoverMethod = Simulation.RandomCrossoverMethod();
        DNA crossedDNA = crossoverMethod.Cross(parent1.DNA, parent2.DNA);
        AncestorLink ancestorLink = crossoverMethod.LastCrossAncestorLink;
        AIPlayer toAdd = new AIPlayer(ancestorLink, crossedDNA, Simulation.NeuralNetworkMaker);
        newlyBred.Add(toAdd);
      }
      for (int i = 0; i < crossoverMutations; i++) {
        AIPlayer parent1 = SelectIndividualRankBased();
        AIPlayer parent2 = SelectIndividualRankBased();
        CrossoverMethod crossoverMethod = Simulation.RandomCrossoverMethod();
        DNA crossedDNA = crossoverMethod.Cross(parent1.DNA, parent2.DNA);
        AncestorLink ancestorLink = crossoverMethod.LastCrossAncestorLink;
        DNA crossedAndMutatedDNA = crossedDNA.GetMutated(Simulation.MutationRate);
        AIPlayer toAdd = new AIPlayer(ancestorLink, crossedAndMutatedDNA, Simulation.NeuralNetworkMaker);
        newlyBred.Add(toAdd);
      }
        return newlyBred;
    }

    //A weighted random selection of an individual based on the rank of each individual (least fitness has rank 1, greatest fitness has rank n)
    private AIPlayer SelectIndividualRankBased() {
      RankMethod rankMethod = new LinearRankMethod();
      return individuals.Get(rankMethod.GetRandomIndex(individuals.Count));
    }

    //A weighted random selection of an individual based on the fitness of each individual
    private AIPlayer SelectIndividualFitnessBased() {
      if (individuals.Count == 0)
        throw new Exception("Individual list is empty");

      //Sum all fitness values
      double sum = 0;
      for (int i = 0; i < individuals.Count; i++)
        sum += individuals.Get(i).GetFitness();

      double ran = RandomNum.RandomDouble() * sum;
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
  }


}
