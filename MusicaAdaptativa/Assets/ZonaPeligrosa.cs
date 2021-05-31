using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class ZonaPeligrosa : MonoBehaviour
{
    Bus danger;
    public DayNightCycle dayNight;

    void Start()
    {
        danger = RuntimeManager.GetBus("bus:/AllEvents");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dayNight.GetDayInstance().setPitch(0.95f);

            dayNight.GetNightInstance().setPitch(0.95f);
        }
    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dayNight.GetDayInstance().setPitch(1.0f);

            dayNight.GetNightInstance().setPitch(1.0f);
        }
    }
}
