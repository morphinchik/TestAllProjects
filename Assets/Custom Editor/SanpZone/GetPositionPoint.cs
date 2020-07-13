using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPositionPoint : MonoBehaviour
{
    public Vector3 truePosition;
    public Quaternion trueRotation;

    public void SetupPoint(){
        truePosition = this.transform.position;
        trueRotation = this.transform.rotation;
    }
}
