//using UnityEngine;
//using UnityEditor;
//using System.Collections;
//
//[ExecuteInEditMode]
//[System.Serializable]
//public class PivotSetter : Editor {
//
//	public enum Corner{
//		Front_TopLeft,
//		Front_TopRight,
//		Front_BottomLeft,
//		Front_BottomRight,
//		Back_TopLeft,
//		Back_TopRight,
//		Back_BottomLeft,
//		Back_BottomRight
//	}
//	public Corner corner;
//
//	public void OnInspectorGUI(){
//		foreach (Transform tran in transform.GetComponentsInChildren<Transform>()){
//			if (corner == Corner.Front_TopLeft){
//				tran.localPosition = 
//					new Vector3 (tran.localScale.x/2,
//					             -tran.localScale.y/2,
//					             tran.localScale.z/2);
//			}
//			else if (corner == Corner.Front_TopRight){
//				tran.localPosition = 
//					new Vector3 (-tran.localScale.x/2,
//					             -tran.localScale.y/2,
//					             tran.localScale.z/2);
//			}
//			else if (corner == Corner.Front_BottomLeft){
//				tran.localPosition = 
//					new Vector3 (tran.localScale.x/2,
//					             tran.localScale.y/2,
//					             tran.localScale.z/2);
//			}
//			else if (corner == Corner.Front_BottomRight){
//				tran.localPosition = 
//					new Vector3 (-tran.localScale.x/2,
//					             tran.localScale.y/2,
//					             tran.localScale.z/2);
//			}
//			else if (corner == Corner.Back_TopLeft){
//				tran.localPosition = 
//					new Vector3 (tran.localScale.x/2,
//					             -tran.localScale.y/2,
//						         -tran.localScale.z/2);
//			}
//			else if (corner == Corner.Back_TopRight){
//				tran.localPosition = 
//					new Vector3 (-tran.localScale.x/2,
//					             -tran.localScale.y/2,
//					             -tran.localScale.z/2);
//			}
//			else if (corner == Corner.Back_BottomLeft){
//				tran.localPosition = 
//					new Vector3 (tran.localScale.x/2,
//					             tran.localScale.y/2,
//					             -tran.localScale.z/2);
//			}
//			else if (corner == Corner.Back_BottomRight){
//				tran.localPosition = 
//					new Vector3 (-tran.localScale.x/2,
//					             tran.localScale.y/2,
//					             -tran.localScale.z/2);
//			}
//		}
//
//	}
//}
