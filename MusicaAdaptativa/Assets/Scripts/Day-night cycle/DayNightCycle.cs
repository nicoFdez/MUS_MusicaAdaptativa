using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class DayNightCycle : MonoBehaviour
{
    public LightingManager lightingManager;

    public enum DayState { Day,Night}

    EventInstance day;
    EventInstance night;
    PARAMETER_ID volParameterId;
    DayState dayState;

    bool inHouse = false;

    void Start()
    {
        //Creamos los eventos que tienen la musica de dia y de noche
        day = RuntimeManager.CreateInstance("event:/Day");
        night = RuntimeManager.CreateInstance("event:/Night");
        //La musica de dia empieza a sonar al principio de la ejecucion
        day.start();
    }

    
    void Update()
    {

        //En función de la hora del dia hacemos que suene una musica o utra
        float timeOfDay = lightingManager.getTimeOfDay();

        if ((timeOfDay >= 18 || timeOfDay < 6) && dayState != DayState.Night) //Suena la musica de noche
        {
            dayState = DayState.Night;

            if(!inHouse)
            {
                day.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                night.start();
            }
            
        }
        else if ((timeOfDay >= 6 && timeOfDay < 18) && dayState != DayState.Day) //Suena la musica de dia
        {
            dayState = DayState.Day;
            if (!inHouse)
            {
                night.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                day.start();
            }
        }

    }

    public EventInstance GetDayInstance()
    {
        return day;
    }

    public EventInstance GetNightInstance()
    {
        return night;
    }

    public DayState GetDayState()
    {
        return dayState;
    }

    public void setInHouse(bool b)
    {
        inHouse = b;
    }
}
