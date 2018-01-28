using UnityEngine;
using System.Collections;

using UnityEngine.UI;

[ CreateAssetMenu( menuName = "Cutscenes/Create Item", order = 1 ) ]
public class CutsceneFrame : ScriptableObject {

	public  Image   Image		= null;

	[Range(0f, 10f)]
	public	float	Duration	= 0;


}
