/*
 * 通过type区分是什么僵尸
 * 不同的僵尸不懂血量，攻击力，移动速度
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform[] wayPoint;
    int nextPoint = 0;
    PrefabPool prefab;
    ZombieInfo zombie = null;
    private void Awake()
    {
        prefab = PrefabPool.GetPrefab();
        zombie = new ZombieInfo();
        wayPoint = WayPoints.wayPoints;

        string name = gameObject.tag;
        switch (name)
        {
            case "Zombie_1":
                zombie.Speed = 15;
                zombie.Blood = 100;
                zombie.Aggressivity = 100;
                zombie.ZombieType = ZombieType.Zombie_1;
                break;
            case "Zombie_2":
                zombie.Speed = 20;
                zombie.Blood = 200;
                zombie.Aggressivity = 200;
                zombie.ZombieType = ZombieType.Zombie_2;
                break;
            case "Zombie_3":
                zombie.Speed = 25;
                zombie.Blood = 300;
                zombie.Aggressivity = 300;
                zombie.ZombieType = ZombieType.Zombie_3;
                break;
            case "Zombie_4":
                zombie.Speed = 30;
                zombie.Blood = 400;
                zombie.Aggressivity = 400;
                zombie.ZombieType = ZombieType.Zombie_4;
                break;
            case "Zombie_5":
                zombie.Speed = 40;
                zombie.Blood = 500;
                zombie.Aggressivity = 500;
                zombie.ZombieType = ZombieType.Zombie_5;
                break;
            default:
                Debug.Log("none of the zombie");
                break;
        }
    }

    void Update()
    {
        Move(zombie);
    }

    void Move(ZombieInfo zombie)
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
        float step = zombie.Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, wayPoint[nextPoint].localPosition, step);
        transform.LookAt(wayPoint[nextPoint].localPosition);
        if (Vector3.Distance(transform.position, wayPoint[nextPoint].position) < 0.2f)
        {
            nextPoint++;
        }
    }

    //僵尸受伤
    public void Hurt(int damage)
    {
        zombie.Blood -= damage;
        if (zombie.Blood<=0)
        {
            //播放死亡特效，人物消失
            Destroy(this.gameObject);
            GameObject dieEffect = Instantiate(prefab.DieEffect, transform.position, Quaternion.identity);
            Destroy(dieEffect, 3f);
            return;
        }
    }
}
