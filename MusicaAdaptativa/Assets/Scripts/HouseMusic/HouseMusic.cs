using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class HouseMusic : MonoBehaviour
{
    public DayNightCycle dayNight;
    EventInstance house;

    private void Start()
    {
        house = RuntimeManager.CreateInstance("event:/House");
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player"))
        {
            dayNight.setInHouse(true);
            dayNight.GetDayInstance().stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            dayNight.GetNightInstance().stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            house.start();           
        }
       
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            dayNight.setInHouse(false);

            if (dayNight.GetDayState() == DayNightCycle.DayState.Day)
            {
                dayNight.GetDayInstance().start();
            }
            else
            {
                dayNight.GetNightInstance().start();
            }
                       
            house.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
