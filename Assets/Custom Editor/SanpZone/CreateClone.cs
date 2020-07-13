using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CreateClone : MonoBehaviour
{
   
    private GameObject cloneObject;
    
    private SnapParent p;
    public bool isGrabbed = false;

    private string currentStackElement;

    private bool isStackMached = false;
    private float deviation = 0.3f;
    
   
    private void CreateCloneZone(){
        cloneObject = Instantiate(this.gameObject, transform.GetComponent<GetPositionPoint>().truePosition, transform.GetComponent<GetPositionPoint>().trueRotation);
         Destroy(cloneObject.GetComponent<Throwable>());
         Destroy(cloneObject.GetComponent<CreateClone>());
         CloneSetup cls = cloneObject.AddComponent<CloneSetup>();
         cls.InitializeClone(isStackMached);
    }
  
    private void MatchCheck(){
        if(p.GetCurrentChild() == this.transform.name) isStackMached = true;
        else isStackMached = false;
    }
    private void SetToStatic(){
        transform.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(transform.GetComponent<Throwable>());
        transform.SetParent(p.mainParent);
    }
    public void OnAttachedToHand(){
        MatchCheck();
        isGrabbed = true;
        CreateCloneZone();
    }
    
    public void OnDetachedFromHand(){
        Vector3 RightPosition = transform.GetComponent<GetPositionPoint>().truePosition;
        Quaternion RightRotation = transform.GetComponent<GetPositionPoint>().trueRotation;
         Destroy(cloneObject);
        isGrabbed = false;
        if((transform.position.x <= RightPosition.x + deviation && transform.position.x >= RightPosition.x - deviation) &&
         (transform.position.y <= RightPosition.y + deviation && transform.position.y >= RightPosition.y - deviation) &&
         (transform.position.z <= RightPosition.z + deviation && transform.position.z >= RightPosition.z - deviation)&& isStackMached){
             transform.position = RightPosition;
             transform.rotation = RightRotation;
             SetToStatic();
             p.KillChild();

            Debug.Log("is Matched");
        }
        else{ Debug.Log("false"); 
        return;}
       
    }
   public void Start(){
       p = this.transform.GetComponentInParent<SnapParent>();
   }
}
