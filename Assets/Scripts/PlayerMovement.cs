using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject note;
    private bool top;
    private bool cooldown = false;

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

   

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        note.GetComponent<FollowPlayer>().ChangeLeftOrRightState(moveX);
        
        Vector3 moveDirection = new Vector3(moveX, 0).normalized;

        transform.position +=  moveDirection * (moveSpeed * Time.deltaTime);
    }
    
    private void InvertGravity()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !cooldown)
        {
            cooldown = true;
            rb.gravityScale *= -1;
            Rotation();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            cooldown = false;
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
