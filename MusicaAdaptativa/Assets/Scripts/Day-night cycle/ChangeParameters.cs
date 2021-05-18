using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class ChangeParameters : MonoBehaviour
{
    public LightingManager lightingManager;

    enum DayState { Day,Night}

    EventInstance day;
    EventInstance night;
    PARAMETER_ID volParameterId;
    DayState dayState;

    //[SerializeField]
    //[Range(0f, 1f)]
    //float volume;


    void Start()
    {
        day = RuntimeManager.CreateInstance("event:/Day");
        night = RuntimeManager.CreateInstance("event:/Night");


        //EventDescription volEventDescription;
        //day.getDescription(out volEventDescription);
        //PARAMETER_DESCRIPTION volParameterDescription;
        //volEventDescription.getParameterDescriptionByName("Volume", out volParameterDescription);
        //volParameterId = volParameterDescription.id;

        day.start();
    }

    
    void Update()
    {
        float timeOfDay = lightingManager.getTimeOfDay();

        if((timeOfDay >= 18 || timeOfDay < 6) && dayState != DayState.Night)
        {
            Debug.Log("Noche");
            dayState = DayState.Night;
           
            day.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            night.start();
        }
        else if((timeOfDay >=6 && timeOfDay < 18) && dayState != DayState.Day)
        {
            Debug.Log("Dia");
            dayState = DayState.Day;
            night.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            day.start();
        }
        
    }



}
