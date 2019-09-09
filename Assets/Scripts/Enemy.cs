using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform[] wayPoint;
    int nextPoint = 0;
    float speed = 30f;

    private void Awake()
    {
        wayPoint = WayPoints.wayPoints;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (nextPoint >= wayPoint.Length)
        {
            //被打死TODO
            Destroy(gameObject, 1f);
            return;
        }

        //朝向拐点目标向量
        //Vector3 unitVector = (wayPoint[nextPoint].position - transform.position).normalized;
        //transform.Translate(unitVector * Time.deltaTime * speed);
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, wayPoint[nextPoint].localPosition, step);
        transform.LookAt(wayPoint[nextPoint].localPosition);
        if (Vector3.Distance(transform.position, wayPoint[nextPoint].position) < 0.2f)
        {
            nextPoint++;
        }
    }

  
}
