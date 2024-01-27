using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private string[] killingTags;
    [SerializeField] private Transform spawn;
    [SerializeField] public GameManager gameManager;
    [SerializeField] private TextMeshProUGUI countDead;


    public int death;
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
        if (killingTags.Contains(killingObject.tag))
        {
            gameManager.RespawnNotes();
            transform.position = spawn.position;
            gameManager.addDeath();
            

            // ajouter une mort au compteur du game Manager
        }
    }
}
