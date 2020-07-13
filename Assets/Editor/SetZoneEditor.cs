using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Valve.VR.InteractionSystem;

[CustomEditor(typeof(SetZoneController))]
public class SetZoneEditor : Editor
{
    
     public override void OnInspectorGUI(){
        SetZoneController myTarget = (SetZoneController)target;
        if(GUILayout.Button("Get Gather Points")){
           myTarget.SetGatherPoints();
        }

     }
    
}
