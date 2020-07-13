using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Valve.VR.InteractionSystem;



[RequireComponent( typeof( Rigidbody ) )]
[CustomEditor(typeof(SnapperV2))]
public class SnapEditor : Editor
{
  
    public override void OnInspectorGUI(){
    SnapperV2 myTarget = (SnapperV2)target;
    myTarget.snapZonePosition = EditorGUILayout.Vector3Field("Snap zone position:",myTarget.snapZonePosition);
    //myTarget.Parent = (GameObject)EditorGUILayout.ObjectField( myTarget.Parent, typeof(GameObject), true);
    if(GUILayout.Button("Get Snap setup")){
    myTarget.GetSnapPosition();
    }

    }
}
