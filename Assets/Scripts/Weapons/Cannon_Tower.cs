/*
 * 判断敌人进入，离开
 * 生成炮弹，或者激光等对应的炮弹
 * 枪头跟踪敌人旋转
 * 每一秒生成一个炮弹，炮弹的移动让bullet脚本自己控制
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cannon_Tower : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> mEnemys;
    private float mShootTime = 0f;
    private float rotationSpeed = 10;
    private Transform mFirePos;
    private PrefabPool mBullet;
    private Transform mTurret;
    private Transform mBase;

    private void Awake()
    {
        mTurret = transform.Find("Turret");
        mBase = transform.Find("Base");
        mFirePos = mTurret.Find("FirePos");
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
            LookAtToZombie();
        }
    }

    private void Shoot()
    {
        for (int i = 0; i < mEnemys.Count; i++)
        {
            if (mEnemys[i] == null)
            {
                mEnemys.RemoveAt(i);
                i -= 1;
            }
        }
        if (mEnemys.Count > 0)//更新完检测
        {
            GameObject bullet = Instantiate(mBullet.Cannon_bullet);
            bullet.transform.SetParent(mFirePos);
            bullet.transform.localPosition = Vector3.zero;
            //子弹目标
            bullet.GetComponent<Bullet>().SetTarget(mEnemys[0].transform.Find("Pos"));
            // mTurret.LookAt(mEnemys[0].transform.Find("Pos"));

        }
    }

    //炮台旋转
    private void LookAtToZombie()
    {
        for (int i = 0; i < mEnemys.Count; i++)
        {
            if (mEnemys[i] == null)
            {
                mEnemys.RemoveAt(i);
                i -= 1;
            }
        }
        mTurret.rotation = Quaternion.Slerp(mTurret.rotation, Quaternion.LookRotation(mEnemys[0].transform.Find("Pos").position - mTurret.position), rotationSpeed * Time.deltaTime);

        //mBase.localRotation = Quaternion.Euler(0, mTurret.rotation.y, 0);
        mBase.Rotate(new Vector3(0, mTurret.localRotation.y, 0));
    }
}
