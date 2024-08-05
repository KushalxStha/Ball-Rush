using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 distance;

    void Start()
    {
        if (player != null)
            distance = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player != null)
            transform.position = player.position + distance;
    }
}