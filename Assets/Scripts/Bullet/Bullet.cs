/*
 * 根据子弹类型获取子弹伤害
 * 对打中的僵尸实行掉血
 * 打中特效，销毁自身
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletInfo bullet;
    private PrefabPool prefab;
    private void Awake()
    {
        prefab = PrefabPool.GetPrefab();
        bullet = new BulletInfo();
        string tag = gameObject.tag;

        switch (tag)
        {
            case "Cannon_Bullet":
                bullet.bulletType = BulletType.Cannon_Bullet;
                bullet.damage = 50;
                bullet.speed = 40;
                break;
            case "Gatling_Bullet":
                bullet.bulletType = BulletType.Gatling_Bullet;
                bullet.damage = 90;
                bullet.speed = 50;
                break;
            case "Laser_Bullet":
                bullet.bulletType = BulletType.Laser_Bullet;
                bullet.damage = 200;
                bullet.speed = 60;
                break;
            case "Mortar_Bullet":
                bullet.bulletType = BulletType.Mortar_Bullet;
                bullet.damage = 300;
                bullet.speed = 40;
                break;

            default:
                Debug.Log("wrong bullet!!!");
                break;
        }
    }
    public void SetTarget(Transform _target)
    {
        bullet.target = _target;
    }
    private void Update()
    {
        if (bullet.target == null)
        {
            Destroy(this.gameObject);
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, bullet.target.position, bullet.speed * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            Destroy(this.gameObject, 0.1f);
            //实例化打中特效
            other.gameObject.GetComponent<Enemy>().Hurt(bullet.damage);
            GameObject explosionEffect = GameObject.Instantiate(prefab.ExplosionEffect, transform.position, transform.rotation);
            Destroy(explosionEffect, 1f);
        }
    }
}
