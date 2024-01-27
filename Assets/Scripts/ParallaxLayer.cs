using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;
    public Transform cameraPosition;


    public void Move(float delta)
    {
        Vector3 newPos = transform.position;
        newPos.x -= delta * parallaxFactor;
        newPos.y = cameraPosition.position.y;

        transform.position = newPos;
    }

}
