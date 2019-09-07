using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//怪物孵化器
/* 1.加载僵尸，
 * 2.僵尸生成的时间间隔
 * 3.给僵尸挂上脚本
 * 4.消灭僵尸
 * 
 */
public class MonsterIncubator : MonoBehaviour
{
    Coroutine mCurrentCor = null;
    public GameObject[] monsterContainer;
    int mCount;  //数量
    int mWave;    //波数
    float mRate;  //每一只生成时间间隔
    float mWaveRate = 5f;//每一波生成的时间间隔
    bool isMonsterEnd;  //前一波怪是否结束

    void Start()
    {
     
        
    }

    IEnumerator Sponwer()
    {
        for (int i = 0; i < mCount; i++)
        {

        }
        int rangeIndex = Random.Range(0, monsterContainer.Length);
        GameObject monster = Instantiate(monsterContainer[rangeIndex]) as GameObject;
        monster.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        monster.transform.SetParent(transform);
        monster.transform.localPosition = Vector3.zero;
        monster.AddComponent<Enemy>();
        yield return mCount == 0;
        StopCoroutine(mCurrentCor);
        mCurrentCor = StartCoroutine("WaveSponwer");
    }

    IEnumerator WaveSponwer()
    {
        yield return mRate == 0;
    }
}
