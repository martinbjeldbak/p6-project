using System;

namespace Genetics {
    /// <summary>
    /// A genotypic diversity measure, that measures diversity in a population based
    /// on the hamming distance between chromosomes belonging to the individuals.
    /// </summary>
    public class HammingDistance : IDiversityMeasure {

        /// <summary>
        /// Calculates the hamming distance between two array of bools
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int SingleHammingDistance(bool[] a, bool[] b) {
            if (a.Length != b.Length)
                throw new Exception("Hamming distance can only be calculated between two strings of equal length");
            int dis = 0;
            for (int i = 0; i < a.Length; i++)
                dis += a[i] == b[i] ? 1 : 0;
            return dis;
        }

        #region IDiversityMeasure implementation
        public double MeasureDiversity(Utility.SortList<AIPlayer> individuals) {
            //calculate average hamming distance between any two strings
            int size = individuals.Count;
            int hammingTotal = 0;
            for (int i = 0; i < size; i++)
                for (int p = i + 1; p < size; p++)
                    hammingTotal += SingleHammingDistance(individuals.Get(i).DNA.Bitstring, individuals.Get(p).DNA.Bitstring);
            return 2 * hammingTotal / (double)(size * (size - 1));
        }

        public string Name() {
            return "Hamming distance";
        }
        #endregion
    }
}

