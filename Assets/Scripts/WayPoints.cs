/*
 * 僵尸移动路径点
 */
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [HideInInspector]
    public static Transform[] wayPoints;

    // Start is called before the first frame update
    private void Awake()
    {
        wayPoints = new Transform[transform.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = transform.GetChild(i);

        }
    }

}
