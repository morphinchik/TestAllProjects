using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetZoneController : MonoBehaviour
{
  
    public void SetGatherPoints(){
       for(int i=0;i<transform.childCount;i++){
           Transform child = transform.GetChild(i);
           child.GetComponent<GetPositionPoint>().SetupPoint();
           
       }
    }
     
}
