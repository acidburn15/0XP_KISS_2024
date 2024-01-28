using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    [SerializeField] private Animator doorAnimator;
    private bool open;
    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] noteArray = GameObject.FindGameObjectsWithTag("Note");
        if (noteArray.Length <= 0)
        {
            doorAnimator.SetTrigger("openDoor");
            open = true;
        }
        /*if (Input.GetKeyDown(KeyCode.G))
        {
            doorAnimator.SetTrigger("openDoor");
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (open)
        {
            Debug.Log("NEXT LEVEL");
            SceneManager.LoadScene(0);
            // load prochaine sc�ne;
        }
    }
}
