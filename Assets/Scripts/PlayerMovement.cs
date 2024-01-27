using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator playerAnimator;
    private GameObject note;
    private bool top;
    private bool cooldown = false;
    private int isInverted = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        if (note != null)
        {
            note.GetComponent<FollowPlayer>().ChangeLeftOrRightState(moveX);
        }
        
        Vector3 moveDirection = new Vector3(moveX, 0).normalized;

        transform.position +=  moveDirection * (moveSpeed * Time.deltaTime);

        // Animation
        if (moveX * isInverted > 0)
        {

            playerAnimator.Play("Player right");

        }

        else if (moveX * isInverted < 0)
        {
            playerAnimator.Play("Player left");
        }

        else if (moveX == 0)
        {

            playerAnimator.Play("Player idle");
        }
    }
    
    private void InvertGravity()
    {
        if (!cooldown && Input.GetKeyDown(KeyCode.Space))
        {
            cooldown = true;
            rb.gravityScale *= -1;
            isInverted *= -1;
            Rotation();
        }
    }

    void Rotation()
    {
        if (top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
        top = !top;
    }
}
