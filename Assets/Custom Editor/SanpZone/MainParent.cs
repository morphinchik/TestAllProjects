using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainParent : MonoBehaviour
{
    // Start is called before the first frame update
     private Stack <string> ObjectsName = new Stack<string>();
     public string lastChild;

     public void AddToParent(string name){
         ObjectsName.Push(name);
         lastChild = name;
         Debug.Log(lastChild);

     }
     public void KillLastChild(){
         ObjectsName.Pop();
         lastChild = ObjectsName.Peek();
     }
     public string GetCurrentChildName(){
         return lastChild;
     }
}
