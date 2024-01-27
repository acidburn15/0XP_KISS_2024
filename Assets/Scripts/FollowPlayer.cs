using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private string[] playerTag;
    [SerializeField] private Animator noteAnimator;
    [SerializeField] public GameManager gameManager;
    public bool picked = false;
    private int offset;
    Transform playerTransform;
    public static float leftOrRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (picked)
        {
            FollowTarget(playerTransform);
        }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (playerTag.Contains(player.tag) && !picked)
        {
            gameManager.AddNoteCollected();
            offset = gameManager.notesCollected;
            picked = true;
            playerTransform = player.transform;

        }
    }

    private void FollowTarget(Transform playerTransform)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerTransform.position.x - (offset * leftOrRight), playerTransform.position.y, 0), 6f * Time.deltaTime);
    }

    public void ChangePickedState()
    {
        picked = false;
    }

    public void ChangeLeftOrRightState(float moveX)
    {
        if(moveX != 0)
        {
            leftOrRight = moveX;
        }
    }
}
