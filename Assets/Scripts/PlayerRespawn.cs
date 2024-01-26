using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawn.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D killingObject)
    {
        if (killingObject.CompareTag("Spike"))
        {
            transform.position = spawn.position;
            // ajouter une mort au compteur du game Manager
        }
    }
}
