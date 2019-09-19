/*
 * 放置炮台
 * 挂上该炮台对应的武器脚本
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTower : MonoBehaviour
{
    PrefabPool prefab;
    private void Awake()
    {
        prefab = PrefabPool.GetPrefab();
    }
    //创建炮台的位置
    public void SetTowerPositon(GameObject tower)
    {
        GameObject go = Instantiate(tower);
        go.transform.SetParent(transform);
        go.transform.localPosition = new Vector3(0, 2.6f, 0);
        GameObject buildEffect = Instantiate(prefab.BuildEffect, go.transform.position, Quaternion.identity);
        Destroy(buildEffect, 1f);
    }
    
}
