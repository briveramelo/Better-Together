using UnityEngine;
using System.Collections;
using GenericFunctions;
public class GameManager : MonoBehaviour {

	public Controls p1;
	public Controls p2;

	public static GameManager theInstance;

	void Awake() {
		if (theInstance == null) {
			DontDestroyOnLoad(gameObject);
			theInstance = this;
			StaticControls.P1_Controls = p1;
		}
		else if (theInstance !=this){
			Destroy(gameObject);
		}
	}

	#region Controls (explo _ implo)
	public static class StaticControls{
		private static Controls p1_Controls;
		private static Controls p2_Controls;
		private static Controls explo_Controls;
		private static Controls implo_Controls;
		
		public static Controls P1_Controls{
			get{
				return p1_Controls;
			}
			set{
				p1_Controls = value;
				p2_Controls = p1_Controls.Action == "P1_Action" ? GameManager.theInstance.p2 : GameManager.theInstance.p1;
				explo_Controls = p1_Controls;
				implo_Controls = p2_Controls;
			}
		}
		public static Controls P2_Controls{
			get{
				return p2_Controls;
			}
			set{
				p2_Controls = value;
				p1_Controls = p2_Controls.Action == "P2_Action" ? GameManager.theInstance.p1 : GameManager.theInstance.p2;
				explo_Controls = p1_Controls;
				implo_Controls = p2_Controls;

			}
		}
		public static Controls Explo_Controls{get{return explo_Controls;}}
		public static Controls Implo_Controls{get{return implo_Controls;}}
	}
	#endregion
	

}
