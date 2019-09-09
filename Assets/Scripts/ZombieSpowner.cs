using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//怪物孵化器
/* 1.加载僵尸，
 * 2.每一只僵尸生成的时间间隔
 * 3.一波僵尸5只，每一只僵尸种类随机
 * 4.每一波僵尸生成时间间隔5s
 * 5.每一波要在前一波被打死后进行计算出场时间
 * 6.给僵尸挂上脚本
 * 
 */
public class ZombieSpowner : MonoBehaviour
{
    private IEnumerator mCurrentCor = null;
    public GameObject[] monsterContainer;
    int mCount = 5;  //数量
    int mWave = 5;    //波数
    float mRate = 1f;  //每一只生成时间间隔
    float mWaveRate = 3f;//每一波生成的时间间隔
    bool isCanBorn = true;  //是否允许僵尸出生

    void Start()
    {
    
    }
    private void Update()
    {
        if (transform.childCount <= 0)
        {
            if (isCanBorn)
            {
                mCurrentCor = WaveSponwer();
                StartCoroutine(mCurrentCor);
                isCanBorn = false;
            }
        }
    }
    //每一只的出生
    IEnumerator Sponwer()
    {
        for (int i = 0; i < mCount; i++)
        {
            int rangeIndex = Random.Range(0, monsterContainer.Length);
            GameObject monster = Instantiate(monsterContainer[rangeIndex]) as GameObject;
            monster.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            monster.transform.SetParent(transform);
            monster.transform.localPosition = Vector3.zero;
            monster.AddComponent<Enemy>();
            yield return new WaitForSeconds(mRate);   
        }
        StopCoroutine(mCurrentCor);
        mCurrentCor = null;
    }

    //每一波的出生
    IEnumerator WaveSponwer()
    {
        --mWave;
        yield return new WaitForSeconds(mWaveRate);
        if (mWave>=0)
        {         
            mCurrentCor = Sponwer();
            StartCoroutine(mCurrentCor);
            isCanBorn = true;
        }
       
    }
}
