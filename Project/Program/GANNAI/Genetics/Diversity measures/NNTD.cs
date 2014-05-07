using System;
using System.Linq;
using System.Collections.Generic;
using Utility;
using System.Threading;
using System.Threading.Tasks;

namespace Genetics.DiversityMeasures {
    /// <summary>
    /// A phenotypic diversity measure for a collection of neural networks, Neural Network
    /// Trait Diversity.
    /// </summary>
    public class NNTD : IDiversityMeasure {
        int runs;
        public NNTD(int runs = 100) {
            this.runs = runs;
        }

        /// <summary>
        /// Returns the specie of the given array of values.
        /// For instance, specie 13 is returned (1101 in binary), if the values on indexes
        /// 1, 2, and 4 is greater than or equal to any other value
        /// </summary>
        /// <param name="outputs">values </param>
        /// <returns>The specie as a decimal value in the range [1, 2^n-1]</returns>
        public int CalcSpecie(double[] values){
            List<int> indexes = new List<int>();
            double max = double.NegativeInfinity;
            for (int i = 0; i < values.Length; i++) {
                if (values[i] > max) {
                    indexes.Clear();
                    indexes.Add(i);
                    max = values[i];
                }
                else if (values[i] == max)
                    indexes.Add(i);
            }
            int specie = 0;
            for (int i = 0; i < indexes.Count; i++)
                specie += 1 << indexes[i];
            return specie;
        }

        #region IDiversityMeasure implementation
        public double MeasureDiversity(SortList<AIPlayer> individuals) {
            int outputSize = individuals.Get(0).neuralNetwork.GetNumberOfOutputs();

            double diversity = 0;

            for (int j = 0; j < runs; j++) {
                double[] randInputs = new double[individuals.Get(0).neuralNetwork.GetNumberOfInputs()];
                for (int i = 0; i < randInputs.Length; i++)
                    randInputs[i] = RandomNum.RandomDouble();

                //We use a dictionary to keep track of the size of each specie we encounter
                Dictionary<int, int> counters = new Dictionary<int, int>();
                for (int l = 0; l < individuals.Count; l++){
                    int specie = CalcSpecie(individuals.Get(l).GetOutputs(randInputs));
                    if (counters.Keys.Contains(specie))
                        counters[specie]++;
                    else
                        counters.Add(specie, 1);
                }

                //Use simpsons diversity
                diversity += CalcSimpsonsDiversity(counters);
            }

            return diversity / runs;
        }

        public double CalcSimpsonsDiversity(Dictionary<int, int> counters) {
            double numerator = 0;
            int total = 0;
            foreach (KeyValuePair<int, int> a in counters){
                numerator += a.Value * (a.Value-1);
                total += a.Value;
            }
            return 1 - numerator / (total * (total - 1));
        }

        public string Name {
          get { return "NNTD"; }
        }
        #endregion
    }
}

