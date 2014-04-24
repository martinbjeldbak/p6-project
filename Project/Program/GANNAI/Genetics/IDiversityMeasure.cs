using System;
using System.Collections.Generic;
using Utility;

namespace Genetics {
  public interface IDiversityMeasure {
    double MeasureDiversity(SortList<AIPlayer> individuals, int runs);
  }
}

