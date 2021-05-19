using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class UnderwaterSound : MonoBehaviour
{
    BoxCollider coll;
    float topPos, bottomPos;

    private void Start()
    {
        coll = GetComponent<BoxCollider>();
        
        topPos = transform.position.y + coll.bounds.size.y/2;
        bottomPos = transform.position.y - coll.bounds.size.y/ 2;
        Debug.Log(transform.position.y);
        Debug.Log(coll.size.y);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float cutoff = (other.transform.position.y - bottomPos) / (topPos - bottomPos);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("UnderwaterFilterCutoff", cutoff);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("UnderwaterFilterCutoff", 2);
        }
    }
}
