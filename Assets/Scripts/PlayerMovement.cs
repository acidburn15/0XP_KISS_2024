using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AudioClip[] footsteps;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform doorTransform;
    [SerializeField] private SoundMixerManager soundMixerManager;
    [SerializeField] private AudioSource musicManager;

    private GameObject note;
    private bool top;
    private bool cooldown = false;
    public float isInverted = 1;
    //private bool epicIsPlayed = false;

    // delai pour sound
    private float waitTime = 0.25f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        doorTransform = GameObject.FindGameObjectWithTag("Door").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.notesCollected == gameManager.numberOfNotes)
        {
            float distanceWithDoor = (doorTransform.position - transform.position).magnitude;

                if (distanceWithDoor < 10f)
                {
                    soundMixerManager.SetMusicVolume(musicManager.volume - ((10 - distanceWithDoor)) * 0.2f);//max volume setter par le jouer - 20% par unit�s de magnitude; 10 - magnitude -> sound maximum - ((10 - magnitude)*0.2) 
                }
            

        }
        Move();
        InvertGravity();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            cooldown = false;
        }
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        note = GameObject.FindGameObjectWithTag("Note");
        bool endLevel = false;

        timer += Time.deltaTime;

        if (note != null)
        {
            note.GetComponent<FollowPlayer>().ChangeLeftOrRightState(moveX);
            endLevel = note.GetComponent<FollowPlayer>().getEndLevel();
        }
        
        Vector3 moveDirection = new Vector3(moveX, 0).normalized;

        transform.position +=  moveDirection * (moveSpeed * Time.deltaTime);

        // Animation
        if (moveX * isInverted > 0)
        {
            playerAnimator.Play("Player right");
            if (timer > waitTime && !cooldown)
            {
                SoundFXManager.Instance.PlayRandomSoundFXClip(footsteps, transform, 1f);
                timer = 0;
            }
        }

        else if (moveX * isInverted < 0)
        {
            playerAnimator.Play("Player left");
            if (timer > waitTime && !cooldown)
            {
                SoundFXManager.Instance.PlayRandomSoundFXClip(footsteps, transform, 1f);
                timer = 0;
            }
        }

        else if (moveX == 0 && !endLevel)
        {

            playerAnimator.Play("Player idle");
        }
        else if (endLevel)
        {
            playerAnimator.Play("Player epic");
        }
    }
    
    private void InvertGravity()
    {
        if (!cooldown && Input.GetKeyDown(KeyCode.Space))
        {
            cooldown = true;
            isInverted *= -1;
            rb.gravityScale *= -1;
            Rotation();
        }
    }

    public void ResetGravity()
    {
        isInverted = 1;
        rb.gravityScale = 1;
        Rotation();
    }
    void Rotation()
    {
        if (isInverted == -1f)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
        
    }
}
