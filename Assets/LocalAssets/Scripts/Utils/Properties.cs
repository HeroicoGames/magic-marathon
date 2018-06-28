using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicMarathon.Utils {
	
	public class Properties {
		public enum TouchStatus {Neutral, Successful, Final, Failed};
		public enum Color {White, Red, Green, Blue};

		// Hexadecimals color: Red="FF4D4D", Green="12BF4C", Blue="6397FF", 
		public static Dictionary <string, byte[]> rgbaColors = new Dictionary <string, byte[]> () {
			{"Red", new byte[] {255, 77, 77, 255}},
			{"Green", new byte[] {18, 191, 76, 255}},
			{"Blue", new byte[] {99, 151, 255, 255}},
		};
	}

}