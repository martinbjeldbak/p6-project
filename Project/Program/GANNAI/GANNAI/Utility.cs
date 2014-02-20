using System;
using System.Text;
using System.Collections.Generic;

namespace GANNAI {
	public static class Utility {
		//random operator
		private static Random random = new Random();

		//return random integer
		public static int RandomInt(int start, int end) {
			return random.Next(start, end);
		}

		//return random double
		public static double RandomDouble(){
			return random.NextDouble(); 
		}

		//return random boolean
		public static bool RandomBool(){
			return (random.NextDouble() >= 0.5) ? true : false;
		}
	}
}

