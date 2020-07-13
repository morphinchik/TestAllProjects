using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public InputField surnameInputF = null;
    public InputField nameInputF = null;
    public InputField lastInputPressed = null;

    void Update()
    {
        if (surnameInputF.isFocused)
        {
            lastInputPressed = surnameInputF;
        }
        if (nameInputF.isFocused)
        {
            lastInputPressed = nameInputF;
        }
    }
    public void alphabetFunction()
    {
        
        if (this.gameObject.name == "BackSpace" )
        {
         lastInputPressed.text = lastInputPressed.text.Substring(0, lastInputPressed.text.Length - 1);
        }
        else
        lastInputPressed.text += this.GetComponentInChildren<TMP_Text>().text;    
    }
   

}
