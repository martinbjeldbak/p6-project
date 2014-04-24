using System;
using System.Linq;

namespace Genetics {
  /// <summary>
  /// Meausres diversity solely based on fitness. It is the number
  /// of unique fitness values in the population, devided by the size
  /// of the population.
  /// </summary>
  public class Fitness : IDiversityMeasure {
    #region IDiversityMeasure implementation
        public double MeasureDiversity(Utility.SortList<AIPlayer> individuals, int runs) {
            int size = individuals.Count;

            double[] fitnessValues = new double[size];

            for(int i = 0; i < size; i++)
                fitnessValues[i] = individuals[i].GetFitness();

            return fitnessValues.Distinct().Count() / (double)size;
        }

        public string Name() {
            return "Fitness-based";
        }
    #endregion
  }
}

