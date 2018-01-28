using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Cutscene {

	[CustomEditor( typeof( CameraMotionSequence ) )]
	public class CameraMotionSequenceCustomInspector : Editor {

		
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();
        
			CameraMotionSequence sequence = (CameraMotionSequence)target;
			if ( GUILayout.Button( "Add empty transform" ) )
			{
				sequence.Transforms.Add( new  CameraMotionSequence.CameraMotion() );
			}
		}

	}

}
