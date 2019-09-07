using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    WayPoints wayPoints = new WayPoints();
    private Transform[] wayPoint;
    int index = 0;
    float speed = 10f;
    private void Awake()
    {
        wayPoint = wayPoints.wayPoints;
    }
    void Update()
    {
        
    }

    void Move()
    {
        if (index > wayPoint.Length - 1)
        {
            return;
        }
        //朝向拐点目标向量
        Vector3 unitVector = (wayPoint[index].position - transform.position).normalized;
        transform.Translate(unitVector * Time.deltaTime * speed);
    }
}
