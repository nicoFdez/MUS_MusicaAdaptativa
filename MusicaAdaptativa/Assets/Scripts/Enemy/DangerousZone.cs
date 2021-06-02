using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class DangerousZone : MonoBehaviour
{
    public DayNightCycle dayNight;

    //Al entrar en la zona peligrosa bajamos un poco el pitch de los eventos que tienen la musica de dia y de noche
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dayNight.GetDayInstance().setPitch(0.95f);

            dayNight.GetNightInstance().setPitch(0.95f);
        }
    
    }

    //Al salir de la zona peligrosa reestablecemos el pitch de los eventos que tienen la musica de dia y de noche
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dayNight.GetDayInstance().setPitch(1.0f);

            dayNight.GetNightInstance().setPitch(1.0f);
        }
    }
}
