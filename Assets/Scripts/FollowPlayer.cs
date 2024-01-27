using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private string[] playerTag;
    [SerializeField] private Animator noteAnimator;
    public GameManager gameManager;

    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private AudioClip noteSound;
    [SerializeField] private float noteVolume = 1f;

    public bool picked = false;
    public bool endLevel = false;
    private int offset;
    Transform playerTransform;
    public static float leftOrRight;
    [SerializeField] private TextMeshProUGUI countNote;

    public int note;

    //Variable pour le slerp
    private Transform endPos;
    Vector3 centerPoint;
    Vector3 startRelCenter;
    Vector3 endRelCenter;

    // Start is called before the first frame update
    void Start()
    {
        endPos = GameObject.FindGameObjectWithTag("Door").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (picked && !endLevel)
        {
            FollowTarget(playerTransform);


        }
        else if (endLevel)
        {
            moveToDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (endLevel && col.CompareTag("Door"))
        {
            explosion.transform.position = endPos.position + new Vector3(0.4f, -0.4f, -1);
            Instantiate(explosion);
            Destroy(gameObject);
        }
        else if (playerTag.Contains(col.tag) && !picked)
        {
            gameManager.AddNoteCollected();
            SoundFXManager.Instance.PlaySoundFXClip(noteSound, transform, 1f);
            offset = gameManager.notesCollected;
            picked = true;
            playerTransform = col.transform;


        }
    }

    private void FollowTarget(Transform playerTransform)
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(playerTransform.position.x - (offset * leftOrRight), playerTransform.position.y, 0),
            6f * Time.deltaTime);
    }

    private void moveToDoor()
    {

        GetCenter(Vector3.up * 4);

        transform.position = Vector3.Slerp(startRelCenter, endRelCenter, 3 * Time.deltaTime);
        transform.position += centerPoint;
        //transform.position = Vector3.Lerp(transform.position, doorTransform.position, 3f * Time.deltaTime);
        //transform.position = Vector3.Slerp(transform.position, endPos.position, 3 * Time.deltaTime);
    }

    private void GetCenter(Vector3 direction)
    {
        centerPoint = (transform.position + endPos.position) * .5f;
        centerPoint -= direction;
        startRelCenter = transform.position - centerPoint;
        endRelCenter = endPos.position - centerPoint;
    }

    public void ChangePickedState()
    {
        picked = false;
    }

    public void EndLevel()
    {
        endLevel = true;
    }

    public void ChangeLeftOrRightState(float moveX)
    {
        if (moveX != 0)
        {
            leftOrRight = moveX;
        }
    }

    public bool getEndLevel()
    {
        return endLevel;
    }

    public AudioClip GetNoteSound()
    {
        return noteSound;
    }

    public float GetNoteSoundVolume()
    {
        return noteVolume;
    }
}


