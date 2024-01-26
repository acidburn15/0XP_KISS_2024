using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private string[] playerTag;
    bool picked = false;
    Transform playerTransform;
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
        if (playerTag.Contains(player.tag))
        {
            picked = true;
            playerTransform = player.transform;

        }
    }

    private void FollowTarget(Transform playerTransform)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerTransform.position.x - 1, playerTransform.position.y, 0), 6f * Time.deltaTime);
    }
}
