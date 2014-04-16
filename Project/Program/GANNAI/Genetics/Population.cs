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

            CalcFitnessValuesThreaded(offspring);
            Simulation.offspringMerger.Merge(individuals, offspring, Simulation);
            individuals.Crop(Simulation.PopulationSize);
            Generation++;
        }


        /// <summary>
        /// Calculates the fitness value of each individual threaded
        /// </summary>
        /// <param name="offspring"></param>
        private void CalcFitnessValuesThreaded(List<AIPlayer> list) {
            Task[] tasks = new Task[list.Count];
            for (int i = 0; i < list.Count; i++) {
                int index = i;
                AITrainableGame game = Simulation.Game;
                tasks[index] = Task.Factory.StartNew(() => { list[index].CalcFitness(game); });
            }
            Task.WaitAll(tasks);  
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

            //Parallel.For(0, newlyBred.Count, i => newlyBred[i].CalcFitness(Simulation.Game));
            foreach (AIPlayer aip in newlyBred) {
                aip.CalcFitness(Simulation.Game);
            }
            return newlyBred;
        }
        //A weighted random selection of an individual based on the rank of each individual (least fitness has rank 1, greatest fitness has rank n)
        private AIPlayer SelectIndividualRankBased() {
            RankMethod rankMethod = new LinearRankMethod();
            return individuals.Get(rankMethod.GetRandomIndex(individuals.Count));
        }

        public void InitializeRandomPopulation() {
            double cloneRate = Simulation.InitialSimilarity;
            double mutateRate = Simulation.InitialMutation;
            if (cloneRate > 1.0 || cloneRate < 0.0)
                throw new Exception("clone rate is not set correctly.");
            if (individuals == null)
                individuals = new SortList<AIPlayer>();
            individuals.Clear();

            AIPlayer cloneIndividual = new AIPlayer(Simulation.NeuralNetworkMaker);
            cloneIndividual.CalcFitness(Simulation.Game);
            individuals.Add(cloneIndividual);
            int cloneSize = (int)(cloneRate * Simulation.PopulationSize);
            for (int i = 1; i < cloneSize; i++) {
                DNA cloneDNA = cloneIndividual.DNA.Clone();
                if (mutateRate > 0.0)
                    cloneDNA = cloneDNA.GetMutated(mutateRate);
                cloneIndividual = new AIPlayer(cloneDNA, Simulation.NeuralNetworkMaker);
                cloneIndividual.CalcFitness(Simulation.Game);
                individuals.Add(cloneIndividual);
            }

            int randSize = Simulation.PopulationSize - cloneSize;
            for (int i = 0; i < randSize; i++) {
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
        public AIPlayer GetMean() {
            return individuals.Get((int)(individuals.Count / 2.0));
        }

        /// <summary>
        /// Gets the average fitness of the entire population.
        /// </summary>
        /// <returns>The average fitness of the population.</returns>
        public double GetAverage() {
            double total = 0.0;
            for (int i = 0; i < individuals.Count; i++)
                total += individuals.Get(i).GetFitness();
            return total / individuals.Count;
        }

        /// <summary>
        /// Returns the fitness values of all individuals in descending order
        /// </summary>
        /// <returns></returns>
        public double[] GetFitnessValues() {
            double[] result = new double[individuals.Count];
            for (int i = 0; i < individuals.Count; i++)
                result[i] = individuals.Get(i).GetFitness();
            return result;
        }

        /// <summary>
        /// Measures the diversity.
        /// </summary>
        /// <returns>The diversity.</returns>
        /// <param name="runs">Number of runs.</param>
        public double MeasureDiversity(int runs = 100) {
            int outputSize = individuals.Get(0).neuralNetwork.GetNumberOfOutputs();

            double[] diversities = new double[runs];

            for (int j = 0; j < runs; j++) {
                int[] outputCount = new int[outputSize];
                double[] randInputs = new double[individuals.Get(0).neuralNetwork.GetNumberOfInputs()];
                for (int i = 0; i < randInputs.Length; i++)
                    randInputs[i] = RandomNum.RandomDouble();

                Parallel.For(0, individuals.Count, i => {
                    AIPlayer a = individuals.Get(i);
                    outputCount[a.GetStrongestOutputIndex(randInputs)]++;
                    double[] outputs = a.GetOutputs(randInputs);
                });

                double numerator = 0.0;
                int totalOrganisms = 0;
                for (int i = 0; i < outputSize; i++) {
                    numerator += outputCount[i] * (outputCount[i] - 1);
                    totalOrganisms += outputCount[i];
                }

                int s = individuals.Count;
                double demoninator = totalOrganisms * (totalOrganisms - 1);
                diversities[j] = 1.0 - numerator / demoninator;
            }

            double diversity = 0.0;
            for (int i = 0; i < runs; i++)
                diversity += diversities[i];

            return diversity / runs;
        }
    }
}
