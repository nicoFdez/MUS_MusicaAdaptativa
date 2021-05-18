using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class UnderwaterSound : MonoBehaviour
{
    EventInstance underwaterFilter;

    void Start()
    {
        underwaterFilter = RuntimeManager.CreateInstance("snapshot:/Underwater");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            underwaterFilter.start();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            underwaterFilter.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
