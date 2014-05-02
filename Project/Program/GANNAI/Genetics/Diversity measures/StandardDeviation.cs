using System;
using System.Linq;

namespace Genetics.DiversityMeasures {
    public class StandardDeviation : IDiversityMeasure {
        public StandardDeviation() {
        }

        #region IDiversityMeasure implementation

        public double MeasureDiversity(Utility.SortList<AIPlayer> individuals) {
            double avgFitness = individuals.Aggregate(0.0, (of, i) => of += i.GetFitness()) / individuals.Count;

            double fitDiff = 0.0;

            foreach(AIPlayer p in individuals) {
                double fit = p.GetFitness();

                fitDiff += (fit - avgFitness) * (fit - avgFitness);
            }

            return Math.Sqrt(fitDiff / (individuals.Count - 1));
        }

        public string Name {
            get {
                return "Standard deviation";
            }
        }

        #endregion
    }
}

