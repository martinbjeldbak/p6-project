using System;

namespace Genetics {
      /// <summary>
      /// A genotypic diversity measure, that measures diversity in a population based
      /// on the hamming distance between chromosomes belonging to the individuals.
      /// </summary>
    public class HammingDistance : IDiversityMeasure {
    #region IDiversityMeasure implementation
        public double MeasureDiversity(Utility.SortList<AIPlayer> individuals, int runs) {
            return 2;
        }

        public string Name() {
            return "Hamming distance";
        }
    #endregion
  }
}

