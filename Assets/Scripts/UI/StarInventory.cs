#region Declaration
using UnityEngine;
using System.Collections;

public class StarInventory : MonoBehaviour {
#endregion

	#region Initialize Variables
	public static StarInventory theInstance;
	private bool[] starCheck;

	void Awake () {
		if (theInstance == null) {
			DontDestroyOnLoad(gameObject);
			theInstance = this;
			starCheck = new bool[6];
		}
		else if (theInstance !=this){
			Destroy(gameObject);
		}
	}
	#endregion

	public IEnumerator AddAStar(LevelNames levelName){
		if ((int)levelName>=1 && (int)levelName<starCheck.Length){
			starCheck[(int)levelName-1] = true;
		}
		yield return null;
	}
}
