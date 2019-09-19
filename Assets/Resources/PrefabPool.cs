using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabPool", menuName = "PrefabPoolContainer")]
public class PrefabPool : ScriptableObject
{
    public static PrefabPool GetPrefab()
    {
        // 通过resource加载
        return Resources.Load<PrefabPool>("PrefabPool");
    }

    #region Bullet
    public GameObject Cannon_bullet;
    public GameObject Gatling_bullet;
    public GameObject Mortar_bullet;
    public GameObject Laser_bullet;
    #endregion


    #region Effect
    public GameObject BuildEffect;
    public GameObject GatlingbulEff;
    public GameObject ExplosionEffect;
    public GameObject DieEffect;
    #endregion



    public List<GameObject> Towers = new List<GameObject>();
    public List<GameObject> Zombies = new List<GameObject>();

}
