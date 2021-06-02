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
        //Creamos el evento que tiene la musica de la casa
        house = RuntimeManager.CreateInstance("event:/House");
    }

    //Al entrar en la casa paramos las instancia de la musica del dia y de la noche y hacemos sonar la musica de la casa
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

    //Al salir de la casa paramos la musica de la casa y paramos la musica del dia o de la noche,dependiendo de la hora que sea
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
