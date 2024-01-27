using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public bool PlayerInZone;

    [SerializeField] private string detectionTag = "Player";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(detectionTag))
        {
            PlayerInZone = true;
            transform.Translate(Vector2.up * 50f * Time.deltaTime);
            
        }
       

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(detectionTag))
        {
            PlayerInZone = false;
            transform.Translate(Vector2.down * 50f * Time.deltaTime);
        }


    }
}
    
