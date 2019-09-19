using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    PrefabPool prefab;
    private void Awake()
    {
        prefab = PrefabPool.GetPrefab();
    }
    public static TurrentData mCurrentSelectWeapon = null;

    public void OnClickCannon(bool isOn)
    {
        if (isOn)
        {
            TurrentData Cannon = new TurrentData();
            Cannon.price = 100;
            Cannon.upOnePrice = 50;
            Cannon.upTwoPrice = 70;
            Cannon.Tower_Base = prefab.Towers[0];
            Cannon.Tower_UpgradeOne = prefab.Towers[1];
            Cannon.Tower_UpgradeTwo = prefab.Towers[2];
            Cannon.turrentType = TurrentType.Cannon;
            mCurrentSelectWeapon = Cannon;
        }
    }

    public void OnClickGatling(bool isOn)
    {
        if (isOn)
        {
            TurrentData Gatling = new TurrentData();
            Gatling.price = 200;
            Gatling.upOnePrice = 80;
            Gatling.upTwoPrice = 90;
            Gatling.Tower_Base = prefab.Towers[3];
            Gatling.Tower_UpgradeOne = prefab.Towers[4];
            Gatling.Tower_UpgradeTwo = prefab.Towers[5];
            Gatling.turrentType = TurrentType.Gatling;
            mCurrentSelectWeapon = Gatling;
        }
    }

    public void OnClickLaser(bool isOn)
    {
        if (isOn)
        {
            TurrentData Laser = new TurrentData();
            Laser.price = 300;
            Laser.upOnePrice = 100;
            Laser.upTwoPrice = 110;
            Laser.Tower_Base = prefab.Towers[6];
            Laser.Tower_UpgradeOne = prefab.Towers[7];
            Laser.Tower_UpgradeTwo = prefab.Towers[8];
            Laser.turrentType = TurrentType.Laser;
            mCurrentSelectWeapon = Laser;
        }
    }

    public void OnClickMortar(bool isOn)
    {
        if (isOn)
        {
            TurrentData Mortar = new TurrentData();
            Mortar.price = 400;
            Mortar.upOnePrice = 120;
            Mortar.upTwoPrice = 130;
            Mortar.Tower_Base = prefab.Towers[9];
            Mortar.Tower_UpgradeOne = prefab.Towers[10];
            Mortar.Tower_UpgradeTwo = prefab.Towers[11];
            Mortar.turrentType = TurrentType.Mortar;
            mCurrentSelectWeapon = Mortar;
        }
    }


}
