using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class SnapperV2 : MonoBehaviour
{
  
  private GameObject snapZoneObj = null;
  public Vector3 snapZonePosition = Vector3.zero;
  public Quaternion snapZoneRotation;
  [SerializeField] private Transform Parent;
  private bool isAttached;
  public bool isSnapped;

  // true if this = currentChild
  private bool isMached;
  
  private bool isInCollision;

      public void GetSnapPosition(){
        snapZonePosition = transform.position;
        snapZoneRotation = transform.rotation;   
      }
      //make clone of  this object and delete extra components
      private void MakeSnapZone(){
        snapZoneObj =  Instantiate(this.gameObject,snapZonePosition,snapZoneRotation);
        Destroy(snapZoneObj.GetComponent<Throwable>());
        Destroy(snapZoneObj.GetComponent<SnapperV2>());
        //snapZoneObj.GetComponent<Renderer>().enabled = false;
      }

      //snap object and set it  kinematic
      private void Snap(){
        transform.position = snapZonePosition;
        transform.rotation = snapZoneRotation;
        transform.GetComponent<Rigidbody>().isKinematic = true;
        transform.SetParent(Parent);
        Destroy(transform.GetComponent<SnapperV2>());
        Destroy(transform.GetComponent<Throwable>());
      }

        //attaching event
        public void OnAttachedToHand(){
          CheckForQueueMatch();
          MakeSnapZone();
          isAttached = true;
          transform.GetComponent<Collider>().isTrigger=true;
          Debug.Log(isAttached);
          Debug.Log(snapZoneRotation);    
        }


        //detach event
        public void OnDetachedFromHand(){
        isAttached = false;
        //this.GetComponent<Collider>().isTrigger=false;
        //Destroy(snapZoneObj);
        Debug.Log(isAttached);
        }

        //check for currentChild match
      public void CheckForQueueMatch(){
        var childName = Parent.GetComponent<SnapParent>().GetCurrentChild();
          if( childName == transform.name){
            isMached = true;
            Debug.Log(childName + transform.name);
          }
          else isMached=false;
      }


      //snap zone event
      public void OnTriggerStay(Collider other){
        isInCollision = true;
      if(other.name==snapZoneObj.name && isAttached==false && isMached){
      this.Snap();
      Destroy(snapZoneObj);
      Parent.GetComponent<SnapParent>().KillChild();
      }
      }
      
      void Start(){
        Parent = transform.parent;
      }
      // Update is called once per frame
      void Update()
      {
        
      }
}
