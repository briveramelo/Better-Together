#region Declaration;
using UnityEngine;
using System.Collections;

namespace GenericFunctions{
#endregion
	
	#region Tags (strings)
	public static class Tags{
		public static string immoveable_Objects = "Immoveable";
		public static string explode_Objects = "Moveable_Explo";
		public static string implode_Objects = "Moveable_Implo";
		public static string moveableObjects = "Moveable";
	}
	#endregion

	#region Layers (ints)
	public static class Layers{
		public static int player = 8;
		public static int ground = 9;
		public static int invisibleWAlls = 10;
	}
	#endregion

}