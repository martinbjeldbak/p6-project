using System;
using System.Collections.Generic;
using Utility;

namespace Genetics {
    public interface IDiversityMeasure {
        /// <summary>
        /// Measures the diversity for the given individuals
        /// </summary>
        /// <returns>A measure of diversity for the individuals</returns>
        /// <param name="individuals">A list of individuals</param>
        /// <param name="runs">How many times to calculate the diversity,
        ///    to take variances into account.</param>
        double MeasureDiversity(SortList<AIPlayer> individuals);

        string Name { get; }
    }
}