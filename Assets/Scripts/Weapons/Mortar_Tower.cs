/*
 * 判断敌人进入，离开
 * 生成炮弹，或者激光等对应的炮弹
 * 枪头跟踪敌人旋转
 * 每一秒生成一个炮弹，炮弹的移动让bullet脚本自己控制
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar_Tower : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> mEnemys = new List<GameObject>();
    private float mShootTime = 0f;
    private Transform mFirePos;
    private PrefabPool mBullet;


    private void Awake()
    {
        mFirePos = transform.Find("Turret/FirePos");
        mBullet = PrefabPool.GetPrefab();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            mEnemys.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            mEnemys.Remove(other.gameObject);
        }
    }


    private void Update()
    {
        //如果进入射击范围敌人  数量>0  开始判断射击
        if (mEnemys.Count > 0)
        {
            if (mShootTime == 0)
            {
                Shoot();
            }
            mShootTime += Time.deltaTime;
            if (mShootTime >= 1f)
            {
                mShootTime = 0;
            }

        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(mBullet.Mortar_bullet);
        bullet.transform.SetParent(mFirePos);
        bullet.transform.localPosition = Vector3.zero;
    }
}
