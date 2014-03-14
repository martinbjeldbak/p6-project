using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetics {
  interface RankMethod {
    /// <summary>
    /// Returns a random index based on the rank of a number of elements. 
    /// A lower index has a greater chance to be selected
    /// </summary>
    /// <param name="num">the number of elements, starting from 0</param>
    /// <returns></returns>
    int GetRandomIndex(int num);
  }
}
