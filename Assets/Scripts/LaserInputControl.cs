using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserInputControl : MonoBehaviour
{
    public SteamVR_Action_Boolean LaserOnOff;
    public SteamVR_Input_Sources handType;
    public GameObject Pointer;
    private bool _isActive;

    void Start()
    {
        LaserOnOff.AddOnStateUpListener(KeyUp, handType);
        _isActive = false;
    }

    public void KeyUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (_isActive)
        {
            Pointer.SetActive(false);
            _isActive = false;
        }
        else
        {
            Pointer.SetActive(true);
            _isActive = true;
        }
    }
}
