using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;
public class TestTest : MonoBehaviour
{
    private PrefabPool prefab;
    public GameObject cube;
    public float speed = 50f;
    private void Awake()
    {
        prefab = PrefabPool.GetPrefab();
        prefab.Cannon_bullet.transform.position = Vector3.zero;
    }
    //protected Highlighter hi;
    //private void Awake()
    //{
    //    hi = gameObject.AddComponent<Highlighter>();
    //}
    //private void Start()
    //{
    //    hi.ConstantOn(Color.red);
    //}
    //private void OnMouseEnter()
    //{
    //    hi.ConstantOn(Color.black);
    //}
    //private void OnMouseExit()
    //{
    //    hi.Off();
    //}

    //void OnParticleTrigger()
    //{
    //    ParticleSystem ps = GetComponent<ParticleSystem>();

    //    // particles
    //    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    //    List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

    //    // get
    //    int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    //    int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

    //    // iterate
    //    for (int i = 0; i < numEnter; i++)
    //    {
    //        ParticleSystem.Particle p = enter[i];
    //        p.startColor = new Color32(255, 0, 0, 255);
    //        enter[i] = p;
    //    }
    //    for (int i = 0; i < numExit; i++)
    //    {
    //        ParticleSystem.Particle p = exit[i];
    //        p.startColor = new Color32(0, 255, 0, 255);
    //        exit[i] = p;
    //    }

    //    // set
    //    ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    //    ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    //}


    private void Update()
    {
        
        
    }
}
