using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class LaserInput : MonoBehaviour
{
    public GameObject currentObject;
    private int _currentID;

    void Start()
    {
        currentObject = null;
        _currentID = 0;
    }

    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0f);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            int id = hit.collider.gameObject.GetInstanceID();

            if (_currentID != id)
            {
                _currentID = id;
                currentObject = hit.collider.gameObject;

                string name = currentObject.name;

                Debug.Log("BBB");
            }
        }
    }
}
