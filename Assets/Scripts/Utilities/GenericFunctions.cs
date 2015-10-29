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

	#region Constants
	public static class Constants{
		public static float near1 = 0.95f;
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

	#region Levels
	public static class Levels{
		public static string homeScreen = 		"0_HomeScreen";
		public static string levelSelect = 		"1_LevelSelect";
		public static string level1 = 			"2_Level1";
		public static string level2 = 			"3_Level2";
		public static string level3 = 			"4_Level3";
		public static string level4 = 			"5_Level4";
		public static string level5 = 			"6_Level5";
		public static string level6 = 			"7_Level6";

		public static void LoadLevel(LevelNames levelName){
			Application.LoadLevel(ConvertLevelNameToString(levelName));
		}

		public static LevelNames ConvertStringToLevelName(string levelString){
			if (levelString == homeScreen){
				return LevelNames.HomeScreen;
			}
			else if (levelString == levelSelect){
				return LevelNames.LevelSelect;
			}
			else if (levelString == level1){
				return LevelNames.Level1;
			}
			else if (levelString == level2){
				return LevelNames.Level2;
			}
			else if (levelString == level3){
				return LevelNames.Level3;
			}
			else if (levelString == level4){
				return LevelNames.Level4;
			}
			else if (levelString == level5){
				return LevelNames.Level5;
			}
			else{
				return LevelNames.Level6;
			}

		}

		#region ConvertLevelNameToString
		static string ConvertLevelNameToString(LevelNames levelName){
			if (levelName == LevelNames.HomeScreen){
				return homeScreen;
			}
			else if (levelName == LevelNames.LevelSelect){
				return levelSelect;
			}
			else if (levelName == LevelNames.Level1){
				return level1;
			}
			else if (levelName == LevelNames.Level2){
				return level2;
			}
			else if (levelName == LevelNames.Level3){
				return level3;
			}
			else if (levelName == LevelNames.Level4){
				return level4;
			}
			else if (levelName == LevelNames.Level5){
				return level5;
			}
			else if (levelName == LevelNames.Level6){
				return level6;
			}
			else {
				return Application.loadedLevelName;
			}
		}
		#endregion


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

	#region GameColor
	public static class GameColor{

		public static Color clearWhite = new Color(1f,1f,1f,0f);
		public static Color star = new Color(255f/255f, 206f/255f,0f,1f);
		public static Color fader = new Color(0f,0f,0f,200f/255f);

		public static class Player{
			public static Color explo = new Color(255f/255f,100f/255f,0f,255f/255f);
			public static Color implo = new Color(119f/255f,0f,161f/255f,255f/255f);

			public static Color fadedImplo = new Color (40f/255f,10f/255f,54f/255f,255f/255f);
		}

		public static class CameraBackground{
			public static Color standard = new Color(71f/255f,71f/255f,71f/255f,1f);
			public static Color darkCloset = new Color(21f/255f,21f/255f,21f/255f,1f);
		}

		public static class Button{
			public static Color availableLevel = Color.white;
			public static Color lockedLevel = Color.grey;
			public static Color selectedLevel = GameColor.Player.explo;
		}

		public static IEnumerator TransitionMaterialColor(Material mat, string colorPropertyName, Color targetColor, float lerpFraction){
			Color currentColor = mat.GetColor(colorPropertyName);
			while (Mathf.Abs (currentColor.r-targetColor.r)>0.001f||
			       Mathf.Abs (currentColor.g-targetColor.g)>0.001f||
			       Mathf.Abs (currentColor.b-targetColor.b)>0.001f||
			       Mathf.Abs (currentColor.a-targetColor.a)>0.001f){
				currentColor = Color.Lerp (currentColor, targetColor,lerpFraction);
				mat.SetColor(colorPropertyName,currentColor); 
				yield return null;
			}
			mat.SetColor(colorPropertyName,targetColor);
			yield return null;
		}

		public static IEnumerator TransitionMaterialFloat(Material mat, string floatPropertyName, float targetStrength, float lerpFraction){
			float currentStrength = mat.GetFloat(floatPropertyName);
			while (Mathf.Abs (currentStrength-targetStrength)>0.01f){
				currentStrength = Mathf.Lerp (currentStrength, targetStrength,lerpFraction);
				mat.SetFloat(floatPropertyName,currentStrength); 
				yield return null;
			}
			mat.SetFloat(floatPropertyName,targetStrength);
			yield return null;
		}
	}
	#endregion


}