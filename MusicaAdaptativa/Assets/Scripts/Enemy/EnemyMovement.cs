using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float time = 3.0f;
    public Transform pos1;
    public Transform pos2;

    Vector3 target;
    float currenTime;
  
    void Start()
    {
        currenTime = time;
        target = pos1.position;
    }

   
    void Update()
    {
        currenTime -= Time.deltaTime;

        if(currenTime<=0)
        {
            currenTime = time;
            if(target == pos1.position)
            {
                target = pos2.position;
            }
            else
            {
                target = pos1.position;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
