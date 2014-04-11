﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {

    /// <summary>
    /// Inserts an offspring individual into the population using the following rules:
    /// If made by two parents, and with a probability that depends on their average fitness related to
    /// the fitness of the individual: replace both parents with the individual and insert a random immigrant
    /// If made by only a single parent, replace it with a probability proportional to their
    /// relative fitness
    /// </summary>
    public class ProbabilisticAncestorElitismReplacementRule : OffspringMerger {
        public void Merge(SortList<AIPlayer> individuals, List<AIPlayer> offspring, Simulation simulation) {

            throw new Exception("Only partially implemented, Kent is working on it.");

            //If having only single parent, replace it with a probability
            foreach (AIPlayer o in offspring) {
                if (o.Parent2 == null) {
                    for (int i = 0; i < individuals.Count; i++) {
                        if (individuals.Get(i) == o.Parent1) {
                            if (Utility.RandomNum.RandomDouble() * (o.GetFitness() + individuals.Get(i).GetFitness()) > o.GetFitness()) {
                                individuals.Remove(individuals.Get(i));
                                individuals.Add(o);
                            }
                        }
                    }
                }
                else {
                    //The offspring were made from 2 parents
                    //If offspring is better than both parents, replace both parents and add a random AIPlayer
                    bool betterThanParent1 = false;
                    bool betterThanParent2 = false;
                    for (int i = 0; i < individuals.Count; i++) {
                        if (individuals.Get(i) == o.Parent1 && individuals.Get(i).GetFitness() < o.Parent1.GetFitness())
                            betterThanParent1 = true;
                        if (individuals.Get(i) == o.Parent2 && individuals.Get(i).GetFitness() < o.Parent2.GetFitness())
                            betterThanParent2 = true;
                    }

                    //if better than both parents, remove both parents and add a random immigrant
                    if (betterThanParent1 && betterThanParent2) {
                        individuals.Remove(o.Parent1);
                        individuals.Remove(o.Parent2);
                        individuals.Add(o);
                        AIPlayer randomImmagrant = new AIPlayer(simulation.NeuralNetworkMaker);
                        randomImmagrant.CalcFitness(simulation.Game);
                        individuals.Add(randomImmagrant);
                    }
                }
            }
            individuals.Crop(individuals.Count / 2);
            while (individuals.Count < simulation.PopulationSize) {
                AIPlayer randomImmagrant = new AIPlayer(simulation.NeuralNetworkMaker);
                randomImmagrant.CalcFitness(simulation.Game);
                individuals.Add(randomImmagrant);
            }
        }
    }
}
