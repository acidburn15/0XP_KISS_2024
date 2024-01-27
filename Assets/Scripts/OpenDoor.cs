using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private Transform doorTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerToDoor = doorTransform.position - transform.position;
        if (gameManager.notesCollected == gameManager.numberOfNotes && playerToDoor.magnitude < 5 && Input.GetKeyDown(KeyCode.E))
        {
            gameManager.OpenDoor();
        }
    }

}
