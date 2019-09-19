/*
 * 视野移动控制
 */
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
        Limit();
        transform.Translate(new Vector3(左右 * moveSpeed, mouseScale * scaleSpeed, 前后 * moveSpeed) * Time.deltaTime, Space.World);
      
    }


    void Limit()
    {
        if (transform.position.x > 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -50)
        {
            transform.position = new Vector3(-50, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 140)
        {
            transform.position = new Vector3(transform.position.x, 140, transform.position.z);
        }
        if (transform.position.y < 120)
        {
            transform.position = new Vector3(transform.position.x, 120, transform.position.z);
        }
        if (transform.position.z > 47)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 47);
        }
        if (transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
