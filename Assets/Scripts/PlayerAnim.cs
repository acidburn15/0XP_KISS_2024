using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    float horizontal;
    int isInverted = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isInverted*=-1;
        }

            if (horizontal*isInverted > 0)
        {

            playerAnimator.Play("Player right");
            
        }

        else if (horizontal*isInverted < 0)
        {
            playerAnimator.Play("Player left");
        }

        else if(horizontal == 0) {

            playerAnimator.Play("Player idle");
        }
    }
}
