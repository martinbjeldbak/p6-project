using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {

    /// <summary>
    /// Inserts an offspring individual into the population using the following rules:
    /// If made from two parents, a random parent is chosen. If the individual is more fit than the chosen parent,
    /// it replaces the parent.
    /// If made from only a single parent, it will replace its parent only if it performs better
    /// </summary>
    public class SingleParentElitismReplacementRule : OffspringMerger {
        public void Merge(SortList<AIPlayer> individuals, List<AIPlayer> offspring, Simulation simulation) {

            //If having only single parent, replace it with a probability
            foreach (AIPlayer o in offspring) {
                if (o.Parent2 == null) {
                    if (o.GetFitness() > o.Parent1.GetFitness() && individuals.Contains(o.Parent1))
                            individuals.Remove(o.Parent1);
                            individuals.Add(o);
                    }
                else {
                    //The offspring were made from 2 parents
                    AIPlayer firstPriority = null;
                    AIPlayer secondPriority = null;
                    if (Utility.RandomNum.RandomInt(0, 2) == 0) {
                        firstPriority = o.Parent1;
                        secondPriority = o.Parent2;
                    }
                    else {
                        firstPriority = o.Parent2;
                        secondPriority = o.Parent1;
                    }
                    if (o.GetFitness() > firstPriority.GetFitness() && individuals.Contains(firstPriority)) {
                        individuals.Remove(firstPriority);
                        individuals.Add(o);
                    }
                    else if (o.GetFitness() > secondPriority.GetFitness() && individuals.Contains(secondPriority)) {
                        individuals.Remove(secondPriority);
                        individuals.Add(o);
                    }
                }
            }
        }
    }
}
