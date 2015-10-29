#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;

public class Level2 : MonoBehaviour {
#endregion

	#region Initialize Variables
	
	void Awake () {
		Players.dominantPlayer = PlayerType.Implo;
	}
	#endregion

}
