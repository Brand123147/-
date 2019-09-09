using System.Collections;
/* 管理炮台
 * 购买每个炮台的money
 * 升级所需要的money
 * 检测当前选中炮台，同步money
 * 炮台类型，名字，价格
 * 
 */
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public struct TurrentData
{
    public int price;
    public int updatePrice;
    public TurrentType turrentType;
}

public enum TurrentType
{
    Cannon,
    Gatling,
    Laser,
    Mortar,
}
public class TurrentManager : MonoBehaviour
{
    
}
