using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewControl : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float scaleSpeed = -600f;


    void Update()
    {
        float 左右 = Input.GetAxis("Horizontal");
        float 前后 = Input.GetAxis("Vertical");
        float mouseScale = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(new Vector3(左右 * moveSpeed, mouseScale * scaleSpeed, 前后 * moveSpeed) * Time.deltaTime, Space.World);

    }
}
