using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class DistanceToEnemy : MonoBehaviour
{

    public Transform enemyTr;
    public float maxDistance = 10.0f;

    EventInstance health;
    float parameter;
    void Start()
    {
        //Creamos la instancia del sonido del corazon
        health = RuntimeManager.CreateInstance("event:/HeartBeat");
        health.start();
    }

    void Update()
    {
        //En funcion de la distancia al enemido vamos cambiado el parametro de este evento que controla el volumen y el pitch
        float distance = Vector3.Distance(enemyTr.position, transform.position);

        if (distance > maxDistance)
        {
            parameter = 0.0f;
        }
        else
        {
            
            parameter = Mathf.Abs(1.0f - (distance / maxDistance));
        }

        health.setParameterByName("Health", parameter);
    }
}
