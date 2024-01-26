using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class pickNote : MonoBehaviour
{
    public string[] pickableItemTags;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (pickableItemTags.Contains(other.tag))
        {
            Destroy(other.gameObject);
        }
    }
}
