using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopDragonAni : MonoBehaviour
{

    private Animation Ani;
    void Awake()
    {
        Ani = GetComponent<Animation>();
    }

    void Start()
    {
        InvokeRepeating("LoopDragon",0,20);
    }

    private void LoopDragon()
    {
        if (Ani!=null)
        {
            Ani.Play();
        }
    }
}
