#region Declaration
using UnityEngine;
using System.Collections;

namespace GenericFunctions{
#endregion
	
	#region Tags (strings)
	public static class Tags{
		public static string immoveable_Objects = "Immoveable";
		public static string explode_Objects = "Moveable_Explo";
		public static string implode_Objects = "Moveable_Implo";
		public static string moveable_Objects = "Moveable";
	}
	#endregion

	#region Layers (ints)
	public static class Layers{
		public const int player = 8;
		public const int ground = 9;
		public const int invisibleWalls = 10;
		public const int feet = 11;
		public const int blocks = 12;

		public static string playerString = "Player";
		public static string groundString = "Ground";
		public static string invisibleWallsString = "InvisibleWalls";
		public static string feetString = "Feet";
		public static string blocksString = "Blocks";
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

		public static GameObject explo_x_Button;
		public static GameObject explo_y_Button;
		public static GameObject explo_b_Button;
		public static GameObject implo_x_Button;
		public static GameObject implo_y_Button;
		public static GameObject implo_b_Button;


		public static PlayerType dominantPlayer;

		public static Vector3 respawnShift = -Vector3.right;
	}
	#endregion

	#region LevelNames
	public static class Levels{
		public static string homeScreen = "HomeScreen";
		public static string characterSelect = "CharacterSelect";
		public static string mainMenu = "LevelSelect";
		public static string level1 = "Level1";
		public static string level2 = "Level2";
		public static string level3 = "Level3";
		public static string level4 = "Level4";
		public static string level5 = "Level5";
		public static string level6 = "Level6";
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
		public static PlayerRespawner playerRespawner;
	}
	#endregion

	#region GameColors
	public static class GameColors{
		public static Color cameraBackground = new Color(71f/255f,71f/255f,71f/255f,1f);
		public static Color darkCloset = new Color(21f/255f,21f/255f,21f/255f,1f);
	}
	#endregion


}