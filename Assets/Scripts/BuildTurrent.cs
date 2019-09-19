using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using HighlightingSystem;
/* 创建炮台
 * 获取到炮台的价格，类型，升级价格，炮台的预制体
 * 检测炮塔是否是炮塔层，炮塔上是否有炮台
 * 炮塔上如果有炮台可以卖掉炮台或者升级炮台，金币增加或减少,卖的炮台升级越高卖的钱越多，升级越低卖的越便宜但是总体返还还是要比原来买的钱少
 * 如果没有炮台则可以建设炮台金币减少
 * 
 */
public class BuildTurrent : MonoBehaviour
{
    static int mMoneyCount = 700;
    public Text mTotalMoney;
    static bool isCanBuild = true;
    private void Awake()
    {
        mTotalMoney.text = "￥" + mMoneyCount.ToString();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)   //点击到ugui不触发
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                bool isGet = Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("TowerBase"), QueryTriggerInteraction.Ignore);
                if (isGet)
                {
                    GameObject towerBase = hit.collider.gameObject;
                    SetTower setTower = towerBase.GetComponent<SetTower>();
                    if (towerBase.transform.childCount <= 0)
                    {
                        //没有炮台则创建炮台
                        if (setTower == null)
                        {
                            setTower = towerBase.AddComponent<SetTower>();
                        }
                        if (UIManager.mCurrentSelectWeapon != null)
                        {
                            MoneyChange(-UIManager.mCurrentSelectWeapon.price);
                            if (isCanBuild)//是否允许建炮
                            {
                                setTower.SetTowerPositon(UIManager.mCurrentSelectWeapon.Tower_Base);
                            }
                        }
                    }
                    else
                    {
                        //有炮台卖掉或者升级
                    }
                }
            }
        }


    }

    private void MoneyChange(int num)
    {
        if (num < 0 && Mathf.Abs(num) > mMoneyCount)   //金钱不足
        {
            mTotalMoney.GetComponent<Animation>().Play();
            isCanBuild = false;
            return;
        }
        mMoneyCount += num;
        mTotalMoney.text = "￥" + mMoneyCount.ToString();
        isCanBuild = true;
    }
}
