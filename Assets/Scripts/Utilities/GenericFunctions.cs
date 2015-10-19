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

	#region Players (explo _ implo)
	public static class Players{
		public static GameObject explo;
		public static GameObject implo;

		public static Transform explo_CameraAnchor;
		public static Transform explo_CameraLookSpot;
		public static Transform implo_CameraAnchor;
		public static Transform implo_CameraLookSpot;

		public static PlayerType dominantPlayer;

		public static Vector3 respawnShift = -Vector3.right;
	}
	#endregion

	#region Controls (explo _ implo)
	public static class StaticControls{
		public static Controls controls_Explo;
		public static Controls controls_Implo;
	}
	#endregion

	#region LevelNames
	public static class Levels{
		public static string mainMenu = "Main Menu";
		public static string level1 = "Level1";
	}
	#endregion

	#region GameState
	public static class GameState{
		public static bool isPaused;
	}
	#endregion

	#region LevelItems
	public static class LevelItems{
		public static GameObject pauseMenu;
	}
	#endregion


}