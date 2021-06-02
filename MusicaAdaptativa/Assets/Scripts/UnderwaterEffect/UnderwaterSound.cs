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
    }

    //Mientras que el jugador este en el agua, a medida que baja mas profundo vamos cambiando el parametro global
    //para que asi se escuche menos la musica de fondo
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float cutoff = (other.transform.position.y - bottomPos) / (topPos - bottomPos);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("UnderwaterFilterCutoff", cutoff);
        }
    }

    //Al salir del agua reestablecemos el parametro global, para que todo vuelva a estar como antes
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("UnderwaterFilterCutoff", 2);
        }
    }
}
