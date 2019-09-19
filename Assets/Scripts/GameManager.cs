using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 炮台模块
public class TurrentData
{
    public TurrentType turrentType;
    public int price;
    public int upOnePrice;
    public int upTwoPrice;
    public GameObject Tower_Base;
    public GameObject Tower_UpgradeOne;
    public GameObject Tower_UpgradeTwo;
}

public enum TurrentType
{
    Cannon,
    Gatling,
    Laser,
    Mortar,
}
#endregion


#region 僵尸模块
public class ZombieInfo
{
    public int Blood;   //血量
    public int Speed;   //移速
    public int Aggressivity;    //攻击力
    public ZombieType ZombieType;
}
public enum ZombieType
{
    Zombie_1,
    Zombie_2,
    Zombie_3,
    Zombie_4,
    Zombie_5,
}

#endregion

#region 子弹模块
public class BulletInfo
{
    public float speed;    //速度
    public int damage;    //伤害
    public Transform target;    //朝向目标
    public BulletType bulletType;
}
public enum BulletType
{
    Cannon_Bullet,
    Gatling_Bullet,
    Laser_Bullet,
    Mortar_Bullet,
}
#endregion



