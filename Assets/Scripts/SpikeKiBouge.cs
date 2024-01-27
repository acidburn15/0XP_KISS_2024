using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeKiBouge : MonoBehaviour
{
    private Animator animator;
    private float time = 1;
    private int seconde;
    private int verif = 0;
    private int verif2 = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        seconde = Mathf.FloorToInt(time % 60);

        if (verif == 0)
        {
           if (seconde % 3 == 0)
                   {
                       animator.SetTrigger("Spike_Up_Trigger");
                       verif = 1;
                       
                   }
        }

        

        if (seconde % 3 != 0)
        {
            verif = 0;
        }
        
        

    }
}
