using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    [SerializeField] private Animator doorAnimator;

    // sound variables
    [SerializeField] private AudioClip doorClip;
    [SerializeField] private AudioClip portalClip;
    private float portalClipLength = 9.728f;
    private float timer = 10f;
    private bool open;
    private bool clipPlayed = false;
    private int  sceneID = 1;
    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        GameObject[] noteArray = GameObject.FindGameObjectsWithTag("Note");
        if (noteArray.Length <= 0)
        {
            doorAnimator.SetTrigger("openDoor");
            open = true;
            if (!clipPlayed)
            {
                SoundFXManager.Instance.PlaySoundFXClip(doorClip, transform, 1f);
                clipPlayed = true;
            }
            else if (timer > portalClipLength)
            {
                SoundFXManager.Instance.PlaySoundFXClip(portalClip, transform, 1f);
                timer = 0f;
            }

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
            sceneID = SceneManager.GetActiveScene().buildIndex;
            if (sceneID <= 3)
            {
                SceneManager.LoadScene(sceneID+1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
            // load prochaine sc�ne;
        }
    }
}
